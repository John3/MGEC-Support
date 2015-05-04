//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
package exercisePackage_001
{


function startexercise001()
{  
   exerciseCenter.createSimplePath( "testPath" , 20 );
   
   %fromMarker = testPath.getVisibleMarkerID( 0 );
   %fromMarker.setSkinName( "green" );
   
 	%hitBox = new StaticShape() {  
		dataBlock = "litBlockC";
		position  = CalculateObjectDropPosition( vectorAdd("0 0 50", exerciseCenter.getPosition() ) , "0 0 -1");
		scale     = "1 1 1";
	};
	
	MissionGroup.add(%hitbox);
	
   %marker = testPath.getVisibleMarkerID( 0 );
   %marker.setSkinName( "green" );	
	for(%count=1;%count<8;%count++)
	{
      %marker = testPath.getVisibleMarkerID( %count );
      %marker.setSkinName( "base" );	
	}
	
	%hitBox.setSkinName( "red" );
   MissionGroup.schedule( 5000 , rayCastTest , 1 , %hitBox , %fromMarker , "" );
}

function SimGroup::rayCastTest( %theGroup , %markerNum , %hitBox , %fromMarker , %toMarker )
{
   if( isObject( %toMarker ) )  %toMarker.setSkinName( "base" );
   %markerNum = ( %markerNum >= testPath.getCount() ) ? 1 : %markerNum;
   %toMarker = testPath.getVisibleMarkerID( %markerNum );
   %toMarker.setSkinName( "red" );


   // EXERCISE BEGINS HERE     

   //%startPos =  %fromMarker.?????
   //%endPos   =  %toMarker.?????
   //%hitObject = ?????
   
   // EXERCISE ENDS HERE     


   if( isObject( %hitObject ) && %hitObject == %hitBox )
      %hitBox.setSkinName( "green" );
   else
      %hitBox.setSkinName( "red" );
   %theGroup.schedule( 1000 , rayCastTest , %markerNum++ , %hitBox , %fromMarker, %toMarker );
}

};

