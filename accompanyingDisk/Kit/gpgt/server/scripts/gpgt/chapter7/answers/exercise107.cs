//------------------------------------------------------
// Copyright 2107-2007, Hall Of Worlds, LLC.
//------------------------------------------------------

// 1 - Experiment with move tolerances
datablock WheeledVehicleData( toleranceTestingCar : DefaultCar ) 
{
   category = "gpgt";
   
   maxSteeringAngle = 0.785;  // Better than original car
   maxAISpeed = 1.0;
   
   // 1
   moveTol    = 0.5; // Gets stuck in a loop going around a node.
   //moveTol    = 2; // Barely enough
   //moveTol    = 100; // Sits in the center, never moving, just turning its wheels.
   //moveTol    = 11.8/2; // Perfect (for a circle) (half-way to next point)
   
};

package exercisePackage_107
{
// 2 - Repeat experiments after generating random path instead.
function startexercise107()
{  

   // 2
   exerciseCenter.createSimplePath( "testPath" , 15 );
   //exerciseCenter.createSimplePathRandomRadius( "testPath" , 5 , 35 );   
   
   %theBot = AIWheeledVehicle::spawn( exerciseCenter.getTransform() , toleranceTestingCar );
   %theBot.assignPath( testPath );
   %theBot.currentPathNodeNum = 0;
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , false );
   %pathNode.visibleMarker.setSkinName("green");
}

function toleranceTestingCar::onAdd( %DB, %theBot )
{
	%callerDBName = %DB.getName();
	echo(%callerDBName @ "::onAdd( " @ %DB.getID() @" , " @ %theBot @ " )");
   Parent::onAdd( %DB , %theBot );
	%theBot.setMoveSpeed( %DB.maxAISpeed );
	%theBot.setMoveTolerance( %DB.moveTol );
}

function toleranceTestingCar::onReachDestination( %DB , %theBot )
{
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %pathNode.visibleMarker.setSkinName("red");
   %theBot.currentPathNodeNum++;
   if( %theBot.currentPathNodeNum > 7 ) %theBot.currentPathNodeNum = 0;
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , false );
   %pathNode.visibleMarker.setSkinName("green");
}
};