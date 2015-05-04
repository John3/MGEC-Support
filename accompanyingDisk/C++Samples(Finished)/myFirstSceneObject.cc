#include "dgl/dgl.h"
#include "console/consoleTypes.h"
#include "core/bitStream.h"
#include "math/mathIO.h"
#include "game/gameConnection.h"
#include "console/simBase.h"
#include "sceneGraph/sceneGraph.h"
#include "sceneGraph/sgUtil.h"

#include "myFirstSceneObject.h"

extern bool gEditingMission; 

//-----------------------------------------------------------------------------
IMPLEMENT_CO_NETOBJECT_V1( myFirstSceneObject );

//-----------------------------------------------------------------------------
myFirstSceneObject::myFirstSceneObject()
{
	// 1. Set up type mask
	// Possible masks: GameBaseObjectType, ShapeBaseObjectType, CameraObjectType,
   //                 StaticShapeObjectType, PlayerObjectType, ItemObjectType,
   //                 VehicleObjectType, VehicleBlockerObjectType, ProjectileObjectType,
   //                 ExplosionObjectType, CorpseObjectType,  DebrisObjectType,
   //                 PhysicalZoneObjectType, StaticTSObjectType, AIObjectType,
   //                 StaticRenderedObjectType
	//
	// Ex: mTypeMask |= StaticObjectType | StaticTSObjectType | StaticRenderedObjectType;
	mTypeMask |= StaticObjectType | StaticTSObjectType | StaticRenderedObjectType;

	// 2. Configure ghosting
	// Possible settings:	
	// mNetFlags.set(0); // Not ghosted.
	// mNetFlags.set(Ghostable); // Ghosted.
	// mNetFlags.set(Ghostable | ScopeAlways); //Ghosted and always rendered.
	// mNetFlags.set(Ghostable | ScopeLocal); //Ghosted and only rendered on the client that owns the object
	// mNetFlags.set(Ghostable |ScopeAlways | ScopeLocal ); // Ghosted, always rendered, but only rendered on the
   //                                                      // client that owns the object. The owner client is
   //                                                      // equivalent to
	//
	mNetFlags.set(Ghostable);
}

//-----------------------------------------------------------------------------
myFirstSceneObject::~myFirstSceneObject()
{
}

//-----------------------------------------------------------------------------
void myFirstSceneObject::initPersistFields()
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
void myFirstSceneObject::consoleInit()
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
bool myFirstSceneObject::onAdd()
{
	// 1. Call parent's version of this method FIRST.
	if(!Parent::onAdd()) return(false);

	// 2. Set the 'initial' bounding box for this object:
	//
	// Notes: 
	// - You must (always) reset the world box and set the render transform
	//   after modifying the bounding box.
	//
	mObjBox.min.set( -1.0f, -1.0f, -1.0f );
	mObjBox.max.set( +1.0f, +1.0f, +1.0f );
	resetWorldBox();
	setRenderTransform(mObjToWorld);

	// 3. Add this object to the scene graph.
	// 
	// Notes: 
	// - Some parent classes may already do this.  Be careful not to add twice.
	//
	addToScene();

	return(true);
}

//-----------------------------------------------------------------------------
void myFirstSceneObject::onRemove()
{
	// 1. Remove this object from the scene graph.
	//
	// Notes: 
	// - Some parent classes may already do this.  Be careful not to remove twice.
	//
	removeFromScene();

	// 2. Call parent's version of this method LAST.
	//
	Parent::onRemove();
}


//-----------------------------------------------------------------------------
void myFirstSceneObject::onGroupAdd()
{
	// 1. Call parent's version of this method FIRST.
	Parent::onGroupAdd();
}

//-----------------------------------------------------------------------------
void myFirstSceneObject::onGroupRemove()
{
	// 1. Call parent's version of this method FIRST.
	Parent::onGroupRemove();
}

