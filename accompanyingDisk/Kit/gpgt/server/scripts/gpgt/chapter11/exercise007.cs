//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------

package exercisePackage_007
{

function startexercise007()
{  
   
}

function testforEachSimple()
{
   new SimSet( testSet );
   
   testSet.add( new SimObject() );
   testSet.add( new SimObject() );
   testSet.add( new SimObject() );
   
   testSet.forEachSimple( doIt );
   
   testSet.deleteSet( true );
}


function testforEachAdvanced()
{
   new SimSet( testSet );
   
   testSet.add( new SimObject() );
   testSet.add( new SimObject() );
   testSet.add( new SimObject() );

   testSet.forEachAdvanced( doIt2, true );
   
   testSet.deleteSet( true );
}

function testforEachAdvanced2()
{
   new SimSet( testSet );
   
   testSet.add( new SimObject() );
   testSet.add( new SimObject() );
   testSet.add( new SimObject() );

   testSet.forEachAdvanced( doIt2, true , 1 , 2 , 3 );
   
   testSet.deleteSet( true );
}

function simObject::doIt( %obj )
{
   echo("Called doIt() on simObject" SPC %obj );
}

function simObject::doIt2( %obj, %arg0, %arg1, %arg2 )
{
   echo("Called doIt2() on simObject" SPC %obj SPC "with args:" SPC %arg0 SPC %arg1 SPC %arg2 );
}


};

