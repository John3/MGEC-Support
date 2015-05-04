#ifndef _T_CONSOLEOBJECT_H_
#define _T_CONSOLEOBJECT_H_

#include "console/ConsoleObject.h"

//-----------------------------------------------------------------------------
class t_ConsoleObject : public ConsoleObject
{
private:
	typedef ConsoleObject Parent;

public:
	t_ConsoleObject();
	~t_ConsoleObject();

	static void initPersistFields();

	static void consoleInit();

	DECLARE_CONOBJECT( t_ConsoleObject );
};

#endif // _T_CONSOLEOBJECT_H_