//-----------------------------------------------------------------------------
void myFirstSceneObject::onNameChange(const char *name)
{
	// 1. Call parent's version of this method FIRST.
	Parent::onNameChange(name);
}

//-----------------------------------------------------------------------------
void myFirstSceneObject::onStaticModified(const char* slotName)
{
	// 1. Call parent's version of this method FIRST.
	Parent::onStaticModified(slotName);
}

//-----------------------------------------------------------------------------
void myFirstSceneObject::onDeleteNotify(SimObject *object)
{
	// 1. Call parent's version of this method FIRST.
	Parent::onDeleteNotify(object);
}

//-----------------------------------------------------------------------------
void myFirstSceneObject::inspectPreApply()
{
	// 1. Call parent's version of this method FIRST.
	Parent::inspectPreApply();
}

//-----------------------------------------------------------------------------
void myFirstSceneObject::inspectPostApply()
{
	// 1. Call parent's version of this method FIRST.
	Parent::inspectPostApply();
}

//-----------------------------------------------------------------------------
void myFirstSceneObject::onEditorEnable()
{
	// 1. Call parent's version of this method FIRST.
	Parent::onEditorEnable();
}

//-----------------------------------------------------------------------------
void myFirstSceneObject::onEditorDisable()
{
	// 1. Call parent's version of this method FIRST.
	Parent::onEditorDisable();
}


//-----------------------------------------------------------------------------
U32 myFirstSceneObject::packUpdate(NetConnection * con, U32 mask, BitStream * stream)
{
	// 1. Call parent's version of this method FIRST.
	U32 retMask = Parent::packUpdate(con, mask, stream);

	// 2.Write object transform.
	stream->writeAffineTransform(mObjToWorld);

	// 3. NEW CODE HERE

	// 4. Return the modified mask bits
	return(retMask);
}

//-----------------------------------------------------------------------------
void myFirstSceneObject::unpackUpdate(NetConnection * con, BitStream * stream)
{
	// 1. Call parent's version of this method FIRST.
	Parent::unpackUpdate(con, stream);

	// 2. Retrieve and apply object transform.
	MatrixF		ObjectMatrix;
	stream->readAffineTransform(&ObjectMatrix);
	setTransform(ObjectMatrix);

	// 3. NEW CODE HERE
}


//-----------------------------------------------------------------------------
bool myFirstSceneObject::prepRenderImage( SceneState* state, const U32 stateKey, const U32 startZone,
										const bool modifyBaseZoneState)
{
	// 1. Return if last state, otherwise set last state
	if (isLastState(state, stateKey)) return false;
	setLastState(state, stateKey);

	// 2. Check if this object will be rendered and if so, prep it...
   if (state->isObjectRendered(this))
   {	   
		// 2a. Allocate a render image (engine deletes this for us).
		SceneRenderImage* image = new SceneRenderImage;

		// 2b. Populate the image.
		image->obj = this;
		image->isTranslucent = false;
		image->sortType = SceneRenderImage::Normal;
		image->useSmallTextures = false;
		image->tieBreaker = false;
		image->textureSortKey = 0;
		
		// 3. Insert image into scene. 
		state->insertRenderImage(image);
   }

   return false;
}

