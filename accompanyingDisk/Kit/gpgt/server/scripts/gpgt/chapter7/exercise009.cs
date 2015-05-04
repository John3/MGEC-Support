//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
datablock PlayerData( lookAtPositionBot : BlueGuy ) 
{
   category = "gpgt";
   maxAISpeed = 0.6;
};

package exercisePackage_009
{

function startexercise009()
{     
   exerciseCenter.createSimplePath( "testPath" , 15 );
   %theBot = AIPlayer::spawn( exerciseCenter.getTransform() , lookAtPositionBot );
   %theBot.assignPath( testPath );
   %theBot.currentPathNodeNum  = 0;
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , false );
   %pathNode.visibleMarker.setSkinName("green");
}

function lookAtPositionBot::onAdd( %DB, %theBot )
{
	%callerDBName = %DB.getName();
	echo(%callerDBName @ "::onAdd( " @ %DB.getID() @" , " @ %theBot @ " )");
	%theBot.setMoveSpeed( %DB.maxAISpeed );
}


// 1 - Randomly select a node on the path to look at an make the bot look there.
function lookAtPositionBot::onReachDestination( %DB , %theBot )
{
   
   if( isObject(%theBot.aimNode) ) (%theBot.aimNode).visibleMarker.setSkinName("red");
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %pathNode.visibleMarker.setSkinName("red");
   %theBot.currentPathNodeNum++;
   if( %theBot.currentPathNodeNum > 7 ) %theBot.currentPathNodeNum = 0;
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , false );
   %pathNode.visibleMarker.setSkinName("green");

   // 1 
   %theBot.aimNode = %theBot.myPath.getObject( getRandom( 0 , 7 ) );
   // ?????

   (%theBot.aimNode).visibleMarker.setSkinName("yellow");
}
};