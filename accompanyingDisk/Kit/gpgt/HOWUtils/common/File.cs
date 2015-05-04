//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
echo("\n--------- Loading File Utilities ---------");

function readFile( %filename )
{
	%file = new FileObject();
	if(%file.openForRead(%filename))
	{
		while(!%file.isEOF())
		{
			%input = %file.readLine();
			%fileContents = ("" $= %fileContents) ? %input : %fileContents NL %input;
		}
	} else {
		%file.delete();
		return false;
	}
	%file.close();
	%file.delete();
	return %fileContents;
}

function writeFile( %filename , %data ) 
{
	%file = new FileObject();
	if(! %file.openforWrite( %filename ) )
	{
		%file.delete();
		return false;
	}
	%file.writeLine( %data );
	%file.close();
	%file.delete();
	return true;
}

function appendToFile( %filename , %data ) 
{
	%file = new FileObject();
	if(! %file.openforAppend( %filename ) )
	{
		%file.delete();
		return false;
	}
	%file.writeLine( %data );
	%file.close();
	%file.delete();
	return true;
}


function getFileList( %pattern ) {
   %filename = findFirstFile( %pattern );
   
   %fileList =  %filename;

   while("" !$= %filename ) 
   {
      %filename = findNextFile(%pattern );
    
      %fileList = %fileList SPC %filename;
   }
   return %fileList;
}