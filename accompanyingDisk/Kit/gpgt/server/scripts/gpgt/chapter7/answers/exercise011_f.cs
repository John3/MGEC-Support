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
// 4 - Make the aim bot aim at the target bot 
// 5 - Assign the path to our target bot.
// 6 - Initialize the target bot to start at path node zero.
// 7 - Start the target bot moving towards the initial node.
function startexercise011()
{     
   // 1
   exerciseCenter.createSimplePath( "testPath" , 15 );
   
   // 2
   %theBot = AIPlayer::spawn( exerciseCenter.getTransform() , aimBot );
   
   // 3
   %theBot2 = AIPlayer::spawn( exerciseCenter.getTransform() , targetBot );
   
   // 4
   %theBot.setAimObject( %theBot2 , "0 0 1.5" );
   
   // 5 
   %theBot2.assignPath( testPath );
   
   // 6
   %theBot2.currentPathNodeNum  = 0;
   
   // 7
   %pathNode = %theBot2.myPath.getObject( %theBot2.currentPathNodeNum );
   %theBot2.setMoveDestination( %pathNode.getTransform() , false );

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
function aimBot::onTargetEnterLOS( %DB , %theBot )
{
   %theBot.setSkinName("green");
}

// 2 - Write declaration for callback that is called when a target exits the
//     aiming bot's line-of-sight
function aimBot::onTargetExitLOS( %DB , %theBot )
{
   %theBot.setSkinName("red");
}
};