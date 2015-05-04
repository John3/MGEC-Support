//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
datablock PlayerData( staticSpeedBot : BlueGuy ) 
{
   category = "gpgt";
   maxAISpeed = 0.5;      
   // ?????
};

package exercisePackage_008
{
function startexercise008()
{     
   exerciseCenter.createSimplePath( "testPath" , 15 );
   
   %theBot = AIPlayer::spawn( exerciseCenter.getTransform() , staticSpeedBot );
   
   %theBot.assignPath( testPath );
   
   %theBot.currentPathNodeNum  = 0;
   
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , true );

   %pathNode.visibleMarker.setSkinName("green");
}

function staticSpeedBot::onAdd( %DB, %theBot )
{
	%callerDBName = %DB.getName();
	echo(%callerDBName @ "::onAdd( " @ %DB.getID() @" , " @ %theBot @ " )");
	
	%theBot.setMoveSpeed( %DB.maxAISpeed );
}


function staticSpeedBot::onReachDestination( %DB , %theBot )
{   
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %pathNode.visibleMarker.setSkinName("red");
   
   %theBot.schedule( 500 , resume );
}

function AIPlayer::resume( %theBot )
{
   %theBot.currentPathNodeNum++;
   if( %theBot.currentPathNodeNum > 7 ) %theBot.currentPathNodeNum = 0;
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , true );
   %pathNode.visibleMarker.setSkinName("green");   
}
};