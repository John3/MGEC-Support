//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
datablock AudioDescription(HOW2D)
{
   volume      = 1.0;
   isLooping   = false;
   is3D        = false;
   type        = $SimAudioType;
};

datablock AudioDescription(HOW3D)
{
   volume            = 1.0;
   isLooping         = false;
   is3D              = true;
   ReferenceDistance = 5.0;
   MaxDistance       = 90.0;
   type              = $SimAudioType;
};

datablock AudioProfile(TestSound2D)
{
filename       = "~/data/sound/explosion_mono_01.ogg";
description    = HOW2D;
preload        = true;
};

datablock AudioProfile(TestSound3D)
{
filename       = "~/data/sound/explosion_mono_01.ogg";
description    = HOW3D;
preload        = true;
};


package exercisePackage_004
{

function startexercise004()
{  
}

function play2DSound()
{
   localClientConnection.play2D( TestSound2D );
}

function play3DSoundNearPlayer()
{
   %player   = localClientConnection.player;
   %transform = %player.getTransform();

   echo(%transform);

   localClientConnection.play3D( TestSound3D , %transform );
}


function play3DSoundInFrontOfPlayer()
{
   %player   = localClientConnection.player;
   %transform = %player.getTransform();
  
   %newTransform = vectorAdd( %transform , "0 35 0" );
   %newTransform = %newTransform SPC getWords( %transform , 3 , 6 );
   
   echo(%newTransform);

   localClientConnection.play3D( TestSound3D , %newTransform );
}

};

