//------------------------------------------------------
// Copyright 2104-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
datablock WheeledVehicleData( stopAndResumerWheeled : DefaultCar ) 
{
   category = "gpgt";
   maxSteeringAngle = 0.785;  // Better than original car
   maxAISpeed = 1.0;
   moveTol    = 5.0;
};

package exercisePackage_104
{

// 1 - Schedule a stop in 10 seconds.
function startexercise104()
{     
   exerciseCenter.createSimplePath( "testPath" , 25 );
   %theBot = AIWheeledVehicle::spawn( exerciseCenter.getTransform() , stopAndResumerWheeled );
   %theBot.assignPath( testPath );
   %theBot.currentPathNodeNum = 0;
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , true );
   %pathNode.visibleMarker.setSkinName("green");

   // 1
   %theBot.isMoving = true;
   %theBot.schedule( 10000 , stopOrResume );
}
function stopAndResumerWheeled::onAdd( %DB, %theBot )
{
	%callerDBName = %DB.getName();
	echo(%callerDBName @ "::onAdd( " @ %DB.getID() @" , " @ %theBot @ " )");
   Parent::onAdd( %DB , %theBot );
	%theBot.setMoveSpeed( %DB.maxAISpeed );
	%theBot.setMoveTolerance( %DB.moveTol );
}


function stopAndResumerWheeled::onReachDestination( %DB , %theBot )
{
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %pathNode.visibleMarker.setSkinName("red");
   %theBot.currentPathNodeNum++;
   if( %theBot.currentPathNodeNum > 7 ) %theBot.currentPathNodeNum = 0;
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , true );
   %pathNode.visibleMarker.setSkinName("green");
}

// 1 - If the bot is moving, 
//   - clear the moving flag
//   - stop the bot
//   - schedule another call to stopOrResume in 5 seconds
//   - return from the function
// 2 - If the bot is not moving, ...
// 3 - Set the moving flag.
// 4 - Get the last destination this bot was moving to.
// 5 - Test the last destination to see if it is valid.
// 5a - If it is not valid, directly call the onReachDestination() callback
// 5b - If it is valid, resume movement towards it.
// 6 - Schedule a new call to stopOrResume in 10 seconds.
function AIWheeledVehicle::stopOrResume( %theBot )  
{
   // 1
   if ( %theBot.isMoving )
   {
      %theBot.isMoving = false;
      // ?????
      %theBot.schedule( 1000 , stopOrResume );
      return;
   }
   // 2
   else
   {
      %theBot.isMoving = true;

      // ?????
   
      // 3
      if( !%oldDestination || %oldDestination $= "0 0 0"  )
      {
         // ?????
      }
      // 4
      else
      {
         // ?????
      }

      %theBot.schedule( 1000 , stopOrResume );
   }
}

};