//-----------------------------------------------------------------------------
void myFirstSceneObject::renderObject(SceneState* state, SceneRenderImage*)
{
	// 1. Check that we're in a known clean (canonical) state.
	AssertFatal(dglIsInCanonicalState(), "Error, GL not in canonical state on entry");

	// 2. Store the current Projection Matrix and Viewport
	//    so that we can restore them when we're done.
	glMatrixMode(GL_PROJECTION);
	glPushMatrix(); // Push current Projection Matrix
	RectI viewport;
	dglGetViewport(&viewport);

	// 3. Let TGE set up the current frustum attributes.
	//
	// Note: This leaves us in ModelView Matrix Mode, so you
	//       don't need to set the mode again.
	state->setupObjectProjection(this);

	// 4. Save the ModelView state so we can restore it when we're done.
	glPushMatrix(); // Push current ModelView Matrix

	// 5. Apply objects's current transform BEFORE rendering, otherwise
	//    your render code will produce the wrong results.
	dglMultMatrix(&getTransform());

	
	// 6. ADD YOUR RENDER CODE HERE
	DrawGLScene();


	// 7. Restore the Projection Matrix, the ModelView Matrix,
	//    and the viewport.
	//    so that we can restore them when we're done.
	glPopMatrix(); // Pop stored ModelView Matrix
	glMatrixMode(GL_PROJECTION);
	glPopMatrix(); // Pop stored Projection Matrix
	glMatrixMode(GL_MODELVIEW);
	dglSetViewport(viewport); // Restore Viewport

	// 8. Verify that we are leaving things the way we found them, in
	//    the canonical state.
	//
	// Note: Doing this check here costs a small amount, but saves A LOT
	//       of debug time later.
	AssertFatal(dglIsInCanonicalState(), "Error, GL not in canonical state on exit");
}


//------------------------------------------------------------------------------
//					Modified Function From Nehe Lesson 5 
//					http://nehe.gamedev.net/data/lessons/lesson.asp?lesson=05
//------------------------------------------------------------------------------
void myFirstSceneObject::DrawGLScene(void)	
{
	glRotatef(90,1,0,0); // Rotate to account for TGE orientation
	glBegin(GL_TRIANGLES);								// Start Drawing A Triangle
		glColor3f(1.0f,0.0f,0.0f);						// Red
		glVertex3f( 0.0f, 1.0f, 0.0f);					// Top Of Triangle (Front)
		glColor3f(0.0f,1.0f,0.0f);						// Green
		glVertex3f(-1.0f,-1.0f, 1.0f);					// Left Of Triangle (Front)
		glColor3f(0.0f,0.0f,1.0f);						// Blue
		glVertex3f( 1.0f,-1.0f, 1.0f);					// Right Of Triangle (Front)
		glColor3f(1.0f,0.0f,0.0f);						// Red
		glVertex3f( 0.0f, 1.0f, 0.0f);					// Top Of Triangle (Right)
		glColor3f(0.0f,0.0f,1.0f);						// Blue
		glVertex3f( 1.0f,-1.0f, 1.0f);					// Left Of Triangle (Right)
		glColor3f(0.0f,1.0f,0.0f);						// Green
		glVertex3f( 1.0f,-1.0f, -1.0f);					// Right Of Triangle (Right)
		glColor3f(1.0f,0.0f,0.0f);						// Red
		glVertex3f( 0.0f, 1.0f, 0.0f);					// Top Of Triangle (Back)
		glColor3f(0.0f,1.0f,0.0f);						// Green
		glVertex3f( 1.0f,-1.0f, -1.0f);					// Left Of Triangle (Back)
		glColor3f(0.0f,0.0f,1.0f);						// Blue
		glVertex3f(-1.0f,-1.0f, -1.0f);					// Right Of Triangle (Back)
		glColor3f(1.0f,0.0f,0.0f);						// Red
		glVertex3f( 0.0f, 1.0f, 0.0f);					// Top Of Triangle (Left)
		glColor3f(0.0f,0.0f,1.0f);						// Blue
		glVertex3f(-1.0f,-1.0f,-1.0f);					// Left Of Triangle (Left)
		glColor3f(0.0f,1.0f,0.0f);						// Green
		glVertex3f(-1.0f,-1.0f, 1.0f);					// Right Of Triangle (Left)
	glEnd();											// Done Drawing The Pyramid
}


// C++ DEFINED CONSOLE FUNCTIONS
//
// 1. Add any neccesary ConsoleFunctions here: ConsoleFunction()
//

// C++ DEFINED CONSOLE METHODS
//
// 2. Add any neccesary ConsoleFunctions here: ConsoleMethod()
//

