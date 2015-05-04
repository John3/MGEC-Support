//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
echo("\n--------- Loading Field Utilities ---------");

// Some utilties for modifying strings of fields
//
// swapFields - Swaps two fields is string
// randomizeFields - Randmomizes locations of fields in string
//
function swapFields( %fields, %first, %second )
{
	%numFields = getFieldCount(%fields);

	if( ! ( ( 0 == %numFields) ||
		(%first < 0) ||
		(%first >= %numFields)  ||
		(%second < 0)  ||
		(%second >= %numFields) ||
		( %first == %second) ) )
	{
		%tmp = getField( %fields , %first );
		%fields = setField( %fields , %first , getField( %fields , %second ) );
		%fields = setField( %fields , %second , %tmp );

	}

	return %fields;
}

function randomizeFields( %fields , %iterations )
{
	%numFields = getFieldCount(%fields);
	if( 0 == %numFields) return "";
	for( %count = 0; %count < %iterations ; %count++) {
		%first  = getRandom( 0 , %numFields - 1 );
		%second = getRandom( 0 , %numFields - 1 );
		%fields = swapFields( %fields, %first, %second );
	}
	return %fields;
}

function sortFields( %fields , %descending )
{
   %tmpArray = new scriptObject( arrayObject );
      
   %tmpTokens = %fields;
   
   while( "" !$= %tmpTokens ) 
   {
      %tmpTokens = nextToken( %tmpTokens , "theToken" , "\t" );
      %tmpArray.addEntry( %theToken );      
   }
   
   %tmpArray.sort( %descending );
   
   %entries = %tmpArray.getCount();
   
   for( %count = 0; %count < %entries; %count++ )
   {
      %newFields = %newFields TAB %tmpArray.getEntry( %count );
   }
   
   %newFields = trim( %newFields );
   
   %tmpArray.delete();
   
   return %newFields;
}


function isUniqueField( %fields , %newField )
{
   //
   // Find and replace the old name
   //
   %tmpFields = %fields; 
   
   %isUnique = true;  

   while( "" !$= %tmpFields ) 
   {
      %tmpFields = nextToken( %tmpFields , "theToken" , "\t" );
      
      if (%theToken $= %newField) %isUnique = false;
   }
   
   return( %isUnique );
}


function addUniqueField( %fields , %newField )
{
   //
   // Find and replace the old name
   //
   %tmpFields = %fields; 
   
   %isUnique = true;  

   while( "" !$= %tmpFields ) 
   {
      %tmpFields = nextToken( %tmpFields , "theToken" , "\t" );
      
      if (%theToken $= %newField) %isUnique = false;
   }
   
   if( !%isUnique ) return %fields;
   
   %newFields = %fields TAB %newField;
   
   %newFields = trim ( %newFields );
   
   return %newFields;
}

function replaceField( %fields , %oldField, %newField )
{
   //
   // Find and replace the old name
   //
   %tmpFields = %fields;   

   while( "" !$= %tmpFields ) 
   {
      %tmpFields = nextToken( %tmpFields , "theToken" , "\t" );
      
      %field = (%theToken $= %oldField) ? %newField : %theToken;
      
      %newFields = %newFields TAB %field;
   }
   
   %newFields = trim ( %newFields );
   
   return %newFields;
}

function removeField( %fields , %oldField , %firstOnly )
{
   //
   // Find and replace the old name
   //
   %tmpFields = %fields;   

   while( "" !$= %tmpFields ) 
   {
      %tmpFields = nextToken( %tmpFields , "theToken" , "\t" );
      
      if ( ( %theToken $= %oldField ) && !(%firstOnly && %removed) )
      {
         // Nothing
         %removed = true;
      }
      else
      {
         %newFields = %newFields TAB %theToken;
      }

   }
   
   %newFields = trim ( %newFields );
   
   return %newFields;
}

function pushFieldFront( %fields , %newField )
{
   %fields = ("" $= %fields) ?  %newField : %newField TAB %fields;
   return %fields;
}

function pushFieldBack( %fields , %newField )
{
   %fields = ("" $= %fields) ?  %newField : %fields TAB %newField;
   return %fields;
}

function popFieldFront( %fields )
{
   %fieldCount = getFieldCount( %fields );

   switch( %fieldCount )
   {
   case 0: return "";
   case 1: return "";
   default:
      %fields = getFields( %fields , 1 );
      return ( trim( %fields ) );
   }
}

function popFieldBack( %fields )
{
   %fieldCount = getFieldCount( %fields );

   switch( %fieldCount )
   {
   case 0: return "";
   case 1: return "";
   default:
      %fields = getFields( %fields , 0 , %fieldCount-2 );
      return ( trim( %fields ) );
   }
}
