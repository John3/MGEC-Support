#include "dgl/dgl.h"
#include "console/consoleTypes.h"
#include "core/bitStream.h"
#include "console/console.h"
#include "console/simBase.h"
#include "gui/core/guiControl.h"

class guiRenderShapes : public GuiControl
{
   typedef GuiControl Parent;

public:
   guiRenderShapes();

   void setContent(const char * newContent);

   StringTableEntry getContent(void);

   void onRender( Point2I, const RectI &);
   static void initPersistFields();
   DECLARE_CONOBJECT( guiRenderShapes );
};

//-----------------------------------------------------------------------------

IMPLEMENT_CONOBJECT( guiRenderShapes );

guiRenderShapes::guiRenderShapes()
{
}

void guiRenderShapes::initPersistFields()
{
   Parent::initPersistFields();
}


//-----------------------------------------------------------------------------

void guiRenderShapes::onRender(Point2I offset, const RectI &updateRect)
{
   // Background first
   
   dglClearBitmapModulation();

   glEnable( GL_BLEND );
   glBlendFunc( GL_SRC_ALPHA, GL_ONE_MINUS_SRC_ALPHA );
   glDisable( GL_TEXTURE_2D );

   glBegin(GL_TRIANGLES); // Start Drawing A Triangle
   {
      // Upper point in triangle (Red)
      glColor3f(1.0f,0.0f,0.0f);		
      glVertex2i( offset.x + updateRect.extent.x/2 , offset.y );

      // Lower-left point in triangl (Green)
      glColor3f(0.0f,1.0f,0.0f);			
      glVertex2i( offset.x , offset.y  + updateRect.extent.y);

      // Lower-right point in triangl (Blue)
      glColor3f(0.0f,0.0f,1.0f);			
      glVertex2i( offset.x + updateRect.extent.x, offset.y + updateRect.extent.y);	  	  
   }
   glEnd();											// Done Drawing The Triangle


   // Border last
	// None.
}


//-----------------------------------------------------------------------------

