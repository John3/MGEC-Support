//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
echo("\n--------- Loading GameBase Utilities ---------");
function isGameBase( %obj ) {
	return ( %obj.getType() == $TypeMasks::GameBaseObjectType );
}
