//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
echo("\n--------- Loading Image Map Utilities ---------");

function createImageMapDB( %name , %path , %imageMode , %smoothing , %cellWidthHeight )
{
	%imageMap = new t2dImageMapDatablock(%name) {
		canSaveDynamicFields = "1";
		imageName = expandFileName(%path);
		imageMode = ("" $= %imageMode) ? "FULL" : %imageMode;
		frameCount = "-1";
		filterMode = ("" $= %smoothing) ? "SMOOTH" : %smoothing ;
		filterPad = "1";
		preferPerf = "0";
		cellRowOrder = "1";
		cellOffsetX = "0";
		cellOffsetY = "0";
		cellStrideX = "0";
		cellStrideY = "0";
		cellCountX = "-1";
		cellCountY = "-1";
		cellWidth = ("" $= %cellWidthHeight) ? "0" : %cellWidthHeight ;
		cellHeight = ("" $= %cellWidthHeight) ? "0" : %cellWidthHeight ;
		preload = "1";
		allowUnload = "0";
	};
	return %imageMap;
}
