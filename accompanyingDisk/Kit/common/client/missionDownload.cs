//-----------------------------------------------------------------------------
// Torque Game Engine 
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//----------------------------------------------------------------------------
// Mission Loading
// Server download handshaking.  This produces a number of onPhaseX
// calls so the game scripts can update the game's GUI.
//
// Loading Phases:
// Phase 1: Download Datablocks
// Phase 2: Download Ghost Objects
// Phase 3: Scene Lighting
//----------------------------------------------------------------------------

//----------------------------------------------------------------------------
// Phase 1 
//----------------------------------------------------------------------------

function clientCmdMissionStartPhase1(%seq, %missionName, %musicTrack)
{
   if($GPGT::MPDebug) echo("\c7 ====> LOAD-CLIENT /common/client/missionDownloads.cs ->:" SPC "clientCmdMissionStartPhase1(" SPC %seq SPC "," SPC %missionName SPC "," SPC %musicTrack SPC ")" );
   
   // These need to come after the cls.
   echo ("*** New Mission: " @ %missionName);
   echo ("*** Phase 1: Download Datablocks & Targets");
   onMissionDownloadPhase1(%missionName, %musicTrack);
   commandToServer('MissionStartPhase1Ack', %seq);
}

function onDataBlockObjectReceived(%index, %total)
{
   if($GPGT::MPDebug) echo("\c7 ====> LOAD-CLIENT /common/client/missionDownloads.cs ->:" SPC "onDataBlockObjectReceived(" SPC %index SPC "," SPC %total SPC ")" );
   
   onPhase1Progress(%index / %total);
}

//----------------------------------------------------------------------------
// Phase 2
//----------------------------------------------------------------------------

function clientCmdMissionStartPhase2(%seq,%missionName)
{
   if($GPGT::MPDebug) echo("\c7 ====> LOAD-CLIENT /common/client/missionDownloads.cs ->:" SPC "clientCmdMissionStartPhase2(" SPC %seq SPC "," SPC %missionName SPC ")" );
   
   onPhase1Complete();
   echo ("*** Phase 2: Download Ghost Objects");
   purgeResources();
   onMissionDownloadPhase2(%missionName);
   commandToServer('MissionStartPhase2Ack', %seq);
}

function onGhostAlwaysStarted(%ghostCount)
{
   if($GPGT::MPDebug) echo("\c7 ====> LOAD-CLIENT /common/client/missionDownloads.cs ->:" SPC "onGhostAlwaysStarted(" SPC %ghostCount SPC ")" );
   
   $ghostCount = %ghostCount;
   $ghostsRecvd = 0;
}

function onGhostAlwaysObjectReceived()
{
   if($GPGT::MPDebug) echo("\c7 ====> LOAD-CLIENT /common/client/missionDownloads.cs ->:" SPC "onGhostAlwaysObjectReceived()" );
   
   $ghostsRecvd++;
   onPhase2Progress($ghostsRecvd / $ghostCount);
}

//----------------------------------------------------------------------------
// Phase 3
//----------------------------------------------------------------------------

function clientCmdMissionStartPhase3(%seq,%missionName)
{
   if($GPGT::MPDebug) echo("\c7 ====> LOAD-CLIENT /common/client/missionDownloads.cs ->:" SPC "clientCmdMissionStartPhase3(" SPC %seq SPC "," SPC %missionName SPC ")" );
   
   onPhase2Complete();
   StartClientReplication();
   StartFoliageReplication();
   echo ("*** Phase 3: Mission Lighting");
   $MSeq = %seq;
   $Client::MissionFile = %missionName;

   // Need to light the mission before we are ready.
   // The sceneLightingComplete function will complete the handshake 
   // once the scene lighting is done.
   if (lightScene("sceneLightingComplete", ""))
   {
      error("Lighting mission....");
      schedule(1, 0, "updateLightingProgress");
      onMissionDownloadPhase3(%missionName);
      $lightingMission = true;
   }
}

function updateLightingProgress()
{
   if($GPGT::MPDebug) echo("\c7 ====> LOAD-CLIENT /common/client/missionDownloads.cs ->:" SPC "updateLightingProgress()" );
   
   onPhase3Progress($SceneLighting::lightingProgress);
   if ($lightingMission)
      $lightingProgressThread = schedule(1, 0, "updateLightingProgress");
}

function sceneLightingComplete()
{
   if($GPGT::MPDebug) echo("\c7 ====> LOAD-CLIENT /common/client/missionDownloads.cs ->:" SPC "sceneLightingComplete()" );
   
   echo("Mission lighting done");
   onPhase3Complete();
   
   // The is also the end of the mission load cycle.
   onMissionDownloadComplete();
   commandToServer('MissionStartPhase3Ack', $MSeq);
}

//----------------------------------------------------------------------------
// Helper functions
//----------------------------------------------------------------------------

function connect(%server)
{
   if($GPGT::MPDebug) echo("\c7 ====> LOAD-CLIENT /common/client/missionDownloads.cs ->:" SPC "connect(" SPC %server SPC ")" );
   
   %conn = new GameConnection();
   %conn.connect(%server);
}