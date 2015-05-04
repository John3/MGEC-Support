//------------------------------------------------------
// Copyright 2105-2007, Hall Of Worlds, LLC.
//------------------------------------------------------

datablock WheeledVehicleData( variableSpeedPathFollower : DefaultCar ) 
{
   category = "gpgt";
   maxSteeringAngle = 0.785;  // Better than original car
   moveTol    = 5.0;
};

package exercisePackage_105
{

function startexercise105()
{     
   exerciseCenter.createSimplePath( "testPath" , 25 );
   %theBot = AIWheeledVehicle::spawn( exerciseCenter.getTransform() , variableSpeedPathFollower );
   %theBot.assignPath( testPath );
   %theBot.currentPathNodeNum = 0;
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , false );
   %pathNode.visibleMarker.setSkinName("green");
}

function variableSpeedPathFollower::onAdd( %DB, %theBot )
{
	%callerDBName = %DB.getName();
	echo(%callerDBName @ "::onAdd( " @ %DB.getID() @" , " @ %theBot @ " )");
   Parent::onAdd( %DB , %theBot );

	%theBot.setMoveTolerance( %DB.moveTol );
}

// 1 - Randomly select and apply a new speed between 10% and 100% of max.
function variableSpeedPathFollower::onReachDestination( %DB , %theBot )
{
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %pathNode.visibleMarker.setSkinName("red");
   %theBot.currentPathNodeNum = getRandom( 0 , 7 );
   
   // 1 
   // ?????

   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , false );
   %pathNode.visibleMarker.setSkinName("green");
}
};