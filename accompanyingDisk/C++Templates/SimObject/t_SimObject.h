#ifndef _T_SIMOBJECT_H_
#define _T_SIMOBJECT_H_

#include "console/ConsoleObject.h"
#include "console/simBase.h"


//-----------------------------------------------------------------------------
class t_SimObject : public SimObject
{
private:
	typedef SimObject Parent;

public:
	t_SimObject();
	~t_SimObject();

	// From ConsoleObject
	//
	static void initPersistFields();
	static void consoleInit();

	// New in SimObject
	//
	// Sim Callbacks
	//
   bool onAdd();                               
   void onRemove();                             
   void onGroupAdd();                           
   void onGroupRemove();                        
   void onNameChange(const char *name);         
   void onStaticModified(const char* slotName); 
	void onDeleteNotify(SimObject *object);
	// Editor Callbacks
	//
   void inspectPreApply();
   void inspectPostApply();
   void onEditorEnable();
   void onEditorDisable();


	DECLARE_CONOBJECT( t_SimObject );
};

#endif // _T_SIMOBJECT_H_


