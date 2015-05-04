//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
echo("\n--------- Loading SimSet Utilities ---------");


// For each object in 'theSet', %function is executed in one of two ways:
// %isMethod == false => function(%obj); // executed as function, %obj is passed manually
// %isMethod == true  => %obj.function(); // executed as method, %obj is passed automatically
//
// If you are having trouble using this utility, enable %printEval by setting it to true
// and check your results.  You may have a typo and it should show up here.
function SimSet::forEach( %theSet, %function, %isMethod, %printEval) 
{
	%numObjects = %theSet.getCount();

	for(%forEachCount = 0; %forEachCount < %numObjects; %forEachCount++) 
	{
		if(%isMethod) 
		{
			%evalStr = %theSet.getObject(%forEachCount) @ "." @ %function @ "();" ;
		} else {
			%evalStr = %function @ "(" @ %theSet.getObject(%forEachCount) @");" ;
		}
		if( %printEval ) echo(%evalStr);
		eval(%evalStr);
	}
}


// This is very like the above forEach, except a string is passed to this method
// specifying tokens (passed as %token) where the ID of the current object should be 
// inserted in place of the token. The resultant string is then executed like a flat 
//  statement.
//
// If you are having trouble using this utility, enable %printEval by setting it to true
// and check your results.  You may have a typo and it should show up here.
//
// Sample Usage: $x.forEachStmt("echo( tok.getID() );", tok );
//
function SimSet::forEachStmt( %theSet, %statement, %token, %printEval) 
{
	%numObjects = %theSet.getCount();

	for(%forEachStmtCount = 0; %forEachStmtCount < %numObjects; %forEachStmtCount++) 
	{
		%evalStr = strReplace( %statement , 
			%token , 
			%theSet.getObject(%forEachStmtCount).getID() );
		if( %printEval ) echo(%evalStr);

		eval(%evalStr);
	}
}

// Deletes every object in 'theSet'
// Self-deletes if 'selfDestruct' is set to true
function SimSet::deleteSet( %theSet, %selfDestruct) 
{
	while(%theSet.getCount() > 0) 
	{
		%theSet.getObject(0).delete();
	}

	if(%selfDestruct) {
		%theSet.delete();
	}
}

// Copies all entries from the calling simSet to the passed SimSet.
function SimSet::copyToSet( %theSet, %destSet ) 
{
	if( "SimSet" $= %destSet.getClassName() )
	{
		%theSet.forEachStmt( %destSet.getID() @ ".add( tok );" , "tok" );
		return 1;
	}
	else if( ( "SimGroup" $= %destSet.getClassName() ) || ( "ScriptGroup" $= %destSet.getClassName() ) )
	{
		%tmpSet = new SimSet();

		%theSet.forEachStmt( %tmpSet.getID() @ ".add( tok );" , "tok" );

		%tmpSet.forEachStmt( %destSet.getID() @ ".add( tok );" , "tok" );

		%tmpSet.delete();

		return 1;
	}
	return 0;
}

// Returns a random entry from the simSet.
// Note: Does not modify the order of the calling set.
function SimSet::getRandomObject( %theSet ) 
{
	if( %theSet.getCount() == 0 ) 
		return 0;
	if( %theSet.getCount() == 1 ) 
	{
		%theObj = %theSet.getObject( 0 );
	}
	else 
	{
		%theObj = %theSet.getObject( getRandom( 0 , %theSet.getCount() - 1 ) );
		while( ( isObject(%theSet._lastRandomObject) ) &&
			(%theObj.getID() == %theSet._lastRandomObject.getID() ) )
		{
			%theObj = %theSet.getObject( getRandom( 0 , %theSet.getCount() - 1 ) );
		}
	}

	%theSet._lastRandomObject = %theObj;

	return %theObj;
}



// Sorts the contents of this SimSet using these rules:
// - Use contents of named field for sort (present in all objects in set)
// - Sort in ascending (increasing) order by default.
// 
// Warning: Uses proxy object of class GuiTextListCtrl to do work.
//
function SimSet::sort( %theSet , %fieldName , %Decreasing )
{
	new GuiTextListCtrl(sortProxy);
	
	%maxIndex = %theSet.getCount();

	for(%count=0; %count < %maxIndex; %count++)
	{
	   %evalStr = "%fieldContents = " @ %theSet.getObject( %count ) @ "." @ %fieldName @ ";";

	   eval(%evalStr);
	   
	   //error( %fieldContents SPC %theSet.getObject( %count ) );
	   
		sortProxy.addRow( %count , %fieldContents SPC %theSet.getObject( %count ) );
	}

	%sortOrder = !(%Decreasing);

	sortProxy.sort( 0 , %sortOrder );

	for(%count=0; %count < %maxIndex; %count++)
	{
	   error( "SORT: ", sortProxy.getRowText(%count) );
		%theSet.pushToBack( getWord( sortProxy.getRowText(%count) , 3 ) );
	}

	sortProxy.delete();

}