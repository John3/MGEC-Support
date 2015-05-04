//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
$HOW_UTILS::Description    = "Hall Of Worlds Scripted Utility Pack #1";
$HOW_UTILS::Version        = 0.5;
$HOW_UTILS::LastUpdate     = "28 JUL 2007";

function initHOWUtils()
{  
   exec("./common/ArrayObject.cs");
   exec("./common/AutoLoadManager.cs");
   exec("./common/Fields.cs");
   exec("./common/File.cs");
   exec("./common/GUI.cs");
   exec("./common/Math.cs");
   exec("./common/Objects.cs");
   exec("./common/Records.cs");
   exec("./common/SimSet.cs");
   exec("./common/Words.cs");

   exec("./common/EventRouter/EventBind.cs");
   exec("./common/EventRouter/EventRouter.cs");

   exec("./TGB/accessMethodGenerators.cs");
   exec("./TGB/ImageMaps.cs");
   exec("./TGB/t2dSceneObject.cs");
   exec("./TGB/WorldLimit.cs");

   exec("./TGE/GameBase.cs");
   exec("./TGE/Networking.cs");
   exec("./TGE/SceneObject.cs");   
}

package HOW_UTILSPackage {
   function getHOWVersions()
   {
      echo( $HOW_UTILS::Description SPC ":" SPC $HOW_UTILS::Version SPC "Last updated:" SPC $HOW_UTILS::LastUpdate );
      Parent::getHOWVersions();
   }
};

activatePackage( HOW_UTILSPackage );

initHOWUtils();