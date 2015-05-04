#ifndef _T_SIMDATABLOCK_H_
#define _T_SIMDATABLOCK_H_

#include "console/simBase.h"

//-----------------------------------------------------------------------------
struct t_SimDataBlock : public GameBaseData
{
   typedef GameBaseData Parent;

   StringTableEntry  mTextureName;
   TextureHandle     mTextureHandle;

public:
   t_SimDataBlock();
   ~t_SimDataBlock();

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

   DECLARE_CONOBJECT(t_SimDataBlock);
};

// Declare our new class as a console type.
//
DECLARE_CONSOLETYPE( t_SimDataBlock );



#endif // _T_SIMDATABLOCK_H_