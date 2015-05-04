//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------

// Load dts shapes and merge animations
exec("~/data/gpgt/BlueGuy/player.cs");

//-------------------------------------------------------------------------
//                        Blue Guy - Inherits from standard Orc  
//-------------------------------------------------------------------------
datablock PlayerData( BlueGuy : PlayerBody )
{
	shapeFile            = "~/data/gpgt/BlueGuy/player.dts";
	category             = "gpgt";
};

