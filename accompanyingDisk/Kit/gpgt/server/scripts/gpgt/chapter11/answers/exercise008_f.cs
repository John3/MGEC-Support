//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------

package exercisePackage_008
{

function startexercise008()
{  
   // 1
   new mySecondSceneObject( testMySceneObject )
   {
      position  = exerciseCenter.getPosition();
      scale     = "1 1 1";    
   };
   
   MissionGroup.add( testMySceneObject );
}


};

