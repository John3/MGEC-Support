//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
function initializeEventRouterSystem(  )
{
   if(isObject("GER"))
   {
      error("ERROR::initializeEventRouterSystem():\nSystem already initialized!\n",
            "Please delete GER before re-initializing system.");
      return 0;
   }
   return( createEventRouter( "GER" ) );
}

function cleanupEventRouterSystem(  )
{
   if(!isObject("GER") ) return;
   
   GER.deleteSet(true);
}

function createEventRouter( %name )
{
   if( isObject( %name ) )
   {
      error("ERROR::createEventRouter():\nObject with name ", %name , " already exists.\n",
            "Event routers must all have UNIQUE names or NO name.");
      return 0;
   }
   
   if( ("GER" !$= %name ) && (!isObject("GER")) )
   {
      error("ERROR::createEventRouter():\nBefore creating task specific routers, please call initializeEventRouterSystem() once.");
      return 0;
   }
   
   %theRouter = new scriptGroup( %name )
   {
      class = "eventRouter";
      enabled = true;
   };
   
   if ("GER" !$= %name ) GER.add( %theRouter );

   %theRouter.eventHandlers = new SimSet();
   %theRouter.eventChains   = new SimSet();

   return %theRouter;
}

// Add new event to list of catchable events
function eventRouter::registerEvent( %theRouter, %eventName, %description ) 
{
   %theRouter.eventList[%eventName] = "enabled";
   %theRouter.eventList[%eventName,description] = %description;
}

// Add new event to list of catchable events
function eventRouter::unregisterEvent( %theRouter, %eventName, %description ) 
{
	%theRouter.eventList[%eventName] = "";
	%theRouter.eventList[%eventName,description] = "";
}

// Checks to see if %eventName is catchable event
function eventRouter::isValidEvent( %theRouter, %eventName )
{
   if( "" $= %theRouter.eventList[%eventName] ) 
   {
       return false;
   }
   return true;
}

// Enables catching of event %eventName
function eventRouter::enableEvent( %theRouter, %eventName )
{

 // Auto-register if user didn't do so already
	if( false == %theRouter.isValidEvent( %eventName ) )
	{
		%theRouter.registerEvent( %eventName , "" );
	}
	%theRouter.eventList[%eventName] = "enabled";
}

// Disables catching of event %eventName
function eventRouter::disableEvent( %theRouter, %eventName )
{
 // Auto-register if user didn't do so already
	if( false == %theRouter.isValidEvent( %eventName ) )
	{
		%theRouter.registerEvent( %eventName , "" );
	}
	%theRouter.eventList[%eventName] = "disabled";
}

// Disables catching of event %eventName
function eventRouter::isEventEnabled( %theRouter, %eventName )
{
	return( "enabled" $= %theRouter.eventList[%eventName] );
}

function eventRouter::enable( %theRouter )
{
	%theRouter.enabled = true;
}

function eventRouter::disable( %theRouter )
{
	%theRouter.enabled = false;
}

// Disables catching of event %eventName
function eventRouter::isEnabled( %theRouter )
{
	return( %theRouter.enabled );
}

// Dumps all details about the current event handler
function eventRouter::dump( %theRouter )
{
	//EFM TBD
	Parent::dump( %theRouter );
}

// Dumps all details about the current event handler
function eventRouter::dumpEvent( %theRouter , %eventName )
{
	echo("Router ", %theRouter.getName() , (%theRouter.isEnabled) ? " enabled" : " disabled" );

	if( false == %theRouter.isValidEvent( %eventName ) )
	{
		echo("Event ", %eventName , " was not registered to this event handler! " );
		return;
	}
	//EFM TBD
}

// Deletes the event router and contents
function eventRouter::delete( %theRouter )
{
	%theRouter.eventHandlers.deleteSet(true);
	%theRouter.eventChains.deleteSet(true);
	Parent::delete( %theRouter );
}

