//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------

// 1 - Select proper class type.
datablock PlayerData( pointToPointGuy : BlueGuy ) 
{
   category = "gpgt";
};

package exercisePackage_002
{

// 1 - Create an AIPlayer
// 2 - Calculate and store two points to navigate to.
function startexercise002()
{  
   // 1
   %theBot = AIPlayer::spawn( exerciseCenter.getTransform() , pointToPointGuy );
   
   // 2
   %theBot.point0 = vectorAdd( %theBot.getPosition() , "-10 0 0" );
   %theBot.point1 = vectorAdd( %theBot.getPosition() , "10 0 0" );

   %theBot.currentPoint = 0;
   
   %theBot.schedule( 1000 , moveToPoint );
}


// 1 - Set a new move destination.
function AIPlayer::moveToPoint( %this )
{
   // 1
   %this.setMoveDestination( %this.point[%this.currentPoint] , false );
   
   %this.currentPoint = !%this.currentPoint;
   %this.schedule( 1000 , moveToPoint );   
}
};