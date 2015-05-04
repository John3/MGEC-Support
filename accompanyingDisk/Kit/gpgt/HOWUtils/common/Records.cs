//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
echo("\n--------- Loading Record Utilities ---------");

// Some utilties for modifying strings of records
//
// swapRecords - Swaps two records is string
// randomizeRecords - Randmomizes locations of records in string
//
function swapRecords( %records, %first, %second )
{
	%numRecords = getRecordCount(%records);

	if( ! ( ( 0 == %numRecords) ||
		(%first < 0) ||
		(%first >= %numRecords)  ||
		(%second < 0)  ||
		(%second >= %numRecords) ||
		( %first == %second) ) )
	{
		%tmp = getRecord( %records , %first );
		%records = setRecord( %records , %first , getRecord( %records , %second ) );
		%records = setRecord( %records , %second , %tmp );

	}

	return %records;
}

function randomizeRecords( %records , %iterations )
{
	%numRecords = getRecordCount(%records);
	if( 0 == %numRecords) return "";
	for( %count = 0; %count < %iterations ; %count++) {
		%first  = getRandom( 0 , %numRecords - 1 );
		%second = getRandom( 0 , %numRecords - 1 );
		%records = swapRecords( %records, %first, %second );
	}
	return %records;
}

function sortRecords( %records , %descending )
{
   %tmpArray = new scriptObject( arrayObject );
      
   %tmpTokens = %records;
   
   while( "" !$= %tmpTokens ) 
   {
      %tmpTokens = nextToken( %tmpTokens , "theToken" , "\n" );
      %tmpArray.addEntry( %theToken );      
   }
   
   %tmpArray.sort( %descending );
   
   %entries = %tmpArray.getCount();
   
   for( %count = 0; %count < %entries; %count++ )
   {
      %newRecords = %newRecords NL %tmpArray.getEntry( %count );
   }
   
   %newRecords = trim( %newRecords );
   
   %tmpArray.delete();
   
   return %newRecords;
}


function isUniqueRecord( %records , %newRecord )
{
   //
   // Find and replace the old name
   //
   %tmpRecords = %records; 
   
   %isUnique = true;  

   while( "" !$= %tmpRecords ) 
   {
      %tmpRecords = nextToken( %tmpRecords , "theToken" , "\n" );
      
      if (%theToken $= %newRecord) %isUnique = false;
   }
   
   return( %isUnique );
}


function addUniqueRecord( %records , %newRecord )
{
   //
   // Find and replace the old name
   //
   %tmpRecords = %records; 
   
   %isUnique = true;  

   while( "" !$= %tmpRecords ) 
   {
      %tmpRecords = nextToken( %tmpRecords , "theToken" , "\n" );
      
      if (%theToken $= %newRecord) %isUnique = false;
   }
   
   if( !%isUnique ) return %records;
   
   %newRecords = %records NL %newRecord;
   
   %newRecords = trim ( %newRecords );
   
   return %newRecords;
}

function replaceRecord( %records , %oldRecord, %newRecord )
{
   //
   // Find and replace the old name
   //
   %tmpRecords = %records;   

   while( "" !$= %tmpRecords ) 
   {
      %tmpRecords = nextToken( %tmpRecords , "theToken" , "\n" );
      
      %record = (%theToken $= %oldRecord) ? %newRecord : %theToken;
      
      %newRecords = %newRecords NL %record;
   }
   
   %newRecords = trim ( %newRecords );
   
   return %newRecords;
}

function removeRecord( %records , %oldRecord , %firstOnly )
{
   //
   // Find and replace the old name
   //
   %tmpRecords = %records;   

   while( "" !$= %tmpRecords ) 
   {
      %tmpRecords = nextToken( %tmpRecords , "theToken" , "\n" );
      
      if ( ( %theToken $= %oldRecord ) && !(%firstOnly && %removed) )
      {
         // Nothing
         %removed = true;
      }
      else
      {
         %newRecords = %newRecords NL %theToken;
      }

   }
   
   %newRecords = trim ( %newRecords );
   
   return %newRecords;
}

function pushRecordFront( %records , %newRecord )
{
   %records = ("" $= %records) ?  %newRecord : %newRecord NL %records;
   return %records;
}

function pushRecordBack( %records , %newRecord )
{
   %records = ("" $= %records) ?  %newRecord : %records NL %newRecord;
   return %records;
}

function popRecordFront( %records )
{
   %recordCount = getRecordCount( %records );

   switch( %recordCount )
   {
   case 0: return "";
   case 1: return "";
   default:
      %records = getRecords( %records , 1 );
      return ( trim( %records ) );
   }
}

function popRecordBack( %records )
{
   %recordCount = getRecordCount( %records );

   switch( %recordCount )
   {
   case 0: return "";
   case 1: return "";
   default:
      %records = getRecords( %records , 0 , %recordCount-2 );
      return ( trim( %records ) );
   }
}

