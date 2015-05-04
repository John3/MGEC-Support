#include "console/simBase.h"

// 1 - Include this directory to get ALL math features
#include "math/mMath.h" 

ConsoleFunction(ch10_exer_008, bool, 5, 5, "ch10_exer_008( start , end, min, max )")
{
	Point3F rayStart;
	Point3F rayEnd;

	Point3F boxMin;
	Point3F boxMax;

	// 2 - Copy ray start and end data into the provided variables
	dSscanf(argv[1], "%f %f %f", &rayStart.x, &rayStart.y, &rayStart.z);
	dSscanf(argv[2], "%f %f %f", &rayEnd.x, &rayEnd.y, &rayEnd.z);

	Con::printf("Ray start => %f %f %f", rayStart.x, rayStart.y, rayStart.z );
	Con::printf("Ray end   => %f %f %f", rayEnd.x, rayEnd.y, rayEnd.z );

	// 3 - Copy box min and max data into the provided variables 
	dSscanf(argv[3], "%f %f %f", &boxMin.x, &boxMin.y, &boxMin.z);
	dSscanf(argv[4], "%f %f %f", &boxMax.x, &boxMax.y, &boxMax.z);

	Con::printf("Box min => %f %f %f", boxMin.x, boxMin.y, boxMin.z );
	Con::printf("Box max => %f %f %f", boxMax.x, boxMax.y, boxMax.z );

	// 4 - Define a new box.
	Box3F aBox( boxMin, boxMax );

	// 5 - Verify that the box was defined properly 
	if( ! aBox.isValidBox() )
	{
		Con::errorf("The box min and max points were not defined properly.  Try again.");
		return false;
	}

	// 6 - Check for a collision and print the location of that collision if there is one
	F32     collisionPos;
	Point3F collisionNormal;
	if( aBox.collideLine( rayStart, rayEnd , &collisionPos, &collisionNormal ) )
	{
		Point3F collisionPoint;
		collisionPoint.interpolate( rayStart, rayEnd , collisionPos );
		Con::printf("Our ray collided with the box at point location <%f %f %f>", 
			         collisionPoint.x, collisionPoint.y, collisionPoint.z);

		return true;
	}

	Con::printf("No collision occurred between our box and the ray");
	return false;
}
