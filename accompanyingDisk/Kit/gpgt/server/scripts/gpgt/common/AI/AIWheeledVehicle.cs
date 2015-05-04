//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------

function AIWheeledVehicle::spawn( %spawnTransform, %DBName )
{
	echo("\c5AIWheeledVehicle::spawn( "@ %DBName @ " , " @ %spawnTransform @ " )");

	%theBot = new AIWheeledVehicle() 
	{
		dataBlock = %DBName;
	};

	MissionGroup.add(%theBot);

	%theBot.setTransform(%spawnTransform);

	return %theBot;
}

function AIWheeledVehicle::assignPath( %AIWheeledVehicle, %path ) 
{
	echo("AIWheeledVehicle::assignPath( "@ %AIWheeledVehicle @ " , " @ %path @ " )");

	if (!isObject(%path)) return false;

	// Store the path in demo player
	%AIWheeledVehicle.myPath = %path;

	// Set first target Destination
	%AIWheeledVehicle.currentPathNode = 0;
	%AIWheeledVehicle.destination     = %path.getObject(%AIWheeledVehicle.currentPathNode).getTransform();

	return true;
}

