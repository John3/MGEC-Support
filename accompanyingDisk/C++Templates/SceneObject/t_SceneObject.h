#ifndef _T_SCENEOBJECT_H_
#define _T_SCENEOBJECT_H_

#include "sim/sceneObject.h"

//-----------------------------------------------------------------------------
class t_SceneObject : public SceneObject
{
private:
	typedef SceneObject		Parent;

public:
	t_SceneObject();
	~t_SceneObject();

	// From ConsoleObject
	//
	static void initPersistFields();
	static void consoleInit();

	// From SimObject
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

	// From NetObject
	U32 packUpdate(NetConnection *, U32, BitStream *);
	void unpackUpdate(NetConnection *, BitStream *);

	// New from SceneObject
	void renderObject(SceneState*, SceneRenderImage*);
	virtual bool prepRenderImage(SceneState*, const U32 stateKey, 
		                          const U32 startZone,
								        const bool modifyBaseZoneState = false);

	DECLARE_CONOBJECT( t_SceneObject );
};

#endif // _T_SCENEOBJECT_H_
