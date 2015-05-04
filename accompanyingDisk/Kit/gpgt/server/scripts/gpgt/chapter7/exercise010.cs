//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
//
// Datablock definition(s) 
//
datablock PlayerData( lookAtObjectBot : BlueGuy ) 
{
   category = "gpgt";
   maxAISpeed = 0.6;
};

package exercisePackage_010
{

function startexercise010()
{     
   exerciseCenter.createSimplePath( "testPath" , 15 );
   %theBot = AIPlayer::spawn( exerciseCenter.getTransform() , lookAtObjectBot );
   %theBot.assignPath( testPath );
   %theBot.currentPathNodeNum  = 0;
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , false );
   %pathNode.visibleMarker.setSkinName("green");
}

function lookAtObjectBot::onAdd( %DB, %theBot )
{
	%callerDBName = %DB.getName();
	echo(%callerDBName @ "::onAdd( " @ %DB.getID() @" , " @ %theBot @ " )");
	%theBot.setMoveSpeed( %DB.maxAISpeed );
}

function lookAtObjectBot::onRemove( %DB, %theBot )
{
	%callerDBName = %DB.getName();
	echo(%callerDBName @ "::onRemove( " @ %DB.getID() @" , " @ %theBot @ " )");
}

// 1 - If the bot is not looking at an object, make it look at the player object.
function lookAtObjectBot::onReachDestination( %DB , %theBot )
{
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %pathNode.visibleMarker.setSkinName("red");
   %theBot.currentPathNodeNum++;
   if( %theBot.currentPathNodeNum > 7 ) %theBot.currentPathNodeNum = 0;
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , false );
   %pathNode.visibleMarker.setSkinName("green");

   // 1
   // ?????
}
};