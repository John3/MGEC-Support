#include "console/consoleTypes.h"
#include "console/console.h"
#include "core/bitStream.h"

#include "mySimObject2.h"

IMPLEMENT_CONOBJECT( mySimObject2 );

mySimObject2::mySimObject2()
{
	// Initialize those variables!!!
   mTestF32 = 0.0f;
	
	mTestF32Array[0] = mTestF32Array[1] = mTestF32Array[2] = \
	mTestF32Array[3] = mTestF32Array[4] = mTestF32Array[5] = 0.0f;

	mTestColorI.set( 128 , 200 , 200 );

	mTestBool        = true;

	mTestU32         = 200; 
}

void mySimObject2::initPersistFields()
{
	Parent::initPersistFields();
	
	addField("testF32", TypeF32, Offset( mTestF32, mySimObject2), "An F32 value");

	addField("testF32Array", TypeF32, Offset( mTestF32Array, mySimObject2), 6, NULL, "An F32 array");

	addField("testColorI", TypeColorI, Offset( mTestColorI, mySimObject2), "A ColorI class");

	addField("testBool", TypeBool, Offset( mTestBool, mySimObject2), "A boolean value");

	addField("testU32", TypeS32, Offset( mTestU32, mySimObject2), "A U32 value, exposed as an S32 (trick).");
}
