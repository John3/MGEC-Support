//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
datablock PlayerData( variableSpeedBotA : BlueGuy ) 
{
   category = "gpgt";
   //maxAISpeed = ?????
};

package exercisePackage_006
{
function startexercise006()
{     
   exerciseCenter.createSimplePath( "testPath" , 15 );
   %theBot = AIPlayer::spawn( exerciseCenter.getTransform() , variableSpeedBotA );
   %theBot.assignPath( testPath );
   %theBot.currentPathNodeNum  = 0;
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , false );
   %pathNode.visibleMarker.setSkinName("green");
}

// 1
/*
function variableSpeedBotA::?????( %DB, %theBot )
{
   // 2
	// ?????
}
*/

function variableSpeedBotA::onReachDestination( %DB , %theBot )
{
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %pathNode.visibleMarker.setSkinName("red");
   %theBot.currentPathNodeNum++;
   if( %theBot.currentPathNodeNum > 7 ) %theBot.currentPathNodeNum = 0;
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , false );
   %pathNode.visibleMarker.setSkinName("green");   
}
};