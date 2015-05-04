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

   // Accept the request and create a new proxy connection object
   $lastTCPObjectProxy = new TCPObject( TCPProxyConnection , %idBuf );
   
   TCPProxyGroup.add($lastTCPObjectProxy);
}

// *******************************************************
// TCP Object Client Callbacks
// *******************************************************
function TCPClient::onLine( %Obj , %line ) 
{
   echo("TCPClient::onLine( " @ %Obj @ " , " @ %line @ " ) " );
}

function TCPClient::onDNSResolved( %Obj ) 
{
   echo("TCPClient::onDNSResolved( " , %Obj , " )");
}

function TCPClient::onDNSFailed( %Obj ) 
{
   echo("TCPClient::onDNSFailed( " , %Obj , " )");
}

function TCPClient::onConnected( %Obj ) 
{
   echo("TCPClient::onConnected( " , %Obj , " )");
}

function TCPClient::onConnectFailed( %Obj ) 
{
   echo("TCPClient::onConnectFailed( " , %Obj , " )");
}

function TCPClient::onDisconnect( %Obj ) 
{
   echo("TCPClient::onDisconnect( " , %Obj , " )");
}

// *******************************************************
// TCP Object Proxy Callbacks
// *******************************************************
function TCPProxyConnection::onLine( %Obj , %line ) 
{
   echo("TCPProxyConnection::onLine( " @ %Obj @ " , " @ %line @ " ) " );
}

function TCPProxyConnection::onDisconnect( %Obj ) 
{
   echo("TCPProxyConnection::onDisconnect( " , %Obj , " )");
}


////
//		TCP0 - Simple Client to Server Connection
////
function TCP0() 
{
   cleanUp(); // PLEASE KEEP
   
   %server = new TCPObject( TCPServer );

   TCPServerGroup.add( %server );

   TCPServer.listen( 5000 );

   %client = new TCPObject( TCPClient );
   
   TCPClientGroup.add( %client );

   TCPClient.connect("IP:127.0.0.1:5000");
}

////
//		TCP1 - Simple Client to Proxy Message (immediate)
////
function TCP1() 
{
   TCP0();

   TCPClient.send("Client to Proxy -> Message 0\n"); // NEVER SENT
}

////
//		TCP1a - Simple Client to Proxy Message (delayed)
////
function TCP1a() 
{
   TCP0();

   TCPClient.send("Client to Proxy -> Message 0\n"); // GETS LOST
   TCPClient.schedule( 1000 , send , "Client to Proxy -> Message 1\n"); //OK
}

////
//		TCP1b - Simple Client to Proxy Message (delayed; multiple sends)
////
function TCP1b() 
{
   TCP0();

   TCPClient.schedule( 1000 , send , "Client to Proxy -> Message 0\n");
   TCPClient.schedule( 1000 , send , "Client to Proxy -> Message 1\n");
   TCPClient.schedule( 1000 , send , "Client to Proxy -> Message 2\n");
   TCPClient.schedule( 1000 , send , "Client to Proxy -> Message 3\n");
}

////
//		TCP2 - Simple Proxy to Client Message (works immediately)
////
function TCP2() 
{
   TCP0();

   ($lastTCPObjectProxy).send("Proxy to Client -> Message 0\n");
}

////
//		TCP2 - Simple Proxy to Client Message (works immediately)
////
function TCP2a() 
{
   TCP0();
   
   schedule( 1000 , 0 , delayedProxySend );   
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

   TCPClient.schedule( 1000 , send , "Client to Proxy -> Message 0 (no newline); ");
}

////
//		TCP3a - Client to Proxy Messages (effect of newline)
////
function TCP3a() 
{
   TCP0();

   TCPClient.schedule( 1000 , send , "Client to Proxy -> Message 0 (no newline); ");
   TCPClient.schedule( 2000 , send , "Client to Proxy -> Message 1 (w/ newline)\n");
}

////
//		TCP4 - Client to Proxy Messages (effect of disconnect)
////
function TCP4() 
{
   TCP0();
   
   TCPClient.schedule( 1000 , send , "Client to Proxy -> Message 0 (no newline); ");
   TCPClient.schedule( 1000 , disconnect );
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
   ($lastTCPObjectProxy).disconnect();
}



////
//		TCP5- Simple Client to Proxy Server (using localhost)
////
function TCP5() 
{
   cleanUp(); // PLEASE KEEP
   
   %server = new TCPObject( TCPServer );

   TCPServerGroup.add( %server );

   TCPServer.listen( 5000 );

   %client = new TCPObject( TCPClient );
   
   TCPClientGroup.add( %client );

   TCPClient.connect("localhost:5000");
   
   TCPClient.schedule( 1000 , send , "Client to Proxy -> localhost works too!\n");
}


};

