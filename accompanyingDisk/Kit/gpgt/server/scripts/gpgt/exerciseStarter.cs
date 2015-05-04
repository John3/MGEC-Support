//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------

// onAdd() callback for exercise starter script object.
// To use this mechanism do the following:
// 
// 1. Create a script object named "exerciseStarter".
//    Type this on command line => new scriptObject(exerciseStarter);
//
// 2. Add this object to the mission's MissionGroup 
//    Type this on command line => MissionGroup.add(exerciseStarter);
//
// 3. Create a dynamic field in "exerciseStarter" named exerciseName by assinging
//    a unique exercise name to it (no spaces).
//    Type this on command line => exerciseStarter.exerciseName = "exercise100";
//
// 4. Save the mission.
//
// 5. Add a new case statement in the onAdd() callback below to handle the exercise name.
//

function exerciseStarter::onAdd( %this )
{   
   echo("exerciseStarter::onAdd() => ", %this.exerciseName SPC %this.packageName );

   activatePackage( "exercisePackage_" @ %this.packageName );
   
   schedule( 5000 , exerciseStarter , eval , "start" @ %this.exerciseName @ "();" );
}

function exerciseStarter::onRemove( %this )
{   
   deActivatePackage( "exercisePackage_" @ %this.packageName );
}

function loadExercise( %fileName )
{
   %finishedfile = strReplace( %fileName , ".cs" , "_f.cs" );
   
   if( isFile(%finishedfile) )
      exec(%finishedfile);
   else
      exec(%fileName);
}