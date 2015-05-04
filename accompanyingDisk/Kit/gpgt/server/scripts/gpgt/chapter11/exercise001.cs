//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------

datablock myGameBaseData( renderBoth )
{
   category    = "Misc";
   drawPyramid = true;
   drawCube    = true;
};

datablock myGameBaseData( pyramidOnly )
{
   category    = "Misc";
   drawPyramid = true;
   drawCube    = false;
};

datablock myGameBaseData( cubeOnly )
{
   category    = "Misc";
   drawPyramid = false;
   drawCube    = true;
};

package exercisePackage_001
{

function startexercise001()
{  
   // 1
   new myGameBase( testMyGameBase )
   {
      position  = exerciseCenter.getPosition();
      dataBlock = "renderBoth";  
      scale     = "1 1 1";    
   };
   
   MissionGroup.add( testMyGameBase );
}

function myGameBaseData::create(%data)
{
   %obj = new myGameBase() 
   {
      dataBlock = %data;
   };
   return %obj;
}

};

