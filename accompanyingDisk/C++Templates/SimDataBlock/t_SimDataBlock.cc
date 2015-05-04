#include "dgl/dgl.h"
#include "console/consoleTypes.h"
#include "core/bitStream.h"
#include "math/mathIO.h"
#include "game/gameConnection.h"
#include "sim/netObject.h"

#include "t_SimDataBlock.h"

extern bool gEditingMission;

//-----------------------------------------------------------------------------
//                  GameBaseData (DATABLOCK) CODE
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
IMPLEMENT_CO_DATABLOCK_V1(t_SimDataBlock);

//-----------------------------------------------------------------------------
t_SimDataBlock::t_SimDataBlock()
{
}

//-----------------------------------------------------------------------------
t_SimDataBlock::~t_SimDataBlock()
{
}

//-----------------------------------------------------------------------------
void t_SimDataBlock::initPersistFields()
{
	// 1. Call parent's version of this method FIRST.
	//
	Parent::initPersistFields();

	// 2. Add our own persistent fields
	//
	// Note: Fields may optionally be 'grouped using the following methods:
	// 
	// addGroup( "UniqueGroupName" ); - This goes BEFORE a set of fields to 
	//                                  be grouped.
	// addField() statements ...
	//
	// endGroup( "UniqueGroupName" ); - This goes AFTER a set of fields to be 
	//                                  grouped and must match prior addGroup().
	//
	// Following types are defined in enum 'ConsoleDynamicTypes' in fileconsoleTypes.h:
	//
	// TypeS8, TypeS32, TypeS32Vector, TypeBool, TypeBoolVector, TypeF32, TypeF32Vector,
	// TypeString, TypeCaseString, TypeFilename, TypeEnum, TypeFlag, TypeColorI, TypeColorF,
	// TypeSimObjectPtr, TypePoint2I, TypePoint2F, TypePoint3F, TypePoint4F, TypeRectI, 
	// TypeRectF, TypeMatrixPosition, TypeMatrixRotation, TypeBox3F, TypeGuiProfile,
	// TypeGameBaseDataPtr, TypeExplosionDataPtr, TypeShockwaveDataPtr, TypeSplashDataPtr,
	// TypeEnergyProjectileDataPtr, TypeBombProjectileDataPtr, TypeParticleEmitterDataPtr,
	// TypeAudioDescriptionPtr, TypeAudioProfilePtr, TypeTriggerPolyhedron,
	// TypeProjectileDataPtr, TypeCannedChatItemPtr, TypeWayPointTeam, TypeDebrisDataPtr, 
	// TypeCommanderIconDataPtr, TypeDecalDataPtr, TypeEffectProfilePtr, 
	// TypeAudioEnvironmentPtr,  TypeAudioSampleEnvironmentPtr,
	//
}

//-----------------------------------------------------------------------------
void t_SimDataBlock::consoleInit()
{
	// 1. Register any neccesary global variables: addVariable()
	//

	// 2. Unregister any neccesary global variables: removeVariable()
	//

	// 3. Register an required existing function or method: addCommand()
	// 
	// Note: The use of this method is deprecated.  You are better off using
	// the ConsoleFunction() and ConsoleMethod() macros instead
	//

}

//-----------------------------------------------------------------------------
bool t_SimDataBlock::onAdd()
{
	// 1. Call parent's version of this method FIRST.
   if(!Parent::onAdd()) return false;

   return true;
}

//-----------------------------------------------------------------------------
void t_SimDataBlock::onRemove()
{

	// Call parent's version of this method LAST.
	//
	Parent::onRemove();
}

//-----------------------------------------------------------------------------
void t_SimDataBlock::onGroupAdd()
{
	// 1. Call parent's version of this method FIRST.
	Parent::onGroupAdd();
}

//-----------------------------------------------------------------------------
void t_SimDataBlock::onGroupRemove()
{
	// 1. Call parent's version of this method FIRST.
	Parent::onGroupRemove();
}

//-----------------------------------------------------------------------------
void t_SimDataBlock::onNameChange(const char *name)
{
	// 1. Call parent's version of this method FIRST.
	Parent::onNameChange(name);
}

//-----------------------------------------------------------------------------
void t_SimDataBlock::onStaticModified(const char* slotName)
{
	// 1. Call parent's version of this method FIRST.
	Parent::onStaticModified(slotName);
}

//-----------------------------------------------------------------------------
void t_SimDataBlock::onDeleteNotify(SimObject *object)
{
	// 1. Call parent's version of this method FIRST.
	Parent::onDeleteNotify(object);
}

//-----------------------------------------------------------------------------
void t_SimDataBlock::inspectPreApply()
{
	// 1. Call parent's version of this method FIRST.
	Parent::inspectPreApply();
}

//-----------------------------------------------------------------------------
void t_SimDataBlock::inspectPostApply()
{
	// 1. Call parent's version of this method FIRST.
	Parent::inspectPostApply();
}

//-----------------------------------------------------------------------------
void t_SimDataBlock::onEditorEnable()
{
	// 1. Call parent's version of this method FIRST.
	Parent::onEditorEnable();
}

//-----------------------------------------------------------------------------
void t_SimDataBlock::onEditorDisable()
{
	// 1. Call parent's version of this method FIRST.
	Parent::onEditorDisable();
}

//-----------------------------------------------------------------------------
bool t_SimDataBlock::preload(bool server, char errorBuffer[256])
{
	// 1. Call parent's version of this method FIRST.
   if (Parent::preload(server, errorBuffer) == false)
      return false;

   if( server ) {
      // SERVER CODE GOES HERE
      return true;
   }

	// CLIENT CODE GOES BELOW

   //EFM -  Load datablocks and shape data here if needed
   return true;
}


//-----------------------------------------------------------------------------
void t_SimDataBlock::packData(BitStream* stream)
{
	// 1. Call parent's version of this method FIRST.
	Parent::packData(stream);

	// 2. NEW CODE HERE
}

//-----------------------------------------------------------------------------
void t_SimDataBlock::unpackData(BitStream* stream)
{
   // 1. Call parent's version of this method FIRST.
	Parent::unpackData(stream);

	// 2. NEW CODE HERE
}


//-----------------------------------------------------------------------------
// Implement our new class as a console type.
//
IMPLEMENT_CONSOLETYPE( t_SimDataBlock );
IMPLEMENT_GETDATATYPE( t_SimDataBlock );
IMPLEMENT_SETDATATYPE( t_SimDataBlock );


// C++ DEFINED CONSOLE FUNCTIONS
//
// 1. Add any neccesary ConsoleFunctions here: ConsoleFunction()
//

// C++ DEFINED CONSOLE METHODS
//
// 2. Add any neccesary ConsoleFunctions here: ConsoleMethod()
//

