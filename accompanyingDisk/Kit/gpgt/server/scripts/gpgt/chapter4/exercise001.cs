//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
package exercisePackage_001
{

function startexercise001()
{  
   initClientQuerySettings();
}

function initClientQuerySettings()
{
//   $Client::LanPortQuery     = 
//   $Client::FlagsQuery       = 
//   $Client::GameTypeQuery    = 
//   $Client::MissionTypeQuery = 
//   $Client::MinPlayersQuery  = 
//   $Client::MaxPlayersQuery  = 
//   $Client::MaxBotsQuery     = 
//   $Client::RegionMaskQuery  = 
//   $Client::MaxPingQuery     = 
//   $Client::MinCPUQuery      = 
//   $Client::FilterFlagsQuery = 
}

function dumpClientQuerySettings()
{
   echo("$Client::LanPortQuery     == ", $Client::LanPortQuery);
// ... add remainder
}

function dumpServerSettings()
{
   echo("$Server::Status             == ", $Server::Status );
// ... add remainder

}

function doLanServersQuery()
{
}

function doStartHeartbeat()
{
}

function doStopHeartbeat()
{
}

function dumpMasterServersList()
{
}

function doMasterServersQuery()
{
}

function onServerInfoQuery()
{
}

function dumpServerInfoData()
{
   // Find out how many servers were found.
   %count = 0 /*add correct function here */;
   
   echo("Found ", %count , " servers." );
   
   // Print out all of the server data we discovered   
   for (%i = 0; %i < %count; %i++) {
      echo("Server # ", %i );
      
      echo("$ServerInfo::Status       == ", $ServerInfo::Status );
      // ... add remainder      
   }
}

};

