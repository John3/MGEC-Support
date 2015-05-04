//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
package exercisePackage_002
{
function startexercise002()
{  
}

function dumpClientGroup()
{
   echo("Client Group (", ClientGroup.getID() , ") contains these clients:");
   
  	%count = ClientGroup.getCount();
	for (%i = 0; %i < %count; %i++)
	{
		%clientConn = ClientGroup.getObject(%i);
		echo("Client #", %i, " ID: ", %clientConn.getID() );
   }
}

function dumpClientGroup2()
{
   echo("Client Group (", ClientGroup.getID() , ") contains these clients:");
   
  	%count = ClientGroup.getCount();
	for (%i = 0; %i < %count; %i++)
	{
		%clientConn = ClientGroup.getObject(%i);
		
		if( isObject( localClientConnection ) && 
		    (%clientConn == localClientConnection.getID() ) )
      {
         echo("Client #", %i, " ID: ", %clientConn.getID() , " \c2(localClientConnection)" );
      }
      else
      {
		   echo("Client #", %i, " ID: ", %clientConn.getID() );
      }
   }
}

function dumpClientGroup3()
{
   echo("Client Group (", ClientGroup.getID() , ") contains these clients:");
   
  	%count = ClientGroup.getCount();
	for (%i = 0; %i < %count; %i++)
	{
		%clientConn = ClientGroup.getObject(%i);
		
		if( isObject( localClientConnection ) && 
		    (%clientConn == localClientConnection.getID() ) )
      {
         echo("Client #", %i, "\n > ClientConnection: ", %clientConn.getID() , " \c2(localClientConnection)" );
      }
      else
      {
		   echo("Client #", %i, "\n > ClientConnection: ", %clientConn.getID() );		   
      }
      
      %serverConn = %clientConn.getServerConnection();
      
      echo(" > ServerConnection: ", %serverConn );
   }   
}

};

