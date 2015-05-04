#include "console/consoleTypes.h"
#include "console/console.h"
#include "core/bitStream.h"

#include "mySimObject3.h"

static EnumTable::Enums myEntriesEnums[] =
{
	{ mySimObject3::myEntry0, "Entry0" },
	{ mySimObject3::myEntry1, "Entry1" },
	{ mySimObject3::myEntry2, "Entry2" },
	{ mySimObject3::myEntry3, "Entry3" },
	{ mySimObject3::myEntry4, "Entry4" }
};

static EnumTable gMyEntriesTable( 5 , myEntriesEnums );

IMPLEMENT_CONOBJECT( mySimObject3 );

mySimObject3::mySimObject3()
{
	// Initialize those variables!!!
   mTestEnum = mySimObject3::myEntry2;
}

void mySimObject3::initPersistFields()
{
	Parent::initPersistFields();
	
	addField("testEnums", TypeEnum, Offset( mTestEnum, mySimObject3), 1, &gMyEntriesTable, "An enumerated field");
}
