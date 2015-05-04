//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
package exercisePackage_103
{


function startexercise103()
{  
   exerciseCenter.createSimplePath( "testPath" , 20 );
   
	for(%count=0;%count<8;%count++)
	{
      %marker = testPath.getVisibleMarkerID( %count );
      %marker.setSkinName( "base" );	
	}
   

   for(%count = 0; %count < testPath.getCount(); %count++)
   {
   
      %marker = testPath.getVisibleMarkerID( %count );
   
 	   %dummy = new Player() 
 	   {  
   		dataBlock = "BlueGuy";
		   position  = CalculateObjectDropPosition( vectorAdd("0" SPC %count SPC "50", %marker.getPosition() ) );
		   scale     = "1 1 1";
	   };
	
	   MissionGroup.add( %dummy );
   }   
   
   MissionGroup.schedule( 1000 , containerBoxEmptyTest , 1 );

}

function SimGroup::containerBoxEmptyTest( %theGroup ,  %markerNum )
{
   if( %markerNum >= testPath.getCount() )
   {
      %markerNum = 0;
   }
   %currentMarker = testPath.getVisibleMarkerID( %markerNum );
   
   // Show Box Points
   new SimGroup( tmpGroup );
   %x = getWord( %currentMarker.getPosition() , 0 );
   %y = getWord( %currentMarker.getPosition() , 1 );
   %z = getWord( %currentMarker.getPosition() , 2 );
   // Corner 0
  	%marker = new StaticShape() 
  	{  
		dataBlock = "FlashingMarker";
		position  = %x+5 SPC %y+5 SPC %z+1;
		scale     = "4 4 4";
	};
	tmpGroup.add(%marker);
   // Corner 1
  	%marker = new StaticShape() 
  	{  
		dataBlock = "FlashingMarker";
		position  = %x-5 SPC %y+5 SPC %z+1;
		scale     = "4 4 4";
	};
	tmpGroup.add(%marker);
   // Corner 2
  	%marker = new StaticShape() 
  	{  
		dataBlock = "FlashingMarker";
		position  = %x+5 SPC %y-5 SPC %z+1;
		scale     = "4 4 4";
	};
	tmpGroup.add(%marker);
   // Corner 3
  	%marker = new StaticShape() 
  	{  
		dataBlock = "FlashingMarker";
		position  = %x-5 SPC %y-5 SPC %z+1;
		scale     = "4 4 4";
	};
	tmpGroup.add(%marker);
   tmpGroup.schedule( 2000 , delete );



// EXERCISE BEGINS HERE        

   //%isEmpty = ?????
   
// EXERCISE ENDS HERE     


   

   if( %isEmpty )
       %currentMarker.setSkinName("green");
   else
       %currentMarker.setSkinName("red");

   
   %currentMarker.schedule( 2000 , setSkinName , "base" );
   %theGroup.schedule( 2000 , containerBoxEmptyTest ,  %markerNum++  );
}

};

