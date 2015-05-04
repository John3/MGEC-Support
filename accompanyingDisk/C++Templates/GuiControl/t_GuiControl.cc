#include "dgl/dgl.h"
#include "console/consoleTypes.h"
#include "core/bitStream.h"
#include "console/console.h"
#include "console/simBase.h"
#include "gui/core/guiControl.h"


//-----------------------------------------------------------------------------
class t_GuiControl : public GuiControl
{
private:
   typedef GuiControl Parent;

public:
   t_GuiControl();
	~t_GuiControl();

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

	// New From GuiControl
	//
   void onRender( Point2I, const RectI &);
	//void onPreRender(); /// Do special pre-render proecessing
	//
	// General Events
	//bool onWake();
	//void onSleep();
	//void onChildAdded( GuiControl *child );
	//void onChildRemoved( GuiControl *child );
	//
	// Mouse Events
	//void onMouseUp(const GuiEvent &event);
	//void onMouseDown(const GuiEvent &event);
	//void onMouseMove(const GuiEvent &event);
	//void onMouseDragged(const GuiEvent &event);
	//void onMouseEnter(const GuiEvent &event);
	//void onMouseLeave(const GuiEvent &event);
	//bool onMouseWheelUp(const GuiEvent &event);
	//bool onMouseWheelDown(const GuiEvent &event);
	//void onRightMouseDown(const GuiEvent &event);
	//void onRightMouseUp(const GuiEvent &event);
	//void onRightMouseDragged(const GuiEvent &event);
	//void onMiddleMouseDown(const GuiEvent &event);
	//void onMiddleMouseUp(const GuiEvent &event);
	//void onMiddleMouseDragged(const GuiEvent &event);
	//
	// Editor Mouse Events
	//bool onMouseDownEditor(const GuiEvent &event, Point2I offset) { return false; };
	//bool onMouseUpEditor(const GuiEvent &event, Point2I offset) { return false; };
	//bool onRightMouseDownEditor(const GuiEvent &event, Point2I offset) { return false; };
	//bool onMouseDraggedEditor(const GuiEvent &event, Point2I offset) { return false; };
	//
	// First Responder Events
	//void onLoseFirstResponder();
	//
	// Keyboard Events
	//void addAcceleratorKey();
	//void buildAcceleratorMap();
	//void acceleratorKeyPress(U32 index);
	//void acceleratorKeyRelease(U32 index);
	//bool onKeyDown(const GuiEvent &event);
	//bool onKeyUp(const GuiEvent &event);
	//bool onKeyRepeat(const GuiEvent &event);
	//
	// GUI Action Event
	//void onAction();
	// 
	// Canvas Events
   //void onDialogPush();
   //void onDialogPop();


	DECLARE_CONOBJECT( t_GuiControl );
};

//-----------------------------------------------------------------------------
IMPLEMENT_CONOBJECT( t_GuiControl );

//-----------------------------------------------------------------------------
t_GuiControl::t_GuiControl()
{
}

//-----------------------------------------------------------------------------
t_GuiControl::~t_GuiControl()
{
}

//-----------------------------------------------------------------------------
void t_GuiControl::initPersistFields()
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
void t_GuiControl::consoleInit()
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
bool t_GuiControl::onAdd()
{
	return true;
}

//-----------------------------------------------------------------------------
void t_GuiControl::onRemove()
{
}

//-----------------------------------------------------------------------------
void t_GuiControl::onGroupAdd()
{
}

//-----------------------------------------------------------------------------
void t_GuiControl::onGroupRemove()
{
}

//-----------------------------------------------------------------------------
void t_GuiControl::onNameChange(const char *name)
{
}

//-----------------------------------------------------------------------------
void t_GuiControl::onStaticModified(const char* slotName)
{
}

//-----------------------------------------------------------------------------
void t_GuiControl::onDeleteNotify(SimObject *object)
{
}

//-----------------------------------------------------------------------------
void t_GuiControl::inspectPreApply()
{
}

//-----------------------------------------------------------------------------
void t_GuiControl::inspectPostApply()
{
}

//-----------------------------------------------------------------------------
void t_GuiControl::onEditorEnable()
{
}

//-----------------------------------------------------------------------------
void t_GuiControl::onEditorDisable()
{
}
//-----------------------------------------------------------------------------
void t_GuiControl::onRender(Point2I offset, const RectI &updateRect)
{
}

