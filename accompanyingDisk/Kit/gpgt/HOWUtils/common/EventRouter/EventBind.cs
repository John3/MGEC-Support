//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
function getDeviceActionMod( %device , %action )
{
   return "edo"; //EFM - finish this to complete functionality
}

// This method does the following:
// 1. Generates a new function (based on the device and action type) to generate the specified event.
// 2. Binds this binds this new function to the specified device + action combo.
//
function ActionMap::bindEvent(  %actionMap, %device, %action, %a0, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a9 )
{    
   // Following line bypasses a bug in the script parser
   %a0 = %a0; %a1 = %a1; %a2 = %a2; %a3 = %a3; %a4 = %a4; %a5 = %a5; %a6 = %a6; %a7 = %a7; %a8 = %a8; %a9 = %a9;
   
   // Extract event name (always last argument)
   for( %count = 0; %count < 10; %count++)
   {
      if( "" !$= %a[%count] ) 
      {
         %eventName = %a[%count];
      }
   }

   %newfuncName = "AMEvntBndr_" @ %device @ %action @%eventName;
   %evalStr = "function " @ %newfuncName @ "( %val ) "
              @ "{"
              @ "   postEvent( " @ %eventName @ " , %val , " @ getDeviceActionMod( %device , %action ) @ " );"
              @ "}";
              
   //echo( %evalStr );
   eval( %evalStr );

   %done = false;
   %evalStr = %actionMap.getID() @ ".bind(" @ %device @ "," @ %action;
   for( %count = 0; %count < 10 && !%done; %count ++)
   {
      if( %a[%count] $= %eventName  )
      {
            %evalStr = %evalStr @ "," @ %newfuncName @ ");";
            %done = true;            
      }
      else
      {
         %evalStr = %evalStr @ ",\"" @ %a[%count] @ "\""; 
      }
   } 
   //echo( %evalStr );
   eval( %evalStr );
}
