//-----------------------------------------------------------------------------
// Torque Game Engine 
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Invoked from the common server & mission loading functions
//-----------------------------------------------------------------------------

function onServerCreated()
{
   if($GPGT::MPDebug) echo("\c5 ====> LOAD-SERVER /common/server/game.cs ->:" SPC "onServerCreated()");
   
   // Invoked by createServer(), when server is created and ready to go

   // Server::GameType is sent to the master server.
   // This variable should uniquely identify your game and/or mod.
   $Server::GameType = "GPGT Volume 2 exercise Kit";

   // Server::MissionType sent to the master server.  Clients can
   // filter servers based on mission type.
   $Server::MissionType = "Exercise";

   // Load up all datablocks, objects etc.  This function is called when
   // a server is constructed.
   // exec("./foo.cs");

   // For backwards compatibility...
   createGame();
}

function onServerDestroyed()
{
   if($GPGT::MPDebug) echo("\c9 ====> PURGE /common/server/game.cs ->:" SPC "onServerDestroyed()");
   
   // Invoked by destroyServer(), right before the server is destroyed
   destroyGame();
}

function onMissionLoaded()
{
   if($GPGT::MPDebug) echo("\c9 ====> GAME /common/server/game.cs ->:" SPC "onMissionLoaded()");
   
   // Called by loadMission() once the mission is finished loading
   startGame();
}

function onMissionEnded()
{
   if($GPGT::MPDebug) echo("\c9 ====> GAME /common/server/game.cs ->:" SPC "onMissionEnded()");
   
   // Called by endMission(), right before the mission is destroyed
   endGame();
}

function onMissionReset()
{
   if($GPGT::MPDebug) echo("\c9 ====> GAME /common/server/game.cs ->:" SPC "onMissionReset()");
   
   // Called by resetMission(), after all the temporary mission objects
   // have been deleted.
}


//-----------------------------------------------------------------------------
// These methods are extensions to the GameConnection class. Extending
// GameConnection make is easier to deal with some of this functionality,
// but these could also be implemented as stand-alone functions.
//-----------------------------------------------------------------------------

function GameConnection::onClientEnterGame(%this)
{
   if($GPGT::MPDebug) echo("\c8 ====> GAME /common/server/game.cs ->:" SPC "GameConnection::onClientEnterGame(" SPC %this SPC ")");
   
   // Called for each client after it's finished downloading the
   // mission and is ready to start playing.
   // Tg: Should think about renaming this onClientEnterMission
}

function GameConnection::onClientLeaveGame(%this)
{
   if($GPGT::MPDebug) echo("\c8 ====> GAME /common/server/game.cs ->:" SPC "GameConnection::onClientLeaveGame(" SPC %this SPC ")");
   
   // Call for each client that drops
   // Tg: Should think about renaming this onClientLeaveMission
}


//-----------------------------------------------------------------------------
// Functions that implement game-play
// These are here for backwards compatibilty only, games and/or mods should
// really be overloading the server and mission functions listed above.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------

function createGame()
{
   if($GPGT::MPDebug) echo("\c8 ====> GAME /common/server/game.cs ->:" SPC "createGame()");
   
   // This function is called by onServerCreated (above)
}

function destroyGame()
{
   if($GPGT::MPDebug) echo("\c8 ====> GAME /common/server/game.cs ->:" SPC "destroyGame()");
   
   // This function is called by onServerDestroyed (above)
}


//-----------------------------------------------------------------------------

function startGame()
{
   if($GPGT::MPDebug) echo("\c8 ====> GAME /common/server/game.cs ->:" SPC "startGame()");
   
   // This is where the game play should start
   // The default onMissionLoaded function starts the game.
}

function endGame()
{
   if($GPGT::MPDebug) echo("\c8 ====> GAME /common/server/game.cs ->:" SPC "endGame()");
   
   // This is where the game play should end
   // The default onMissionEnded function shuts down the game.
}



