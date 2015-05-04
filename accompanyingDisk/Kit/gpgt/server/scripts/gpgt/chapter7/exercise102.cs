//------------------------------------------------------
// Copyright 2102-2007, Hall Of Worlds, LLC.
//------------------------------------------------------

datablock WheeledVehicleData( wheeledPathFollower : DefaultCar ) 
{
   category = "gpgt";
   
   maxSteeringAngle = 0.785;  // Better than original car
   maxAISpeed = 0.8;
   moveTol    = 5.0;
};

package exercisePackage_102
{

// 1 - Create a path for our AIWheeledVehicle to follow.
// 2 - Spawn an AI wheeled vehicle using our datablock.
// 3 - Assign the path to our wheeled bot.
// 4 - Initialize the AI wheeled vehicle to start at path node zero.
// 5 - Start the AI wheeled vehicle moving towards the initial node.
function startexercise102()
{     
   // 1
   // ?????
   
   // 2
   // ?????
   
   // 3 
   // ?????
   
   // 4
   // ?????
   
   // 5
   // ?????
   // ?????
   
   %pathNode.visibleMarker.setSkinName("green");
}

function wheeledPathFollower::onAdd( %DB, %theBot )
{
	%callerDBName = %DB.getName();
	echo(%callerDBName @ "::onAdd( " @ %DB.getID() @" , " @ %theBot @ " )");
   Parent::onAdd( %DB , %theBot );
	%theBot.setMoveSpeed( %DB.maxAISpeed );
	%theBot.setMoveTolerance( %DB.moveTol );
}

// 1 - Swap path nodes (toggles between 0 and 1, over and over).
// 2 - Start the AI wheeled vehicle moving towards the next node.
function wheeledPathFollower::onReachDestination( %DB , %theBot )
{
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %pathNode.visibleMarker.setSkinName("red");

   // 1
   // ?????
   // ?????
   
   // 2
   // ?????
   // ?????

   %pathNode.visibleMarker.setSkinName("green");
}
};