#include "console/simBase.h"

// 1

ConsoleFunction(ch10_exer_007, void, 3, 3, 
                "ch10_exer_007( point0 , point1 )")
{
   Point3F point[2]; 


   // 2
   // Add code here
   // Add code here
   Con::printf("Point0 orig => %f %f %f", 
               point[0].x, point[0].y, point[0].z );
   Con::printf("Point1 orig => %f %f %f\n", 
               point[1].x, point[1].y, point[1].z );


   // 3
   // Add code here
   // Add code here
   Con::printf("Point0 norm => %f %f %f",  
               point[0].x, point[0].y, point[0].z );
   Con::printf("Point1 norm => %f %f %f\n",  
               point[1].x, point[1].y, point[1].z );

   // 4
   F32 vectorLen = 0.0f;

   // Add code here
   if( (1.0f - vectorLen) > POINT_EPSILON ) // point[0]
   {
      return;
   }

   // Add code here
   if( (1.0f - vectorLen) > POINT_EPSILON ) // point[1]
   {
      return;
   }

   // 5
   F32 dotProduct = 0.0f;

   // Add code here

   // 6
   F32 theta = 0.0f;

   if( 1.0f == dotProduct ) // Same direction
      theta = 0.0f; // Modify this code.
   else if( -1.0f == dotProduct ) // Exactly opposing directions
      theta = 0.0f; // Modify this code.
   else if( 0.0f == dotProduct ) // @ Right angles
      theta = 0.0f; // Modify this code.
   else // Let's calculate the angle
      theta = 0.0f; // Modify this code.

   Con::printf("The angle between the two vectors is %f degrees.",
               theta );
}