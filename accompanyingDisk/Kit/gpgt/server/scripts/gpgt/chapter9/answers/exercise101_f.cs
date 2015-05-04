//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
datablock PlayerData( boxSearchMan : BlueGuy ) 
{
   category = "gpgt";
};

package exercisePackage_101
{
   
function AIPlayer::containerSearchTest( %theBot )
{
// EXERCISE BEGINS HERE        
   %curObject = containerFindFirst( $TypeMasks::StaticShapeObjectType , %theBot.getWorldBoxCenter() , 5 , 5 , 5  );
   
   while( isObject( %curObject ) )
   {
      %curObject.setSkinName( "yellow" );
      %curObject.schedule( 250 , setSkinName , "red" );
      
      %curObject = containerFindNext();
   }
// EXERCISE ENDS HERE        
   %theBot.schedule( 250 , containerSearchTest );
}      

function startexercise101()
{     
   for(%count = 4; %count < 24; %count+=2)
   {
      exerciseCenter.createSimplePath( "loop" @ %count , %count );
   }

   exerciseCenter.createSimplePath( "testPath" , 24.0 );
   %theBot = AIPlayer::spawn( exerciseCenter.getTransform() , boxSearchMan );
   %theBot.assignPath( testPath );
   %theBot.currentPathNodeNum = getRandom( 0 , 7 );
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , true );
   %pathNode.visibleMarker.setSkinName("green");
   
	%theBot.schedule( 3000 , containerSearchTest );

}
function boxSearchMan::onReachDestination( %DB , %theBot )
{
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %pathNode.visibleMarker.setSkinName("red");
   %theBot.currentPathNodeNum = getRandom( 0 , 7 );
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , true );
   %pathNode.visibleMarker.setSkinName("green");   
}
};