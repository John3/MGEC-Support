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
function startexercise003()
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


// 1 - Select the number of the next node in the loop.
// 2 - Move the bot towards the next node.
//
function loopingPathFollower::onReachDestination( %DB , %theBot )
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