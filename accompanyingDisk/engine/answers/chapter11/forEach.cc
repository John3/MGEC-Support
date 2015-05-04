#include "console/consoleTypes.h"
#include "console/console.h"
#include "core/bitStream.h"

#include "console/ConsoleObject.h"
#include "console/simBase.h"

ConsoleMethod( SimSet , forEachSimple , void, 2, 3, "obj.forEachSimple( method [, debug = false ] );")
{
	char methodName[256];    // Not efficient, but simple.
	char evalStr[1024];   // Not efficient, but simple.

	bool debug = false; // Assume no debug
	int extraArgs = 0;  // Assum no extra args

	// Extract the methodName
	dMemset( methodName, '\0', 256 ); // Clear the evalStr string
	dSprintf( methodName , 256, "%s", argv[2] );

	// Determine if debug has been enabled and if there are extra args
	if( 3 == argc )
	{
		debug = false;
		extraArgs = 0;
	}
	else
	{
		debug = dAtob(argv[3]);
		extraArgs = 0;
	}

	// Build and Execute the evalStr, once for each object in the SimSet
	for (SimSetIterator obj( object ); *obj; ++obj)
	{
		SimObject* nobj = dynamic_cast<SimObject*>(*obj);

		if (nobj)
		{
			dMemset( evalStr, '\0', 1024 ); // Clear the evalStr string

			dSprintf( evalStr, 1024 , "%d.%s();", nobj->getId(), methodName);

			Con::evaluate( evalStr , debug );
		}
	}
}

ConsoleMethod( SimSet , forEachAdvanced , void, 2, 0, "obj.forEachAdvanced( method [, debug = false [, arg0 [, ... [, argn ]]]] );")
{
	char methodName[256];    // Not efficient, but simple.
	char evalStr[1024];   // Not efficient, but simple.
	char argString[1024]; // Not efficient, but simple.

	bool debug = false; // Assume no debug
	int extraArgs = 0;  // Assum no extra args

	// Extract the methodName
	dMemset( methodName, '\0', 256 ); // Clear the evalStr string
	dSprintf( methodName , 256, "%s", argv[2] );

	// Determine if debug has been enabled and if there are extra args
	if( 3 == argc )
	{
		debug = false;
		extraArgs = 0;
	}
	else if( 4 == argc )
	{
		debug = dAtob(argv[3]);
		extraArgs = 0;
	}
	else
	{
		debug = dAtob(argv[3]);
		extraArgs = argc - 4;
	}

	// Build the method call less the ID of the calling object.
	dMemset( argString, '\0', 1024 ); // Clear the extra args string before filling it
	for( int count = 0;count < extraArgs;count++ )
	{
		int offset = dStrlen( argString ); //Offset into arg string to place next argument
		if(offset)
		{
			dSprintf( argString + offset , 1024-offset , ",%s", argv[4+count] );
		}
		else
		{
			dSprintf( argString , 1024 , "%s", argv[4+count] );
		}		
	}

	// Build and Execute the evalStr, once for each object in the SimSet
	for (SimSetIterator obj( object ); *obj; ++obj)
	{
		SimObject* nobj = dynamic_cast<SimObject*>(*obj);

		if (nobj)
		{
			dMemset( evalStr, '\0', 1024 ); // Clear the evalStr string

			dSprintf( evalStr, 1024 , "%d.%s(%s);", nobj->getId(), methodName, argString );

			Con::evaluate( evalStr , debug );
		}
	}
}