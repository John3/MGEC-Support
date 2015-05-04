//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
function generateBasicAccessMethods( %namespace , %fieldName )
{
   generateBasicGetMethod( %namespace , %fieldName );
   generateBasicSetMethod( %namespace , %fieldName );
}

function generateBasicGetMethod( %namespace , %fieldName )
{
   %evalStr = 
   "function " @ %namespace @ "::get" @ %fieldName @ "( %this )" @
   "{" @
   "    return %this." @ %fieldName @ ";" @
   "}";
   //echo( "\c3" @ %evalStr );
   eval( %evalStr );
}

function generateBasicSetMethod( %namespace , %fieldName )
{
   %evalStr = 
   "function " @ %namespace @ "::set" @ %fieldName @ "( %this , %value )" @
   "{" @
   "    %this." @ %fieldName @ " = %value;" @
   "    return %this." @ %fieldName @ ";" @
   "}";
   //echo( "\c3" @ %evalStr );
   eval( %evalStr );
}

