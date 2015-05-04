#ifndef _mySimObject3_H_
#define _mySimObject3_H_

#include "console/ConsoleObject.h"
#include "console/simBase.h"


//-----------------------------------------------------------------------------
class mySimObject3 : public SimObject
{
private:
	typedef SimObject Parent;

public:
	mySimObject3();

	enum myEntries {
		myEntry0 = 0,
		myEntry1,
		myEntry2,
		myEntry3,
		myEntry4,
	};

   S32  mTestEnum;

	static void initPersistFields();

	DECLARE_CONOBJECT( mySimObject3 );
};

#endif // _mySimObject3_H_


