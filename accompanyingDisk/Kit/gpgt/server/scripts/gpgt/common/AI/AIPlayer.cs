//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------

function AIPlayer::spawn( %spawnTransform, %DBName )
{
	echo("\c5AIPlayer::spawn( "@ %DBName @ " , " @ %spawnTransform @ " )");

	%theBot = new AIPlayer() 
	{
		dataBlock = %DBName;
	};

	MissionGroup.add(%theBot);

	%theBot.setTransform(%spawnTransform);

	return %theBot;
}

function AIPlayer::assignPath( %aiPlayer, %path ) 
{
	echo("AIPlayer::assignPath( "@ %aiPlayer @ " , " @ %path @ " )");

	if (!isObject(%path)) return false;

	// Store the path in demo player
	%aiPlayer.myPath = %path;

	// Set first target Destination
	%aiPlayer.currentPathNode = 0;
	%aiPlayer.destination     = %path.getObject(%aiPlayer.currentPathNode).getTransform();

	return true;
}

