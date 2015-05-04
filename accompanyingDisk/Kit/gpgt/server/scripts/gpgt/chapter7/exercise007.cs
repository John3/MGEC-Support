//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
datablock PlayerData( variableSpeedBotB : BlueGuy ) 
{
   category = "gpgt";
   maxAISpeed = 25.0; // Same as 1.0 (range is 0.0 to 1.0)
};

package exercisePackage_007
{
function startexercise007()
{     
   exerciseCenter.createSimplePath( "testPath" , 15 );
   %theBot = AIPlayer::spawn( exerciseCenter.getTransform() , variableSpeedBotB );
   %theBot.assignPath( testPath );
   %theBot.currentPathNodeNum  = 0;
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , false );
   %pathNode.visibleMarker.setSkinName("green");
}

function variableSpeedBotB::onAdd( %DB, %theBot )
{
	%callerDBName = %DB.getName();
	echo(%callerDBName @ "::onAdd( " @ %DB.getID() @" , " @ %theBot @ " )");
	%theBot.setMoveSpeed( %DB.maxAISpeed );
}

// 1 - Randomly select a new speed between 10% and 90% max rate
function variableSpeedBotB::onReachDestination( %DB , %theBot )
{
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %pathNode.visibleMarker.setSkinName("red");
   %theBot.currentPathNodeNum++;
   if( %theBot.currentPathNodeNum > 7 ) %theBot.currentPathNodeNum = 0;
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , false );
   
   // 1
   // ?????
   // ?????

   %pathNode.visibleMarker.setSkinName("green");
}
};