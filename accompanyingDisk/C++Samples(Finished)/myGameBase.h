#ifndef _myGameBase_H_
#define _myGameBase_H_

#include "game/gameBase.h"

//-----------------------------------------------------------------------------
struct myGameBaseData : public GameBaseData
{
   typedef GameBaseData Parent;

public:
   myGameBaseData();
   ~myGameBaseData();

	bool mDrawPyramid;
	bool mDrawCube;

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

	// From SimDataBlock
	// 
   bool        preload( bool server, char errorBuffer[256] );
   void        packData(BitStream* stream);
   void        unpackData(BitStream* stream);

   DECLARE_CONOBJECT(myGameBaseData);
};

// Declare our new class as a console type.
//
DECLARE_CONSOLETYPE( myGameBaseData );


//------------------------------------------------------------------------------
// Class: myGameBase  -- OBJECT DECLARATION
//------------------------------------------------------------------------------
class myGameBase : public GameBase
{
private:
	typedef GameBase		Parent;

   myGameBaseData   * mDataBlock;

	void DrawGLPyramid(void);
	void DrawGLCube(void);

public:
	myGameBase();
	~myGameBase();

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

	// From SceneObject
	void renderObject(SceneState*, SceneRenderImage*);
	virtual bool prepRenderImage(SceneState*, const U32 stateKey, 
		                          const U32 startZone,
								        const bool modifyBaseZoneState = false);

	// New From GameBase
   bool onNewDataBlock( GameBaseData* dptr );
   void interpolateTick( F32 delta );
   void processTick(const Move* move);
   void advanceTime( F32 dt );

   // Declare Console Object.
	DECLARE_CONOBJECT(myGameBase);
};
#endif // _myGameBase_H_