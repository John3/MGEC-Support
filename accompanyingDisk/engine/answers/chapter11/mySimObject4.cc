#include "console/consoleTypes.h"
#include "console/console.h"
#include "core/bitStream.h"

#include "mySimObject4.h"

#include "console/typeValidators.h" //EFM

IMPLEMENT_CONOBJECT( mySimObject4 );

mySimObject4::mySimObject4()
{
	// Initialize those variables!!!
   mTestS32 = -2;
}

void mySimObject4::initPersistFields()
{
	Parent::initPersistFields();
	
	addFieldV("testS32", TypeS32, Offset( mTestS32, mySimObject4), 
		       new IRangeValidator( -5 , 15 ), "A range validated S32 value");

}
