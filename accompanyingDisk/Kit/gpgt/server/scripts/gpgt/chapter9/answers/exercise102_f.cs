//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
datablock PlayerData( sphereSearchMan : BlueGuy ) 
{
   category = "gpgt";
};

package exercisePackage_102
{
   
function AIPlayer::containerSearchTest( %theBot )
{
// EXERCISE BEGINS HERE        
   initContainerRadiusSearch( %theBot.getWorldBoxCenter() , 10 , $TypeMasks::StaticShapeObjectType );
   
   while( isObject( %curObject = containerSearchNext() ) )
   {
      %curObject.setSkinName( "yellow" );
      %curObject.schedule( 250 , setSkinName , "red" );
   }
// EXERCISE ENDS HERE        

   %theBot.schedule( 250 , containerSearchTest );
}

function startexercise102()
{     
   for(%count = 4; %count < 24; %count+=2)
   {
      exerciseCenter.createSimplePath( "loop" @ %count , %count );
   }

   exerciseCenter.createSimplePath( "testPath" , 24.0 );
   %theBot = AIPlayer::spawn( exerciseCenter.getTransform() , sphereSearchMan );
   %theBot.assignPath( testPath );
   %theBot.currentPathNodeNum = getRandom( 0 , 7 );
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , true );
   %pathNode.visibleMarker.setSkinName("green");
   
	%theBot.schedule( 3000 , containerSearchTest );

}
function sphereSearchMan::onReachDestination( %DB , %theBot )
{
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %pathNode.visibleMarker.setSkinName("red");
   %theBot.currentPathNodeNum = getRandom( 0 , 7 );
   %pathNode = %theBot.myPath.getObject( %theBot.currentPathNodeNum );
   %theBot.setMoveDestination( %pathNode.getTransform() , true );
   %pathNode.visibleMarker.setSkinName("green");   
}
};