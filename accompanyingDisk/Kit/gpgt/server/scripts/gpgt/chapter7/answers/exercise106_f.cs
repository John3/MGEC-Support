//------------------------------------------------------
// Copyright 2106-2007, Hall Of Worlds, LLC.
//------------------------------------------------------

datablock WheeledVehicleData( staticSpeedPathFollower : DefaultCar ) 
{
   category = "gpgt";
   maxSteeringAngle = 0.785;  // Better than original car
   moveTol    = 10.0;

   // Rigid Body
   mass = 200;
   // Engine
   engineTorque = 50000;       // Engine power
};

package exercisePackage_106
{

function startexercise106()
{     
   exerciseCenter.createSimplePath( "testPath" , 25 );
   %theBot = AIWheeledVehicle::spawn( exerciseCenter.getTransform() , staticSpeedPathFollower );
   %theBot.assignPath( testPath );
   %theBot.currentPathNodeNum = 0;
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , false );
   %pathNode.visibleMarker.setSkinName("green");
}

function staticSpeedPathFollower::onAdd( %DB, %theBot )
{
	%callerDBName = %DB.getName();
	echo(%callerDBName @ "::onAdd( " @ %DB.getID() @" , " @ %theBot @ " )");
   Parent::onAdd( %DB , %theBot );

	%theBot.setMoveTolerance( %DB.moveTol );
}

function staticSpeedPathFollower::onReachDestination( %DB , %theBot )
{
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %pathNode.visibleMarker.setSkinName("red");
   %theBot.currentPathNodeNum = getRandom( 0 , 7 );
   %theBot.setMoveSpeed( getRandom( 1 , 10 ) / 10 );
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , false );
   %pathNode.visibleMarker.setSkinName("green");
}
};