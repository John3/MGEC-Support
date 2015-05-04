#include "dgl/dgl.h"
#include "console/consoleTypes.h"
#include "core/bitStream.h"
#include "math/mathIO.h"
#include "game/gameConnection.h"
#include "console/simBase.h"
#include "sceneGraph/sceneGraph.h"
#include "sceneGraph/sgUtil.h"

#include "mySecondSceneObject.h"

extern bool gEditingMission; 

//-----------------------------------------------------------------------------
IMPLEMENT_CO_NETOBJECT_V1( mySecondSceneObject );

//-----------------------------------------------------------------------------
mySecondSceneObject::mySecondSceneObject()
{
	mDrawControl = 0x1 | 0x2;

	mTypeMask |= StaticObjectType | StaticTSObjectType | StaticRenderedObjectType;
	mNetFlags.set(Ghostable);
}

//-----------------------------------------------------------------------------
mySecondSceneObject::~mySecondSceneObject()
{
}

//-----------------------------------------------------------------------------
void mySecondSceneObject::initPersistFields()
{
	Parent::initPersistFields();

	addField("drawPyramid" , TypeS32 , Offset( mDrawControl, mySecondSceneObject) );
}

//-----------------------------------------------------------------------------
bool mySecondSceneObject::onAdd()
{
	if(!Parent::onAdd()) return(false);

	mObjBox.min.set( -1.0f, -1.0f, -1.0f );
	mObjBox.max.set( +1.0f, +1.0f, +1.0f );
	resetWorldBox();
	setRenderTransform(mObjToWorld);

	addToScene();

	return(true);
}

//-----------------------------------------------------------------------------
void mySecondSceneObject::onRemove()
{
	removeFromScene();

	Parent::onRemove();
}


//-----------------------------------------------------------------------------
U32 mySecondSceneObject::packUpdate(NetConnection * con, U32 mask, BitStream * stream)
{
	U32 retMask = Parent::packUpdate(con, mask, stream);

	stream->writeAffineTransform(mObjToWorld);
	stream->write(mDrawControl);

	return(retMask);
}

//-----------------------------------------------------------------------------
void mySecondSceneObject::unpackUpdate(NetConnection * con, BitStream * stream)
{
	Parent::unpackUpdate(con, stream);

	MatrixF		ObjectMatrix;
	stream->readAffineTransform(&ObjectMatrix);
	setTransform(ObjectMatrix);

	stream->read(&mDrawControl);
}


//-----------------------------------------------------------------------------
bool mySecondSceneObject::prepRenderImage( SceneState* state, const U32 stateKey, const U32 startZone,
										const bool modifyBaseZoneState)
{
	if (isLastState(state, stateKey)) return false;
	setLastState(state, stateKey);

   if (state->isObjectRendered(this))
   {	   
		SceneRenderImage* image = new SceneRenderImage;

		image->obj = this;
		image->isTranslucent = false;
		image->sortType = SceneRenderImage::Normal;
		image->useSmallTextures = false;
		image->tieBreaker = false;
		image->textureSortKey = 0;
		
		state->insertRenderImage(image);
   }

   return false;
}

//-----------------------------------------------------------------------------
void mySecondSceneObject::renderObject(SceneState* state, SceneRenderImage*)
{
	AssertFatal(dglIsInCanonicalState(), "Error, GL not in canonical state on entry");

	glMatrixMode(GL_PROJECTION);
	glPushMatrix(); // Push current Projection Matrix
	RectI viewport;
	dglGetViewport(&viewport);

	state->setupObjectProjection(this);

	glPushMatrix(); // Push current ModelView Matrix

	dglMultMatrix(&getTransform());

	if( 0x1 & mDrawControl ) DrawGLPyramid();

	// Reset the render matrix before drawing again.
	glPopMatrix(); // Pop stored ModelView Matrix
	glPushMatrix(); // Push current ModelView Matrix
	dglMultMatrix(&getTransform());

	if( 0x2 & mDrawControl ) DrawGLCube();
	glPopMatrix(); // Pop stored ModelView Matrix
	glMatrixMode(GL_PROJECTION);
	glPopMatrix(); // Pop stored Projection Matrix
	glMatrixMode(GL_MODELVIEW);
	dglSetViewport(viewport); // Restore Viewport

	AssertFatal(dglIsInCanonicalState(), "Error, GL not in canonical state on exit");
}

