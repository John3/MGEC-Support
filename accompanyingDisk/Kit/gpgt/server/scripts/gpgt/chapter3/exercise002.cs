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
   //echo("Client Group (", ?????.getID() , ") contains these clients:");
   
  	//%count = ?????.getCount();
	for (%i = 0; %i < %count; %i++)
	{
		//%clientConn = ?????.getObject(%i);
		echo("Client #", %i, " ID: ", %clientConn.getID() );
   }
}

function dumpClientGroup2()
{
}

function dumpClientGroup3()
{
}

};

