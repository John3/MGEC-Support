#include "dgl/dgl.h"
#include "console/consoleTypes.h"
#include "core/bitStream.h"
#include "console/console.h"
#include "console/simBase.h"
#include "gui/core/guiControl.h"

class guiHelloWorld : public GuiControl
{
   typedef GuiControl Parent;

   StringTableEntry mContent;

   ColorF   mBackgroundColor;
   ColorF   mForegroundColor;

public:
   guiHelloWorld();

   void setContent(const char * newContent);

   StringTableEntry getContent(void);

   void onRender( Point2I, const RectI &);
   static void initPersistFields();
   DECLARE_CONOBJECT( guiHelloWorld );
};

//-----------------------------------------------------------------------------

IMPLEMENT_CONOBJECT( guiHelloWorld );

guiHelloWorld::guiHelloWorld()
{
   mContent = StringTable->insert("Hello World!");

   mBackgroundColor.set(0, 1, 0, 0.5);
   mForegroundColor.set( 1, 1, 1, 1 );

}

void guiHelloWorld::initPersistFields()
{
   Parent::initPersistFields();

   addGroup("Settings");

   addField( "contents",  TypeString, Offset( mContent,		    guiHelloWorld ) );
   addField( "fillColor", TypeColorF, Offset( mBackgroundColor, guiHelloWorld ) );
   addField( "textColor", TypeColorF, Offset( mForegroundColor, guiHelloWorld ) );

   endGroup("Settings");
}


//-----------------------------------------------------------------------------

void guiHelloWorld::onRender(Point2I offset, const RectI &updateRect)
{
   // Background first
   dglDrawRectFill(updateRect, mBackgroundColor);
   
   // Currently only displays min/sec
   char buf[256];
   dSprintf( buf , sizeof(buf), "%s", mContent );

   // Center the text
   offset.x += (mBounds.extent.x - mProfile->mFont->getStrWidth(buf)) / 2;
   offset.y += (mBounds.extent.y - mProfile->mFont->getHeight()) / 2;
   dglSetBitmapModulation(mForegroundColor);
   dglDrawText(mProfile->mFont, offset, buf);
   dglClearBitmapModulation();

   // Border last
	// None.
}


//-----------------------------------------------------------------------------

void guiHelloWorld::setContent(const char * newContent)
{
   // Set Attribute.
   mContent = StringTable->insert(newContent);
}

StringTableEntry guiHelloWorld::getContent(void)
{
   return mContent;
}

ConsoleMethod(guiHelloWorld,setContent,void,3, 3,"( newContent ) - Sets content field to \'newContent\'")
{
   object->setContent(argv[2]);
}

ConsoleMethod(guiHelloWorld,getContent, const char *, 2, 2,"() - Returns current value of content field.")
{
   char * retBuf = Con::getReturnBuffer(256);

   dSprintf(retBuf, 256, "%s", object->getContent() );

   return(retBuf);

}
