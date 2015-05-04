#include "console/simBase.h"


ConsoleFunction(ch10_exer_005, void, 1, 1, "")
{
	signed char count = 0; 
	float value = 3.14159f;

	for(; (count >= 0) && (count <= 127); count++)
	{
		if( 0 == (count % 2) )
		{
			Con::printf("On count %d value == %f", count , value * (float) count );
		}
		else
		{
			Con::printf("On count %d value == %f", count , value * (float) -count );
		}
	}
}
