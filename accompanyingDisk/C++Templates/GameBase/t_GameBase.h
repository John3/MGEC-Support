#ifndef _T_GAMEBASE_H_
#define _T_GAMEBASE_H_

#include "game/gameBase.h"

//-----------------------------------------------------------------------------
struct t_GameBaseData : public GameBaseData
{
   typedef GameBaseData Parent;

public:
   t_GameBaseData();
   ~t_GameBaseData();

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

   DECLARE_CONOBJECT(t_GameBaseData);
};

// Declare our new class as a console type.
//
DECLARE_CONSOLETYPE( t_GameBaseData );


//------------------------------------------------------------------------------
// Class: t_GameBase  -- OBJECT DECLARATION
//------------------------------------------------------------------------------
class t_GameBase : public GameBase
{
private:
	typedef GameBase		Parent;

   t_GameBaseData   * mDataBlock;

public:
	t_GameBase();
	~t_GameBase();

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
	DECLARE_CONOBJECT(t_GameBase);
};
#endif // _T_GAMEBASE_H_