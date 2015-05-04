//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
datablock PlayerData( randomPathFollower : BlueGuy ) 
{
   category = "gpgt";
};

package exercisePackage_004
{

// 1 - Create a path for our AIPlayer to follow.
// 2 - Spawn an AI player using our datablock.
// 3 - Assign the path to our bot.
// 4 - Select a random first node.
// 5 - Start the AI player moving towards the initial node.
function startexercise004()
{     
   // 1
   exerciseCenter.createSimplePath( "testPath" , 15 );
   
   // 2
   %theBot = AIPlayer::spawn( exerciseCenter.getTransform() , randomPathFollower );
   
   // 3 
   %theBot.assignPath( testPath );
   
   // 4
   %theBot.currentPathNodeNum = getRandom( 0 , 7 );
   
   // 5
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , true );

   %pathNode.visibleMarker.setSkinName("green");
}

// 1 - Select a new (random) destination node in the path.
// 2 - Start the AI player moving towards the next node.
function randomPathFollower::onReachDestination( %DB , %theBot )
{
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %pathNode.visibleMarker.setSkinName("red");
   
   // 1
   %theBot.currentPathNodeNum = getRandom( 0 , 7 );
   
   // 2
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , true );

   %pathNode.visibleMarker.setSkinName("green");   
}
};