//Registers a handler to catch an event.
function eventRouter::registerHandler( %theRouter, %eventName , %handler ) 
{
 // Auto-register if user didn't do so already
	if( false == %theRouter.isValidEvent( %eventName ) )
	{
		%theRouter.registerEvent( %eventName , "" );
	}

	%eventHandler = new ScriptObject()
	{
		handler   = %handler;
		eventName = %eventName;
	};

	%theRouter.eventHandlers.add( %eventHandler );
}

//Registers a handler method to catch an event, calls this method on registered object
function eventRouter::registerHandlerMethod( %theRouter, %eventName , %handler , %obj ) 
{
 // Auto-register if user didn't do so already
	if( false == %theRouter.isValidEvent( %eventName ) )
	{
		%theRouter.registerEvent( %eventName , "" );
	}
	
	if( !isObject( %obj  ) )
	{
	   error("ERROR:: eventRouter::registerHandlerMethod() - Invalid Object ID, did you mean to call registerHandler()?");
	   return;
	}

	%eventHandler = new ScriptObject()
	{
		methodHandler   = %handler;
		obj             = %obj.getID();
		eventName       = %eventName;
	};

	%theRouter.eventHandlers.add( %eventHandler );
}

// Registers an event to fired when %eventName is fired
function eventRouter::registerChainedEvent( %theRouter, %eventName , %chainedEventName ) 
{
 // Auto-register if user didn't do so already
	if( false == %theRouter.isValidEvent( %eventName ) )
	{
		%theRouter.registerEvent( %eventName , "" );
	}
 // Auto-register if user didn't do so already
	if( false == %theRouter.isValidEvent( %chainedEventName ) )
	{
		%theRouter.registerEvent( %chainedEventName , "" );
	}

	%eventChain = new ScriptObject()
	{
		eventName        = %eventName;
		chainedEventName = %chainedEventName;
	};

	//EFM  Add code to check for loops

	%theRouter.eventChains.add( %eventChain );
}

// EFM this may be wrong ==> // EFM need one for handlermethod too
// Check for handlers with non-zero objects that are no longer valid objects and delete the associated handler object
function eventRouter::unregisterHandler( %theRouter, %eventName , %handler )
{
	%deadHandlers = new simSet();

	%stmt = "if( ( tok.handler $= " @ %handler @ " ) && ( tok.eventName $= " @ %eventName @ " ) ) " @ %deadHandlers @ ".add(tok);";

	%theRouter.eventHandlers.forEachStmt(  %stmt , "tok" );

	%deadHandlers.deleteSet(true);
}

function eventRouter::unregisterMethodHandler( %theRouter, %eventName , %handlerMethod , %obj ) 
{
	%deadHandlers = new simSet();

	%stmt = "if( ( tok.obj == " @ %obj @ " ) && ( tok.handlerMethod $= " @ %handlerMethod @ " ) && ( tok.eventName $= " @ %eventName @ " ) ) " @ %deadHandlers @ ".add(tok);";

	%theRouter.eventHandlers.forEachStmt(  %stmt , "tok" );

	%deadHandlers.deleteSet(true);
}

function eventRouter::unregisterDeadObjects( %theRouter  ) 
{
	%deadHandlers = new simSet();

	%stmt = "if( !isObject( tok.obj ) ) " @ %deadHandlers @ ".add(tok);";

	%theRouter.eventHandlers.forEachStmt(  %stmt , "tok" );

	%deadHandlers.deleteSet(true);
}

function eventRouter::unregisterObject( %theRouter, %obj ) 
{
	%deadHandlers = new simSet();

	%stmt = "if( tok.obj == " @ %obj @ " ) " @ %deadHandlers @ ".add(tok);";

	%theRouter.eventHandlers.forEachStmt(  %stmt , "tok" );

	%deadHandlers.deleteSet(true);
}

