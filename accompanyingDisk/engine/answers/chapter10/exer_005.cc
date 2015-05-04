#include "console/simBase.h"

ConsoleFunction(ch10_exer_005, void, 1, 1, "")
{
	S8 count = 0; 
	F32 value = Float_Pi;

	for(; (count >= 0) && (count <= S8_MAX); count++)
	{
		if( 0 == (count % 2) )
		{
			Con::printf("On count %d value == %f", count , value * (F32) count );
		}
		else
		{
			Con::printf("On count %d value == %f", count , value * (F32) -count );
		}
	}
}

