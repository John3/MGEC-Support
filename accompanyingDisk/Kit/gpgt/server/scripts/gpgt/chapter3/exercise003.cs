//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
package exercisePackage_003
{

function startexercise003()
{  
   // Red Guy
	%theGuy = new AIPlayer() 
	{
		dataBlock = BlueGuy;
	};
	MissionGroup.add(%theGuy);
	%theGuy.setTransform( vectorAdd( "0 -3 0", exerciseCenter.getTransform()));
	%theGuy.setSkinName("red");

   // Blue Guy
	%theGuy = new AIPlayer() 
	{
		dataBlock = BlueGuy;
	};
	MissionGroup.add(%theGuy);
	%theGuy.setTransform(exerciseCenter.getTransform());
  

   // Green Guy
	%theGuy = new AIPlayer() 
	{
		dataBlock = BlueGuy;
	};
	MissionGroup.add(%theGuy);
	%theGuy.setTransform(vectorAdd( "0 3 0", exerciseCenter.getTransform()));
   %theGuy.setSkinName("green");
}

function dumpClientGroup4()
{
}

function dumpLocalGhostIndexes()
{
   //%cameraID = ?????
   //%playerID = ?????
   
   //%cameraGhost = ?????.?????( %cameraID );
   //%playerGhost = ?????.?????( %playerID );
   
   echo("The server object ID of the local camera is: ", %cameraID );
   echo("The server object ID of the local player is: ", %playerID );
   
   echo("The ghost index for the local camera is: ", %cameraGhost );
   echo("The ghost index for the local player is: ", %playerGhost );

}

function dumpServerObjectIDs()
{
   //%ghostCount = serverConnection.?????();
   
   echo("Resolving ghost indexes to server object IDs.");

   for( %count = 0; %count < %ghostCount; %count++ )
   {      
      //%serverObjectID = serverConnection.?????( %count );
      echo("Ghost Index #", %count, " translates to server object ID: ",
           %serverObjectID ,
           " Class Name: ", %serverObjectID.getClassName());      
   }
}

function dumpGhostIDs()
{
   //%ghostCount = serverConnection.?????();
   
   echo("Resolving ghost indexes to ghosts for local server and client.");

   for( %count = 0; %count < %ghostCount; %count++ )
   {      
      //%ghostID = localClientConnection.?????( %count );
      echo("Ghost Index #", %count, " translates to ghost object ID: ",
           %ghostID ,
           " Class Name: ", %ghostID.getClassName());      
   }
}


};

