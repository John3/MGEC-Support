//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
datablock PlayerData( loopingPathFollower : BlueGuy ) 
{
   category = "gpgt";
};

package exercisePackage_003
{

// 1 - Create a path for our AIPlayer to follow.
// 2 - Spawn an AI player using our datablock.
// 3 - Assign the path (from 1) to our AI player (from 2).
// 4 - Initialize the AI player to start at path node zero.
// 5 - Start the AI player moving towards the initial node.
// 6 - Update the node's visual feedback. (optional)
function startexercise003()
{     
   // 1
   exerciseCenter.createSimplePath( "testPath" , 15 );
   
   // 2
   %theBot = AIPlayer::spawn( exerciseCenter.getTransform() , loopingPathFollower );
   
   // 3 
   %theBot.assignPath( testPath );
   
   // 4
   %theBot.currentPathNodeNum  = 0;
   
   // 5
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , false );

   %pathNode.visibleMarker.setSkinName("green");
}


// 1 - Select the number of the next node in the loop.
// 2 - Move the bot towards the next node.
//
function loopingPathFollower::onReachDestination( %DB , %theBot )
{
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %pathNode.visibleMarker.setSkinName("red");

   // 1
   %theBot.currentPathNodeNum++;
   if( %theBot.currentPathNodeNum > 7 ) %theBot.currentPathNodeNum = 0;
   
   // 2
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , false );

   %pathNode.visibleMarker.setSkinName("green");
}
};