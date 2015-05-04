//-----------------------------------------------------------------------------
// Torque Game Engine 
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//----------------------------------------------------------------------------
// Mission Loading & Mission Info
// The mission loading server handshaking is handled by the
// common/client/missingLoading.cs.  This portion handles the interface
// with the game GUI.
//----------------------------------------------------------------------------

//----------------------------------------------------------------------------
// Loading Phases:
// Phase 1: Download Datablocks
// Phase 2: Download Ghost Objects
// Phase 3: Scene Lighting

//----------------------------------------------------------------------------
// Phase 1
//----------------------------------------------------------------------------

function onMissionDownloadPhase1(%missionName, %musicTrack)
{
   if($GPGT::MPDebug) echo("\c7 ====> LOAD-CLIENT /gpgt/client/scripts/missionDownloads.cs ->:" SPC "onMissionDownloadPhase1(" SPC %missionName SPC "," SPC %musicTrack SPC ")" );
   
   // Close and clear the message hud (in case it's open)
   MessageHud.close();
   //cls();

   // Reset the loading progress controls:
   LoadingProgress.setValue(0);
   LoadingProgressTxt.setValue("LOADING DATABLOCKS");
}

function onPhase1Progress(%progress)
{
   if($GPGT::MPDebug) echo("\c7 ====> LOAD-CLIENT /gpgt/client/scripts/missionDownloads.cs ->:" SPC "onPhase1Progress(" SPC %progress SPC ")" );
   
   LoadingProgress.setValue(%progress);
   Canvas.repaint();
}

function onPhase1Complete()
{
}

//----------------------------------------------------------------------------
// Phase 2
//----------------------------------------------------------------------------

function onMissionDownloadPhase2()
{
   if($GPGT::MPDebug) echo("\c7 ====> LOAD-CLIENT /gpgt/client/scripts/missionDownloads.cs ->:" SPC "onMissionDownloadPhase2()");
   
   // Reset the loading progress controls:
   LoadingProgress.setValue(0);
   LoadingProgressTxt.setValue("LOADING OBJECTS");
   Canvas.repaint();
}

function onPhase2Progress(%progress)
{
   if($GPGT::MPDebug) echo("\c7 ====> LOAD-CLIENT /gpgt/client/scripts/missionDownloads.cs ->:" SPC "onPhase2Progress(" SPC %progress SPC ")" );
   
   LoadingProgress.setValue(%progress);
   Canvas.repaint();
}

function onPhase2Complete()
{
   if($GPGT::MPDebug) echo("\c7 ====> LOAD-CLIENT /gpgt/client/scripts/missionDownloads.cs ->:" SPC "onPhase2Complete()");
   
}   

function onFileChunkReceived(%fileName, %ofs, %size)
{
   if($GPGT::MPDebug) echo("\c7 ====> LOAD-CLIENT /gpgt/client/scripts/missionDownloads.cs ->:" SPC "onFileChunkReceived(" SPC %fileName SPC "," SPC %ofs SPC "," SPC %size SPC ")" );
   
   LoadingProgress.setValue(%ofs / %size);
   LoadingProgressTxt.setValue("Downloading " @ %fileName @ "...");
}

//----------------------------------------------------------------------------
// Phase 3
//----------------------------------------------------------------------------

function onMissionDownloadPhase3()
{
   if($GPGT::MPDebug) echo("\c7 ====> LOAD-CLIENT /gpgt/client/scripts/missionDownloads.cs ->:" SPC "onMissionDownloadPhase3()");
   
   LoadingProgress.setValue(0);
   LoadingProgressTxt.setValue("LIGHTING MISSION");
   Canvas.repaint();
}

function onPhase3Progress(%progress)
{
   if($GPGT::MPDebug) echo("\c7 ====> LOAD-CLIENT /gpgt/client/scripts/missionDownloads.cs ->:" SPC "onPhase3Progress(" SPC %progress SPC ")" );
   
   LoadingProgress.setValue(%progress);
}

function onPhase3Complete()
{
   if($GPGT::MPDebug) echo("\c7 ====> LOAD-CLIENT /gpgt/client/scripts/missionDownloads.cs ->:" SPC "onPhase3Complete()");
   
   LoadingProgress.setValue( 1 );
   $lightingMission = false;
}

//----------------------------------------------------------------------------
// Mission loading done!
//----------------------------------------------------------------------------

function onMissionDownloadComplete()
{
   if($GPGT::MPDebug) echo("\c7 ====> LOAD-CLIENT /gpgt/client/scripts/missionDownloads.cs ->:" SPC "onMissionDownloadComplete()");
   
   // Client will shortly be dropped into the game, so this is
   // good place for any last minute gui cleanup.
}


//------------------------------------------------------------------------------
// Before downloading a mission, the server transmits the mission
// information through these messages.
//------------------------------------------------------------------------------

addMessageCallback( 'MsgLoadInfo', handleLoadInfoMessage );
addMessageCallback( 'MsgLoadDescripition', handleLoadDescriptionMessage );
addMessageCallback( 'MsgLoadInfoDone', handleLoadInfoDoneMessage );

//------------------------------------------------------------------------------

function handleLoadInfoMessage( %msgType, %msgString, %mapName ) {
	
	// Need to pop up the loading gui to display this stuff.
	Canvas.setContent("LoadingGui");

	// Clear all of the loading info lines:
	for( %line = 0; %line < LoadingGui.qLineCount; %line++ )
		LoadingGui.qLine[%line] = "";
	LoadingGui.qLineCount = 0;

   //
	LOAD_MapName.setText( %mapName );
}

//------------------------------------------------------------------------------

function handleLoadDescriptionMessage( %msgType, %msgString, %line )
{
	LoadingGui.qLine[LoadingGui.qLineCount] = %line;
	LoadingGui.qLineCount++;

   // Gather up all the previous lines, append the current one
   // and stuff it into the control
	%text = "<spush><font:Arial:16>";
	
	for( %line = 0; %line < LoadingGui.qLineCount - 1; %line++ )
		%text = %text @ LoadingGui.qLine[%line] @ " ";
   %text = %text @ LoadingGui.qLine[%line] @ "<spop>";

	LOAD_MapDescription.setText( %text );
}

//------------------------------------------------------------------------------

function handleLoadInfoDoneMessage( %msgType, %msgString )
{
   // This will get called after the last description line is sent.
}
