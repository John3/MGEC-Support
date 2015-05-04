//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
echo("\n--------- Loading Miscellaneous Utilities ---------");

//
// This method is provided to allow you to dump a text file into 
// an existing ML Text control, instead of writing the same code
// over, and over, ...
//
function GuiMLTextCtrl::fillFromFile( %theControl , %textFile , %clear ) {

	if( %clear )
	{
		%theControl.setValue(""); // Clear it
	}

	%file = new FileObject();

	%fileName = expandFileName( %textFile );

	%fileIsOpen = %file.openForRead( %fileName );

	if( %fileIsOpen ) 
	{
		while(!%file.isEOF()) 
		{
			%currentLine = %file.readLine();

			%theControl.addText( %currentLine, true );
		}
	}

	if( %theControl.isVisible() ) %theControl.forceReflow();

	%file.close();

	%file.delete();
}

