#ifndef _mySecondSceneObject_H_
#define _mySecondSceneObject_H_

#include "sim/sceneObject.h"

//-----------------------------------------------------------------------------
class mySecondSceneObject : public SceneObject
{
private:
	typedef SceneObject		Parent;

	void DrawGLPyramid(void);
	void DrawGLCube(void);

public:
	mySecondSceneObject();
	~mySecondSceneObject();

	bool mDrawControl;

	static void initPersistFields();

   bool onAdd();                               
   void onRemove();                             

	U32 packUpdate(NetConnection *, U32, BitStream *);
	void unpackUpdate(NetConnection *, BitStream *);

	void renderObject(SceneState*, SceneRenderImage*);
	virtual bool prepRenderImage(SceneState*, const U32 stateKey, 
		                          const U32 startZone,
								        const bool modifyBaseZoneState = false);

	DECLARE_CONOBJECT( mySecondSceneObject );
};

#endif // _mySecondSceneObject_H_
