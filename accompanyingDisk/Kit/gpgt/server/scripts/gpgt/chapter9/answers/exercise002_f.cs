//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
// EXERCISE BEGINS HERE     
$meshVariationsTestNum=0;

$meshVariationsDB[0]= "StaticShapeEgg";
$meshVariationsDB[1]= "StaticShapeEggCol";
$meshVariationsDB[2]= "StaticShapeEggLOS";
$meshVariationsDB[3]= "BlueGuy";
$meshVariationsDB[4]= "ItemEgg";
$meshVariationsDB[5]= "ItemEggCol";
$meshVariationsDB[6]= "ItemEggLOS";

// EXERCISE ENDS HERE     

package exercisePackage_002
{

function startexercise002()
{  
   exerciseCenter.createSimplePath( "testPath" , 20 );
   
   %fromMarker = testPath.getVisibleMarkerID( 0 );
   %fromMarker.setSkinName( "green" );

   if( $meshVariationsTestNum < 3 )
   {
 	   %hitBox = new StaticShape() {  
		   dataBlock = $meshVariationsDB[$meshVariationsTestNum];
		   position  = CalculateObjectDropPosition( vectorAdd("0 0 50", exerciseCenter.getPosition() ) , "0 0 -1");
		   scale     = "1 1 1";
	   };
   }
   else if( $meshVariationsTestNum == 3 )
   {
 	   %hitBox = new Player() {  
		   dataBlock = $meshVariationsDB[$meshVariationsTestNum];
		   position  = CalculateObjectDropPosition( vectorAdd("0 0 50", exerciseCenter.getPosition() ) , "0 0 5");
		   scale     = "1 1 1";
	   };
   }
   else
   {
 	   %hitBox = new Item() {  
		   dataBlock = $meshVariationsDB[$meshVariationsTestNum];
		   position  = CalculateObjectDropPosition( vectorAdd("0 0 50", exerciseCenter.getPosition() ) , "0 0 -1");
		   scale     = "1 1 1";
	   };
   }
   
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

   %startPos =  %fromMarker.getWorldBoxCenter();
   %endPos   =  %toMarker.getWorldBoxCenter();
   %hitObject = containerRayCast( %startPos , %endPos , -1 , %fromMarker );


   if( isObject( %hitObject ) && %hitObject == %hitBox )
      %hitBox.setSkinName( "green" );
   else
      %hitBox.setSkinName( "red" );
   %theGroup.schedule( 1000 , rayCastTest , %markerNum++ , %hitBox , %fromMarker, %toMarker );
}

};

