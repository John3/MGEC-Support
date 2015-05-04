//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
package exercisePackage_001
{

function startexercise001()
{  
   initClientQuerySettings();
}

//
// Note:  The majority of these variables are made up, purely for this example.
// However, two of them are in fact defined in the standard FPS Starter Kit.
// I have annotated these two variables below.
//
function initClientQuerySettings()
{
   $Client::LanPortQuery     = 28000;
   $Client::FlagsQuery       = 0;
   $Client::GameTypeQuery    = "FPS Starter Kit"; // found in ~/client/init.cs -> initClient()
   $Client::MissionTypeQuery = "ANY"; // found in ~/client/init.cs -> initClient()
   $Client::MinPlayersQuery  = 0;
   $Client::MaxPlayersQuery  = 100;
   $Client::MaxBotsQuery     = 0;
   $Client::RegionMaskQuery  = 2;
   $Client::MaxPingQuery     = 0;
   $Client::MinCPUQuery      = 100;
   $Client::FilterFlagsQuery = 0;
}

function dumpClientQuerySettings()
{
   echo("$Client::LanPortQuery     == ", $Client::LanPortQuery);
   echo("$Client::FlagsQuery       == ", $Client::FlagsQuery);
   echo("$Client::GameTypeQuery    == ", $Client::GameTypeQuery);
   echo("$Client::MissionTypeQuery == ", $Client::MissionTypeQuery);
   echo("$Client::MinPlayersQuery  == ", $Client::MinPlayersQuery);
   echo("$Client::MaxPlayersQuery  == ", $Client::MaxPlayersQuery);
   echo("$Client::MaxBotsQuery     == ", $Client::MaxBotsQuery);
   echo("$Client::RegionMaskQuery  == ", $Client::RegionMaskQuery);
   echo("$Client::MaxPingQuery     == ", $Client::MaxPingQuery);
   echo("$Client::MinCPUQuery      == ", $Client::MinCPUQuery);
   echo("$Client::FilterFlagsQuery == ", $Client::FilterFlagsQuery);
}

function dumpServerSettings()
{
   echo("$Server::Status             == ", $Server::Status );
   echo("$Pref::Server::Name         == ", $Pref::Server::Name );
   echo("$Server::GameType           == ", $Server::GameType );
   echo("$Server::MissionName        == ", $Server::MissionName );
   echo("$Server::MissionType        == ", $Server::MissionType );
   echo("$Pref::Server::Info         == ", $Pref::Server::Info );
   echo("$Pref::Server::MaxPlayers   == ", $Pref::Server::MaxPlayers );
   echo("$Server::Dedicated          == ", $Server::Dedicated );
   echo("$Pref::Server::Password     == ", $Pref::Server::Password );   
   echo("$Pref::Net::DisplayOnMaster == ", $Pref::Net::DisplayOnMaster );      
}

function doLanServersQuery()
{
   queryLANServers(
      $Client::LanPortQuery,       // lanPort for local queries
      $Client::FlagsQuery,         // Query flags
      $Client::GameTypeQuery,      // gameTypes
      $Client::MissionTypeQuery,   // missionType
      $Client::MinPlayersQuery,    // minPlayers
      $Client::MaxPlayersQuery,    // maxPlayers
      $Client::MaxBotsQuery,       // maxBots
      $Client::RegionMaskQuery,    // regionMask
      $Client::MaxPingQuery,       // maxPing
      $Client::MinCPUQuery,        // minCPU
      $Client::FilterFlagsQuery    // filterFlags
      );
}

function doStartHeartbeat()
{
   startHeartbeat();
}

function doStopHeartbeat()
{
   stopHeartbeat();
}

function dumpMasterServersList()
{
   for( %count = 0; %count < 5; %count++ )
   {
      echo("$pref::Master[", %count, "] == ", $pref::Master[%count]);
   }
}

function doMasterServersQuery()
{
   queryMasterServer(
      $Client::FlagsQuery,         // Query flags
      $Client::GameTypeQuery,      // gameTypes
      $Client::MissionTypeQuery,   // missionType
      $Client::MinPlayersQuery,    // minPlayers
      $Client::MaxPlayersQuery,    // maxPlayers
      $Client::MaxBotsQuery,       // maxBots
      $Client::RegionMaskQuery,    // regionMask
      $Client::MaxPingQuery,       // maxPing
      $Client::MinCPUQuery,        // minCPU
      $Client::FilterFlagsQuery    // filterFlags
      );
}

function onServerInfoQuery()
{
   return $ServerInfo::Status;
}

function dumpServerInfoData()
{
   // Find out how many servers were found.
   %count = getServerCount();
   
   echo("Found ", %count , " servers." );
   
   // Print out all of the server data we discovered   
   for (%i = 0; %i < %count; %i++) {
      echo("Server # ", %i );

      echo("$ServerInfo::Status       == ", $ServerInfo::Status );
      echo("$ServerInfo::Address      == ", $ServerInfo::Address );
      echo("$ServerInfo::Name         == ", $ServerInfo::Name );
      echo("$ServerInfo::GameType     == ", $ServerInfo::GameType );
      echo("$ServerInfo::MissionName  == ", $ServerInfo::MissionName );
      echo("$ServerInfo::MissionType  == ", $ServerInfo::MissionType );

      // BEGIN BONUS 
      // Build a state string from the state bitmask
      // Status_Linux      = BIT(2),
      // Status_New        = 0, 
      // Status_Querying   = BIT(28)
      // Status_Updating   = BIT(29)
      // Status_Responded  = BIT(30)
      // Status_TimedOut   = BIT(31)         
      if( 0 == $ServerInfo::State )
      {
         %state = "NEW";
      }
      else
      {
         %state = " ";
         
         if( (1 << 2)  & $ServerInfo::State) %state = %state SPC "Linux; ";
         if( (1 << 28) & $ServerInfo::State) %state = %state SPC "Querying; ";
         if( (1 << 29) & $ServerInfo::State) %state = %state SPC "Updating; ";
         if( (1 << 30) & $ServerInfo::State) %state = %state SPC "Responded; ";
         if( (1 << 31) & $ServerInfo::State) %state = %state SPC "Timed Out; ";
      }
      // END BONUS 
      
      echo("$ServerInfo::State        == ", $ServerInfo::State SPC %state);

      echo("$ServerInfo::Info         == ", $ServerInfo::Info );
      echo("$ServerInfo::PlayerCount  == ", $ServerInfo::PlayerCount );
      echo("$ServerInfo::MaxPlayers   == ", $ServerInfo::MaxPlayers );
      echo("$ServerInfo::BotCount     == ", $ServerInfo::BotCount );
      echo("$ServerInfo::Version      == ", $ServerInfo::Version );
      echo("$ServerInfo::Ping         == ", $ServerInfo::Ping );
      echo("$ServerInfo::CPUSpeed     == ", $ServerInfo::CPUSpeed );
      echo("$ServerInfo::Favorite     == ", $ServerInfo::Favorite );
      echo("$ServerInfo::Dedicated    == ", $ServerInfo::Dedicated );
      echo("$ServerInfo::Password     == ", $ServerInfo::Password );
   }
}
};

