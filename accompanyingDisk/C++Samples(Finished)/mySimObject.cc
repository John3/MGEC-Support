#include "console/consoleTypes.h"
#include "console/console.h"
#include "core/bitStream.h"

#include "mySimObject.h"

bool testGlobal = true;

//-----------------------------------------------------------------------------
IMPLEMENT_CONOBJECT( mySimObject );

//-----------------------------------------------------------------------------
mySimObject::mySimObject()
{
	mTestVal = 0;		
}

//-----------------------------------------------------------------------------
void mySimObject::initPersistFields()
{
	Parent::initPersistFields();
	
	addField("testVal" , TypeS32 , Offset( mTestVal, mySimObject) );
}

//-----------------------------------------------------------------------------
void mySimObject::consoleInit()
{
	Con::addVariable("$testGlobal", TypeBool, &testGlobal);
}


ConsoleMethod( mySimObject , printTestVal , void, 2, 2, "Prints the current value of the field testVal")
{
   Con::printf("Calling mySimObject::%s( %d ).", argv[0], dAtoi(argv[1]));
   Con::printf("testVal == %d", object->mTestVal);
}

ConsoleFunction( printField, bool , 3 , 4 , "printField( Obj , fieldName [, idx ])" )
{
   Con::printf("Calling %s( %s , %s ).", argv[0], argv[1] , argv[2] );

	//// Try to find the object
   //
   SimObject* obj;
   if( !Sim::findObject( argv[1] , obj ) ) 
   {
      Con::errorf("Could not find object %s", argv[1]);
      return false;
   };

   //// See if the object has a field of the passed name
   //
   const char * curIndex = (4 == argc) ? argv[3] : NULL;
   if( ! obj->getDataField( StringTable->insert(argv[2], false ), curIndex ) ) 
   {
      Con::errorf("Could not find %s.%s", argv[1], argv[2] );
      return false;
   }

   Con::printf("%s.%s == %s", argv[1], argv[2], 
       obj->getDataField( StringTable->insert(argv[2], false) , NULL ) );
   return true;
}
