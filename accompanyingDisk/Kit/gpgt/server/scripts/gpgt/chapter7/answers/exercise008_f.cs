//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
datablock PlayerData( staticSpeedBot : BlueGuy ) 
{
   category = "gpgt";
   
   // Modify values specified in PlayerBody DB (staticSpeedBot->BlueGuy->PlayerBody)
   
   maxAISpeed = 1.0;


   // Original Values:
   // mass     = 90
   // runForce = 48 * 90;
   // maxForwardSpeed = 14;

   // New Values:
   //
   runForce        = 5 * 90;  // A slow starter, and ...
   maxForwardSpeed = 7;       // only half the  top speed.
   
   // Alternately you could write this.
   //runForce        = 5 * BlueGuy.mass;
   //maxForwardSpeed = 0.5 * BlueGuy.maxForwardSpeed;
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