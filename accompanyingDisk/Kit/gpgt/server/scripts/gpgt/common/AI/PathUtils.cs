//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------

//*********************************************************
//             Path Utiltiy Code
//*********************************************************

function createSimplePathPoint( %path, %position ) {
	echo("\c4 Adding marker at position: ", %position );
	%marker = new Marker() {
		position      = CalculateObjectDropPosition( vectorAdd("0 0 50", %position ) );
		scale         = "1 1 1";
		seqNum        = "1";
		type          = "Normal";
		msToNext      = "1000";
		smoothingType = "Spline";
	};
	%path.add(%marker);

	%marker.visibleMarker = new StaticShape() {  
		dataBlock = "FlashingMarker";
		position  = CalculateObjectDropPosition( vectorAdd("0 0 50", %position ) );
		scale     = "4 4 4";
	};

	%marker.visibleMarker.setSkinName("red");

	VisMarkersGroup.add(%marker.visibleMarker);
	
	return %path;
}


function SceneObject::createSimplePath( %this , %name , %radius )
{
	%pathPoints = %this.GetCompassPoints( %radius );
	
	if( isObject( %name ) )
	{
	   %name.delete();
	   VisMarkersGroup.delete();
	}

	%path = new Path( %name ) 
	{
		isLooping = 1;
	};

	MissionGroup.add( %path );
	
	MissionGroup.add( new SimGroup( "VisMarkersGroup" ) );

	%pathPoints.forEachStmt("createSimplePathPoint(" @ %path.getID() @ ", tok.position );", tok );

	%pathPoints.deleteSet(true);		
}

function SceneObject::createSimplePathRandomRadius( %this , %name , %minRadius , %maxRadius )
{
	%pathPoints = %this.GetCompassPointsRandomOffset( %minRadius , %maxRadius );
	
	if( isObject( %name ) )
	{
	   %name.delete();
	   VisMarkersGroup.delete();
	}

	%path = new Path( %name ) 
	{
		isLooping = 1;
	};

	MissionGroup.add( %path );
	
	MissionGroup.add( new SimGroup( "VisMarkersGroup" ) );

	%pathPoints.forEachStmt("createSimplePathPoint(" @ %path.getID() @ ", tok.position );", tok );

	%pathPoints.deleteSet(true);		
}


function Path::getVisibleMarkerID( %path, %nodeNum )
{
   return(%path.getObject(%nodeNum).visibleMarker.getID());   
}



