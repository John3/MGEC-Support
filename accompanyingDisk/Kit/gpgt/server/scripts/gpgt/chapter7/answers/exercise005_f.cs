//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------

datablock PlayerData( stopAndResumer : BlueGuy ) 
{
   category = "gpgt";
};

package exercisePackage_005
{

// 1 - Schedule a stop in 1 second and resume in 2 seconds.
function startexercise005()
{     
   exerciseCenter.createSimplePath( "testPath" , 15 );
   %theBot = AIPlayer::spawn( exerciseCenter.getTransform() , stopAndResumer );
   %theBot.assignPath( testPath );
   
   // 1
   %theBot.isMoving = true;
   %theBot.schedule( 1000 , stopOrResume );
}

function stopAndResumer::onReachDestination( %DB , %theBot )
{
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %pathNode.visibleMarker.setSkinName("red");
   %theBot.currentPathNodeNum = getRandom( 0 , 7 );
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , true );
   %pathNode.visibleMarker.setSkinName("green");
}

// 1 - If the bot is moving, 
//   - clear the moving flag
//   - stop the bot
//   - schedule another call to stopOrResume in 1 second
//   - return from the function
// 2 - If the bot is not moving, ...
// 3 - Set the moving flag.
// 4 - Get the last destination this bot was moving to.
// 5 - Test the last destination to see if it is valid.
// 5a - If it is not valid, directly call the onReachDestination() callback
// 5b - If it is valid, resume movement towards it.
// 6 - Schedule a new call to stopOrResume in 1 second.
function AIPlayer::stopOrResume( %theBot )
{
   // 1
   if ( %theBot.isMoving )
   {
      %theBot.isMoving = false;
      %theBot.stop();      
      %theBot.schedule( 1000 , stopOrResume );
      return;
   }
   // 2
   else
   {
      // 3
      %theBot.isMoving = true;

      // 4
      %oldDestination = %theBot.getMoveDestination( );
   
      // 5
      if( !%oldDestination || %oldDestination $= "0 0 0"  )
      {
         // 5a
         %theBot.getDatablock().onReachDestination( %theBot );
      }
      else
      {
         // 5b
         %theBot.setMoveDestination( %oldDestination , true );
      }

      // 6
      %theBot.schedule( 1000 , stopOrResume );
   }
}

};