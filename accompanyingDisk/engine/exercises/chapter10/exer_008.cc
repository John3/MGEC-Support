#include "console/simBase.h"

// 1

ConsoleFunction(ch10_exer_008, bool, 5, 5, 
					 "ch10_exer_008( start , end, min, max )")
{
	Point3F rayStart;
	Point3F rayEnd;

	Point3F boxMin;
	Point3F boxMax;

	// 2
	dSscanf(argv[1], "%f %f %f", &rayStart.x, &rayStart.y, &rayStart.z);
	dSscanf(argv[2], "%f %f %f", &rayEnd.x, &rayEnd.y, &rayEnd.z);

	Con::printf("Ray start => %f %f %f", rayStart.x, rayStart.y, rayStart.z );
	Con::printf("Ray end   => %f %f %f", rayEnd.x, rayEnd.y, rayEnd.z );

	// 3
	dSscanf(argv[3], "%f %f %f", &boxMin.x, &boxMin.y, &boxMin.z);
	dSscanf(argv[4], "%f %f %f", &boxMax.x, &boxMax.y, &boxMax.z);

	Con::printf("Box min => %f %f %f", boxMin.x, boxMin.y, boxMin.z );
	Con::printf("Box max => %f %f %f", boxMax.x, boxMax.y, boxMax.z );

	// 4
	// Add Code here

	// 5
	if( 0 )  // Modify me
	{
		return false;
	}

	// 6
	// Add Code here  (several lines; see the book)


	// 7 
	Con::printf("No collision occurred between our box and the ray");

	return false;
}