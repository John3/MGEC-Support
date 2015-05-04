//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------

// None in this example

package exercisePackage_001
{

function startexercise001()
{  
}

// ************************************************************************
// COMMAND Exercise 1 - BLACK OUT SCREEN
// ************************************************************************
// SERVER CODE
function fadeScreenOutandIn( %start, %outTime, %waitTime, %inTime )
{   
  	%count = ClientGroup.getCount();
	for (%i = 0; %i < %count; %i++)
	{
		%clientConn = ClientGroup.getObject(%i);
		commandToClient( %clientConn , 'fadeScreenOutandIn' , %start, %outTime, %waitTime, %inTime );
   }   
}

// CLIENT CODE
function clientCmdFadeScreenOutandIn( %start, %outTime, %waitTime, %inTime )
{
   echo("clientCmdFadeScreenOutandIn()" );
   
   serverConnection.schedule( %start , setBlackout , true, %outTime );

   serverConnection.schedule( %start + %outTime + %waitTime , setBlackout , false, %inTime );
}

// ************************************************************************
// COMMANDS Exercise 2 - Ghost Resolution
// ************************************************************************

// CLIENT CODE
function doRemoteGhostResolution()
{
   commandToServer( 'sendControlObjectGhostData' );
}

function clientCmdReceiveControlObjectGhostData( %ghostIndex ,  %serverObjectID ) 
{
   echo("clientCmdReceiveControlObjectGhostData()" );
   
   %ghostID = serverConnection.resolveGhostID( %ghostIndex );
   
   echo("This client's control object ghost index is ", %ghostIndex );
   echo("   This client's control object ghost ID is ", %ghostID );
   echo("  This client's control server object ID is ", %serverObjectID );
}

// SERVER CODE 
function serverCmdSendControlObjectGhostData( %clientConn )
{
   echo("serverCmdSendControlObjectGhostData(", %clientConn, ")" );
 
   %controlObject = %clientConn.getControlObject();
   
   %ghostIndex = %clientConn.getGhostID( %controlObject );
   
   commandToClient( %clientConn , 'ReceiveControlObjectGhostData' , %ghostIndex , %controlObject ); 
}

};

