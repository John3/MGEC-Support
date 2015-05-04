//-----------------------------------------------------------------------------
// Torque Engine
// Copyright (c) GarageGames.Com
//-----------------------------------------------------------------------------
loadDir("common");

package Creator
{
   function onStart()
   {
      if($GPGT::MPDebug) echo("\c3 ====> START-INIT /creator/main.cs ->" SPC "onStart()");
      Parent::onStart();
      echo( "\n--------- Initializing: Torque Creator ---------" );
      
      // Scripts
      exec("./editor/editor.cs");
      exec("./editor/particleEditor.cs");
      exec("./scripts/scriptDoc.cs");
      
      // Gui's
      exec("./ui/creatorProfiles.cs");
      exec("./ui/InspectDlg.gui");
      exec("./ui/GuiEditorGui.gui");
	  
	  exec("./ui/lightEditor.gui");
	  exec("./ui/lightEditorNewDB.gui");
   }
};

if($GPGT::MPDebug) echo("\c3 ====> START-INIT /creator/main.cs ->" SPC "activating package: Creator");
activatePackage( Creator );
