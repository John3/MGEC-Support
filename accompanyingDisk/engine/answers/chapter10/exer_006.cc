#include "console/simBase.h"
#include <string.h>
#include <ctype.h> 

ConsoleFunction(ch10_exer_006, const char *, 3, 3, "ch10_exer_006( string1 , string2 )")
{
	char *newString = Con::getReturnBuffer(256);
	const char *string1 = argv[1];
	const char *string2 = argv[2];

	// Concatenate the strings
   S32   len1 = dStrlen(string1);
	S32   len2 = dStrlen(string2);

	if( (len1 + len2) > 255 ) return NULL;

   dMemcpy(newString, string1, len1);

	dMemcpy(newString + len1 , string2, len2);

	newString[len1+len2] = '\0';

	// Convert all characters to upper case
	for(int i = 0; i<256;i++)
	{
		newString[i] = dToupper(newString[i]);
	}
	// could have used this function instead of above loop:
	//    dStrupr( newString );

	// do rudimentary leetspeak conversion
	for(int i = 0; i<256;i++)
	{
		switch( newString[i] ) {
		case 'O': 
			newString[i] = '0';
			break;
		case 'D': 
			newString[i] = '0';
			break;

		case 'I': 
			newString[i] = '1';
			break;
		case 'T': 
			newString[i] = '1';
			break;

		case 'E': 
			newString[i] = '3';
			break;
		case 'B': 
			newString[i] = '3';
			break;

		case 'Z': 
			newString[i] = '2';
			break;
		case 'R': 
			newString[i] = '2';
			break;

		case 'G': 
			newString[i] = '6';
			break;

		case 'L': 
			newString[i] = '1';
			break;
		}
	}
	return newString;
}


