//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------

function getAllDatablocksByClassName( %className )
{
   %tmpSet = new simset();
   %stmt = "if(tok.getClassName() $= " @ %className @ ") " @ %tmpSet.getID() @ ".add(tok);";
   
   datablockGroup.foreachStmt( %stmt , tok , false );
   
   return %tmpSet;
}

function findFirstInstanceByClassName( %className )
{
   %tmpSet = new simset();

   //EFM doesn't find all objects. this is not good!   
   findAllByClassName( %tmpSet , rootGroup, %className );
   findAllByClassName( %tmpSet , missionGroup, %className );
   findAllByClassName( %tmpSet , missionCleanup, %className );

   %firstObject = %tmpSet.getObject(0);

   %tmpSet.delete();

   return %firstObject;
}


function findAllByClassName(  %set, %searchSet , %className )
{  
   %numEntries = %searchSet.getCount();
   
   for( %count = 0 ; %count < %numEntries ; %count++ )
   {
      %curClassName = %searchSet.getObject(%count).getClassName();
      
      if( %curClassName $= %className ) %set.add( %searchSet.getObject( %count ) );
      else if( %curClassName $= "SimGroup" ) findAllByClassName( %set, %searchSet.getObject( %count ) , %className );
      else if( %curClassName $= "ScriptGroup" ) findAllByClassName( %set, %searchSet.getObject( %count ) , %className );      
      else if( %curClassName $= "SimSet" ) findAllByClassName( %set, %searchSet.getObject( %count ) , %className );
      else if( %curClassName $= "ScriptSet" ) findAllByClassName( %set, %searchSet.getObject( %count ) , %className );
   }
}

