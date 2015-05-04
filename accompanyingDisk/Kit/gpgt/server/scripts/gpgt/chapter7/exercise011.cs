//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------

datablock PlayerData( aimBot : BlueGuy ) 
{
   category = "gpgt";
};

datablock PlayerData( targetBot : BlueGuy ) 
{
   category = "gpgt";
   maxAISpeed = 0.6;
};

package exercisePackage_011
{

// 1 - Create a path for our AIPlayer to follow.
// 2 - Spawn an AI player aimBot datablock.
// 3 - Spawn an AI player targetBot datablock.
// 4 - Make the aim bot aim at the target bot.
// 5 - Assign the path to our target bot.
// 6 - Initialize the target bot to start at path node zero.
// 7 - Start the target bot moving towards the initial node.
function startexercise011()
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
   
   // 6
   // ?????
   
   // 7
   // ?????
   // ?????

   %pathNode.visibleMarker.setSkinName("green");
}

function targetBot::onAdd( %DB, %theBot )
{
	%callerDBName = %DB.getName();
	echo(%callerDBName @ "::onAdd( " @ %DB.getID() @" , " @ %theBot @ " )");
	%theBot.setMoveSpeed( %DB.maxAISpeed );
}

function targetBot::onReachDestination( %DB , %theBot )
{
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %pathNode.visibleMarker.setSkinName("red");
   %theBot.currentPathNodeNum++;
   if( %theBot.currentPathNodeNum > 7 ) %theBot.currentPathNodeNum = 0;
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , false );
   %pathNode.visibleMarker.setSkinName("green");
}

// 1 - Write declaration for callback that is called when a target enters the
//     aiming bot's line-of-sight
//function ?????
//{
///   %theBot.setSkinName("green");
//}

// 2 - Write declaration for callback that is called when a target exits the
//     aiming bot's line-of-sight
//function ?????
//{
//   %theBot.setSkinName("red");
//}
};