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

function AIPlayer::stopOrResume( %theBot )  // EFM make comment on fact that only AIPlayer namespace works
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