#ifndef _mySimObject_H_
#define _mySimObject_H_

#include "console/ConsoleObject.h"
#include "console/simBase.h"


//-----------------------------------------------------------------------------
class mySimObject : public SimObject
{
private:
	typedef SimObject Parent;

public:
	mySimObject();

   S32 mTestVal;

	static void initPersistFields();
	static void consoleInit();

	DECLARE_CONOBJECT( mySimObject );
};

#endif // _mySimObject_H_


