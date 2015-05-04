//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
 
 function loadGPGTexercises()
 {  
    
   exec("./exerciseStarter.cs");
   
   exec("./common/Markers/FlashingMarker.cs");
   exec("./common/BlueGuy/player.cs");
   exec("./common/AI/PathUtils.cs");
   exec("./common/AI/AIPlayer.cs");
   exec("./common/AI/AIWheeledVehicle.cs");
   exec("./common/Blocks/blocks.cs");
   exec("./common/Eggs/eggs.cs");

   
   if( "" !$= $GPGT::exerciseSet ) //EFM will NOT work in MP scenario
   {
      echo("Loading " @ $GPGT::exerciseSet @ " datablocks and scripts...");
      exec("./" @ $GPGT::exerciseSet @ "/loader.cs");
   }
 }