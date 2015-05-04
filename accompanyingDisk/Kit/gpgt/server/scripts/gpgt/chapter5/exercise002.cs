//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------

// None in this example

package exercisePackage_002
{

function startexercise002()
{  
   if(!isObject(TCPProxyGroup))  new SimGroup(TCPProxyGroup);
   if(!isObject(TCPServerGroup)) new SimGroup(TCPServerGroup);
   if(!isObject(TCPClientGroup)) new SimGroup(TCPClientGroup);
}

function exerciseStarter::onRemove( %this )
{   
   if(isObject(TCPProxyGroup))TCPProxyGroup.delete();
   if(isObject(TCPServerGroup))TCPServerGroup.delete();
   if(isObject(TCPClientGroup))TCPClientGroup.delete();

   Parent::onRemove( %this );
}

function cleanUp()
{
   TCPProxyGroup.deleteSet(false);
   TCPServerGroup.deleteSet(false);
   TCPClientGroup.deleteSet(false);
}

// *******************************************************
// TCP Object Server Callbacks
// *******************************************************
function TCPServer::onConnectRequest( %Obj , %addrBuf , %idBuf ) 
{   
   echo("TCPServer::onConnectRequest( " @ %Obj @ " , " @ %addrBuf @ " , " @ %idBuf @ " ) " );
   
//   $lastTCPObjectProxy = ??????
   
   TCPProxyGroup.add($lastTCPObjectProxy);
}

// *******************************************************
// TCP Object Client Callbacks
// *******************************************************
function TCPClient::onLine( %Obj , %line ) 
{
}
function TCPClient::onConnected( %Obj ) 
{
}
function TCPClient::onConnectFailed( %Obj ) 
{
}
function TCPClient::onDisconnect( %Obj ) 
{
}

// *******************************************************
// TCP Object Proxy Callbacks
// *******************************************************
function TCPProxyConnection::onDisconnect( %Obj ) 
{
}


////
//		TCP0 - Simple Client to Server Connection
////
function TCP0() 
{
   cleanUp(); // PLEASE KEEP
//   %server = ??????
//   TCPServerGroup.add( %server );
//   listen?
//   %client = ??????
//   TCPClientGroup.add( %client );
//   connect?

}

////
//		TCP1 - Simple Client to Proxy Message (immediate)
////
function TCP1() 
{
   TCP0();
}

////
//		TCP1a - Simple Client to Proxy Message (delayed)
////
function TCP1a() 
{
   TCP0();
}

////
//		TCP1b - Simple Client to Proxy Message (delayed; multiple sends)
////
function TCP1b() 
{
   TCP0();
}

////
//		TCP2 - Simple Proxy to Client Message (works immediately)
////
function TCP2() 
{
   TCP0();
}

////
//		TCP2 - Simple Proxy to Client Message (works immediately)
////
function TCP2a() 
{
   TCP0();
}
function delayedProxySend()
{
   $lastTCPObjectProxy.send("Proxy to Client -> Message 0\n");
}


////
//		TCP3 - Client to Proxy Messages (effect of newline)
////
function TCP3() 
{
   TCP0();
}

////
//		TCP3a - Client to Proxy Messages (effect of newline)
////
function TCP3a() 
{
   TCP0();
}

////
//		TCP4 - Client to Proxy Messages (effect of disconnect)
////
function TCP4() 
{
   TCP0();
}

////
//		TCP4a - Client to Proxy Messages (effect of disconnect on other agent's messages)
////
function TCP4a() 
{
   TCP0();
   
   TCPClient.schedule( 1000 , send , "Client to Proxy -> Message 0 (no newline); ");
   schedule( 1500 , 0 , delayedProxyDisconnect );      
}
function delayedProxyDisconnect()
{
// ($lastTCPObjectProxy).????????
}

////
//		TCP5- Simple Client to Server Connection (using localhost)
////
function TCP5() 
{
   cleanUp(); // PLEASE KEEP
}


};

