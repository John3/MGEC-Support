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
   // FUNCTION BODY?
}

// CLIENT CODE
/*
function FUNCTION_NAME?( arguments? )
{
}
*/

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
}

// SERVER CODE 
/*
function FUNCTION_NAME?( %clientConn )
{
}
*/

};

