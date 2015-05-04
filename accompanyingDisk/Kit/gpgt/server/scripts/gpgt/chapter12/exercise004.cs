//------------------------------------------------------
// Copyright 2004-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
package exercisePackage_004
{

function startexercise004()
{
   $prepFile = expandFilename( "~/baseLineTMMDump" );
   $TMMFile = expandFilename( "~/debugTMMDump" );
}

function doPrepWork()
{
   // ?????
   // ?????
}

function doTMMDump()
{
   // ?????
}

function dummyWork()
{
   new SimObject(dummyObjA);
}

function dummyCleanup()
{
   dummyObjA.delete();
}

function printDumps()
{
   %preWork = readFile( $prepFile );
   %postWork = readFile( $TMMFile );
   
   echo("****** PRE WORK ************");
   echo(%preWork);
   
   echo("\n****** POST WORK *********");
   echo(%postWork);

}

function tmmTest0()
{
   doPrepWork();

   dummyWork();
   dummyCleanup();

   doTMMDump();
   printDumps();
}

function tmmTest1()
{
   doPrepWork();

   dummyWork();

   doTMMDump();
   printDumps();
   
}

};