// Post event to all registered routers
function postEvent( %eventName , %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10 )
{
   if(!isObject("GER") )
   {
      error("ERROR::postEvent():\nPlease call initializeEventRouterSystem() before posting events.");
      return 0;
   }
   
   GER.eventProcessingStack = pushWordFront( GER.eventProcessingStack , %eventName );
   
   // Post event to any handlers in GER first
   GER.postEvent( %eventName , %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10 );
   
   // Post event to any registered routers next
   for(%count = 0; %count < GER.getCount(); %count++)
   {
      (GER.getObject(%count)).postEvent( %eventName , %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10 );
   }
   
   if( %eventName !$= getWord( GER.eventProcessingStack  , 0 ) )
   {
      error("ERROR:: eventRouter::postEvent() - Event ", %eventName, "got popped prematurely?");
      error("ERROR:: eventRouter::postEvent() - Front event is: ", getWord( GER.eventProcessingStack , 0 ));
   }
   
   GER.eventProcessingStack = popWordFront( GER.eventProcessingStack );
}

function eventRouter::postEvent( %theRouter, %eventName , %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10 )  // Post an event for handling with up to 10 optional arguments
{
	if( false == %theRouter.isValidEvent( %eventName ) )
	{
      //warn(%theRouter.getName(), ":: Event ", %eventName , " was not registered to this event handler?" );
      return;
	}

	if( false == %theRouter.isEnabled() ) return false;

	for( %count = 0 ; %count < %theRouter.eventHandlers.getCount(); %count++ )
	{
		%theHandlerObject = %theRouter.eventHandlers.getObject( %count );

		if(%theHandlerObject.eventName !$= %eventName ) continue;

		if( false == %theRouter.isEventEnabled( %theHandlerObject.eventName ) ) continue;

		if( "" !$= %theHandlerObject.handler )
		{
      //echo("\c5Event: " , %eventName , " ==> Handler: ", %theHandlerObject.handler );
      call( %theHandlerObject.handler , %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10 );		
		}
		else if ( ( "" !$= %theHandlerObject.methodHandler )  && (isObject( %theHandlerObject.obj ) ) )
		{
      //echo("\c5Event: " , %eventName , " ==> Method Handler: ", %theHandlerObject.methodHandler, " ==> Obj: ", %theHandlerObject.obj );
      
      for( %count2 = 1; %count2 <= 10 ; %count2++ ) 
      {
         %arg[%count2] = ("" $= %a[%count2]) ? "\"\"" : "\"" @ %a[%count2] @ "\""  ;
      }
      
      if( "" $= %a1 )
      {
         %evalStr = %theHandlerObject.obj @ "." @ %theHandlerObject.methodHandler @"();";
      }
      else
      {
         %evalStr = %theHandlerObject.obj @ "." @ %theHandlerObject.methodHandler @"("@
               %arg1@","@
               %arg2@","@
               %arg3@","@
               %arg4@","@
               %arg5@","@
               %arg6@","@
               %arg7@","@
               %arg8@","@
               %arg9@","@
               %arg10@");";		
      }
            
      //echo( %evalStr );
      eval( %evalStr );
		}
//EFM add code to remove dead objects ??
	}
	%theRouter.fireChainedEvents( %eventName , %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10 );
}

function eventRouter::fireChainedEvents( %theRouter, %eventName , %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10 )  // Post an event for handling with up to 10 optional arguments
{
	if( false == %theRouter.isValidEvent( %eventName ) )
	{
		warn("Event ", %eventName , " was not registered to this event handler?" );
		return false;
	}

	if( false == %theRouter.isEnabled() ) return false;

	for( %count = 0 ; %count < %theRouter.eventChains.getCount(); %count++ )
	{
		%theChainObject = %theRouter.eventChains.getObject( %count );

		if(%theChainObject.eventName !$= %eventName ) continue;

		if( false == %theRouter.isEventEnabled( %theChainObject.eventName ) ) continue;

		//echo("\c3Event: " , %eventName , " ==> Chained Event: ", %theChainObject.chainedEventName );

		%theRouter.postEvent( %theChainObject.chainedEventName , %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10 );
	}
}

function getCurrentlyProcessingEvent()
{
   if(!isObject("GER") )
   {
      return "";
   }
   return getWord( GER.eventProcessingStack  , 0 );
}

