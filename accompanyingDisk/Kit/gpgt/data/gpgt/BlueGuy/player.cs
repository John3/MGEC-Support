//------------------------------------------------------
// Copyright (c) 2000-2005, GarageGames.com, Inc.
//------------------------------------------------------

// Caution: You may find that placing this file too deeply in your hiearchy will cause
// the game to crash/fail when transmitting datablocks.  The reason for this is
// that the total size of this datablock will exceed 1024 bytes which is the default
// limit for a single packet.  
//
// Solutions:
// 1. Move lower in hierarchy
// 2. Increase packet size.
// 3. Modify packet code to split this into two or more packets.
//


datablock TSShapeConstructor(PlayerDts)
{
   baseShape = "./player.dts";
   sequence0 = "./player_root.dsq root";
   sequence1 = "./player_forward.dsq run";
   sequence2 = "./player_back.dsq back";
   sequence3 = "./player_side.dsq side";
   sequence4 = "./player_lookde.dsq look";
   sequence5 = "./player_head.dsq head";
   sequence6 = "./player_fall.dsq fall";
   sequence7 = "./player_land.dsq land";
   sequence8 = "./player_jump.dsq jump";
   sequence9  = "./player_diehead.dsq death1";
   sequence10 = "./player_looksn.dsq looksn";
   sequence11 = "./player_lookms.dsq lookms";
   sequence12 = "./player_headside.dsq headside";
   sequence13 = "./player_standjump.dsq standjump";
   sequence14 = "./player_looknw.dsq looknw";
};         
