#include "console/consoleTypes.h"
#include "console/console.h"
#include "core/bitStream.h"

#include "t_SimObject.h"

//-----------------------------------------------------------------------------
IMPLEMENT_CONOBJECT( t_SimObject );

//-----------------------------------------------------------------------------
t_SimObject::t_SimObject()
{
}
//-----------------------------------------------------------------------------
t_SimObject::~t_SimObject()
{
}

//-----------------------------------------------------------------------------
void t_SimObject::initPersistFields()
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
void t_SimObject::consoleInit()
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
bool t_SimObject::onAdd()
{
	return true;
}

//-----------------------------------------------------------------------------
void t_SimObject::onRemove()
{
}

//-----------------------------------------------------------------------------
void t_SimObject::onGroupAdd()
{
}

//-----------------------------------------------------------------------------
void t_SimObject::onGroupRemove()
{
}

//-----------------------------------------------------------------------------
void t_SimObject::onNameChange(const char *name)
{
}

//-----------------------------------------------------------------------------
void t_SimObject::onStaticModified(const char* slotName)
{
}

//-----------------------------------------------------------------------------
void t_SimObject::onDeleteNotify(SimObject *object)
{
}

//-----------------------------------------------------------------------------
void t_SimObject::inspectPreApply()
{
}

//-----------------------------------------------------------------------------
void t_SimObject::inspectPostApply()
{
}

//-----------------------------------------------------------------------------
void t_SimObject::onEditorEnable()
{
}

//-----------------------------------------------------------------------------
void t_SimObject::onEditorDisable()
{
}


// C++ DEFINED CONSOLE FUNCTIONS
//
// 1. Add any neccesary ConsoleFunctions here: ConsoleFunction()
//

// C++ DEFINED CONSOLE METHODS
//
// 2. Add any neccesary ConsoleFunctions here: ConsoleMethod()
//