//------------------------------------------------------------------------------
//					Modified Functions From Nehe Lesson 5 
//					http://nehe.gamedev.net/data/lessons/lesson.asp?lesson=05
//------------------------------------------------------------------------------
void mySecondSceneObject::DrawGLPyramid(void)	
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

void mySecondSceneObject::DrawGLCube(void)	
{
	glRotatef(90,1,0,0); // Rotate to account for TGE orientation
	glTranslatef( 0.0f, 2.0f, 0.0f );  // Always above the pyramid
	glBegin(GL_QUADS);									// Draw A Quad
		glColor3f(0.0f,1.0f,0.0f);						// Set The Color To Green
		glVertex3f( 1.0f, 1.0f,-1.0f);					// Top Right Of The Quad (Top)
		glVertex3f(-1.0f, 1.0f,-1.0f);					// Top Left Of The Quad (Top)
		glVertex3f(-1.0f, 1.0f, 1.0f);					// Bottom Left Of The Quad (Top)
		glVertex3f( 1.0f, 1.0f, 1.0f);					// Bottom Right Of The Quad (Top)
		glColor3f(1.0f,0.5f,0.0f);						// Set The Color To Orange
		glVertex3f( 1.0f,-1.0f, 1.0f);					// Top Right Of The Quad (Bottom)
		glVertex3f(-1.0f,-1.0f, 1.0f);					// Top Left Of The Quad (Bottom)
		glVertex3f(-1.0f,-1.0f,-1.0f);					// Bottom Left Of The Quad (Bottom)
		glVertex3f( 1.0f,-1.0f,-1.0f);					// Bottom Right Of The Quad (Bottom)
		glColor3f(1.0f,0.0f,0.0f);						// Set The Color To Red
		glVertex3f( 1.0f, 1.0f, 1.0f);					// Top Right Of The Quad (Front)
		glVertex3f(-1.0f, 1.0f, 1.0f);					// Top Left Of The Quad (Front)
		glVertex3f(-1.0f,-1.0f, 1.0f);					// Bottom Left Of The Quad (Front)
		glVertex3f( 1.0f,-1.0f, 1.0f);					// Bottom Right Of The Quad (Front)
		glColor3f(1.0f,1.0f,0.0f);						// Set The Color To Yellow
		glVertex3f( 1.0f,-1.0f,-1.0f);					// Top Right Of The Quad (Back)
		glVertex3f(-1.0f,-1.0f,-1.0f);					// Top Left Of The Quad (Back)
		glVertex3f(-1.0f, 1.0f,-1.0f);					// Bottom Left Of The Quad (Back)
		glVertex3f( 1.0f, 1.0f,-1.0f);					// Bottom Right Of The Quad (Back)
		glColor3f(0.0f,0.0f,1.0f);						// Set The Color To Blue
		glVertex3f(-1.0f, 1.0f, 1.0f);					// Top Right Of The Quad (Left)
		glVertex3f(-1.0f, 1.0f,-1.0f);					// Top Left Of The Quad (Left)
		glVertex3f(-1.0f,-1.0f,-1.0f);					// Bottom Left Of The Quad (Left)
		glVertex3f(-1.0f,-1.0f, 1.0f);					// Bottom Right Of The Quad (Left)
		glColor3f(1.0f,0.0f,1.0f);						// Set The Color To Violet
		glVertex3f( 1.0f, 1.0f,-1.0f);					// Top Right Of The Quad (Right)
		glVertex3f( 1.0f, 1.0f, 1.0f);					// Top Left Of The Quad (Right)
		glVertex3f( 1.0f,-1.0f, 1.0f);					// Bottom Left Of The Quad (Right)
		glVertex3f( 1.0f,-1.0f,-1.0f);					// Bottom Right Of The Quad (Right)
	glEnd();											// Done Drawing The Quad
}
