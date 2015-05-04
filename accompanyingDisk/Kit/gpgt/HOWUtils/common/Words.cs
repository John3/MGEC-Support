//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
echo("\n--------- Loading Word Utilities ---------");

// Some utilties for modifying strings of words
//
// swapWords - Swaps two words is string
// randomizeWords - Randmomizes locations of words in string
//
function swapWords( %words, %first, %second )
{
	%numWords = getWordCount(%words);

	if( ! ( ( 0 == %numWords) ||
		(%first < 0) ||
		(%first >= %numWords)  ||
		(%second < 0)  ||
		(%second >= %numWords) ||
		( %first == %second) ) )
	{
		%tmp = getWord( %words , %first );
		%words = setWord( %words , %first , getWord( %words , %second ) );
		%words = setWord( %words , %second , %tmp );

	}

	return %words;
}

function randomizeWords( %words , %iterations )
{
	%numWords = getWordCount(%words);
	if( 0 == %numWords) return "";
	for( %count = 0; %count < %iterations ; %count++) {
		%first  = getRandom( 0 , %numWords - 1 );
		%second = getRandom( 0 , %numWords - 1 );
		%words = swapWords( %words, %first, %second );
	}
	return %words;
}

function sortWords( %words , %descending )
{
   %tmpArray = new scriptObject( arrayObject );
      
   %tmpTokens = %words;
   
   while( "" !$= %tmpTokens ) 
   {
      %tmpTokens = nextToken( %tmpTokens , "theToken" , " " );
      %tmpArray.addEntry( %theToken );      
   }
   
   %tmpArray.sort( %descending );
   
   %entries = %tmpArray.getCount();
   
   for( %count = 0; %count < %entries; %count++ )
   {
      %newWords = %newWords SPC %tmpArray.getEntry( %count );
   }
   
   %newWords = trim( %newWords );
   
   %tmpArray.delete();
   
   return %newWords;
}


function isUniqueWord( %words , %newWord )
{
   //
   // Find and replace the old name
   //
   %tmpWords = %words; 
   
   %isUnique = true;  

   while( "" !$= %tmpWords ) 
   {
      %tmpWords = nextToken( %tmpWords , "theToken" , " " );
      
      if (%theToken $= %newWord) %isUnique = false;
   }
   
   return( %isUnique );
}


function addUniqueWord( %words , %newWord )
{
   //
   // Find and replace the old name
   //
   %tmpWords = %words; 
   
   %isUnique = true;  

   while( "" !$= %tmpWords ) 
   {
      %tmpWords = nextToken( %tmpWords , "theToken" , " " );
      
      if (%theToken $= %newWord) %isUnique = false;
   }
   
   if( !%isUnique ) return %words;
   
   %newWords = %words SPC %newWord;
   
   %newWords = trim ( %newWords );
   
   return %newWords;
}

function replaceWord( %words , %oldWord, %newWord )
{
   //
   // Find and replace the old name
   //
   %tmpWords = %words;   

   while( "" !$= %tmpWords ) 
   {
      %tmpWords = nextToken( %tmpWords , "theToken" , " " );
      
      %word = (%theToken $= %oldWord) ? %newWord : %theToken;
      
      %newWords = %newWords SPC %word;
   }
   
   %newWords = trim ( %newWords );
   
   return %newWords;
}

function removeWord( %words , %oldWord , %firstOnly )
{
   //
   // Find and replace the old name
   //
   %tmpWords = %words;   

   while( "" !$= %tmpWords ) 
   {
      %tmpWords = nextToken( %tmpWords , "theToken" , " " );
      
      if ( ( %theToken $= %oldWord ) && !(%firstOnly && %removed) )
      {
         // Nothing
         %removed = true;
      }
      else
      {
         %newWords = %newWords SPC %theToken;
      }

   }
   
   %newWords = trim ( %newWords );
   
   return %newWords;
}

function pushWordFront( %words , %newWord )
{
   %words = ("" $= %words) ?  %newWord : %newWord SPC %words;
   return %words;
}

function pushWordBack( %words , %newWord )
{
   %words = ("" $= %words) ?  %newWord : %words SPC %newWord;
   return %words;
}

function popWordFront( %words )
{
   %wordCount = getWordCount( %words );

   switch( %wordCount )
   {
   case 0: return "";
   case 1: return "";
   default:
      %words = getWords( %words , 1 );
      return ( trim( %words ) );
   }
}

function popWordBack( %words )
{
   %wordCount = getWordCount( %words );

   switch( %wordCount )
   {
   case 0: return "";
   case 1: return "";
   default:
      %words = getWords( %words , 0 , %wordCount-2 );
      return ( trim( %words ) );
   }
}




