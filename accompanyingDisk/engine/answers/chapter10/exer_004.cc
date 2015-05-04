#include "console/simBase.h"

ConsoleFunction(ch10_exer_004a, void, 1, 1, "")
{
	// YOUR CODE GOES HERE
	Con::printf("Torque Rocks!"); 
	Con::warnf("Torque Rocks!");
	Con::errorf("Torque Rocks!");

	Con::printf("A float %08.2f", 123.456); 

	Con::printf("\x1 Color Code 0");
	Con::printf("\x2 Color Code 1");
	Con::printf("\x3 Color Code 2");
	Con::printf("\x4 Color Code 3");
	Con::printf("\x5 Color Code 4");
	Con::printf("\x6 Color Code 5");
	Con::printf("\x7 Color Code 6");
	Con::printf("\xb Color Code 7");
	Con::printf("\xc Color Code 8");
	Con::printf("\xe Color Code 9");

	// or if you prefer octal

	//Con::printf("\001 Color Code 0");
	//Con::printf("\002 Color Code 1");
	//Con::printf("\003 Color Code 2");
	//Con::printf("\004 Color Code 3");
	//Con::printf("\005 Color Code 4");
	//Con::printf("\006 Color Code 5");
	//Con::printf("\007 Color Code 6");
	//Con::printf("\013 Color Code 7");
	//Con::printf("\014 Color Code 8");
	//Con::printf("\016 Color Code 9");
}


