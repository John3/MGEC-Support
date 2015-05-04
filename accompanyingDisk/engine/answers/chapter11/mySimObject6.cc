#include "console/consoleTypes.h"
#include "console/console.h"
#include "core/bitStream.h"

#include "mySimObject6.h"

IMPLEMENT_CONOBJECT( mySimObject6 );

ConsoleFunction( doAddItUp1, void , 1 , 1 , "doAdditUp1()" )
{
   static const char *myArgs[3];

   myArgs[0] = "echo";
   myArgs[1] = "10 + 10 == ";
   myArgs[2] = "20";

   Con::execute(3, myArgs);
}

ConsoleFunction( doAddItUp2, void , 1 , 1 , "doAdditUp2()" )
{
   Con::executef(3, "echo" , "10 + 10 == ", "20" );
}

ConsoleMethod( mySimObject6 , doDump1 , void, 2, 2, "obj.doDump1()" )
{
   static const char *myArgs[1];

   myArgs[0] = "dump";

   Con::execute( object , 2, myArgs );
}

ConsoleMethod( mySimObject6 , doDump2 , void, 2, 2, "obj.doDump2()" )
{
	   Con::executef( object , 1, "dump");
}

