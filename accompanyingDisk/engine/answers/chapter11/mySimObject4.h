#ifndef _mySimObject4_H_
#define _mySimObject4_H_

#include "console/ConsoleObject.h"
#include "console/simBase.h"

#include "core/color.h" //EFM - need to add on your own

//-----------------------------------------------------------------------------
class mySimObject4 : public SimObject
{
private:
	typedef SimObject Parent;

public:
	mySimObject4();

   S32    mTestS32;

	static void initPersistFields();

	DECLARE_CONOBJECT( mySimObject4 );
};

#endif // _mySimObject4_H_


