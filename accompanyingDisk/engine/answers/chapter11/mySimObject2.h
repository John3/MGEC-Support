#ifndef _mySimObject2_H_
#define _mySimObject2_H_

#include "console/ConsoleObject.h"
#include "console/simBase.h"

#include "core/color.h" //EFM - need to add on your own

//-----------------------------------------------------------------------------
class mySimObject2 : public SimObject
{
private:
	typedef SimObject Parent;

public:
	mySimObject2();

   F32    mTestF32;
	F32    mTestF32Array[6];
	ColorI mTestColorI;
	bool   mTestBool;
	U32    mTestU32;

	static void initPersistFields();

	DECLARE_CONOBJECT( mySimObject2 );
};

#endif // _mySimObject2_H_


