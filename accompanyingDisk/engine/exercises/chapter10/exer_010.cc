#include "console/simBase.h"

ConsoleFunction(ch10_exer_010, void, 1, 1, "")
{
	const char * string1 = "Hello World!";
	const char * string2 = "Hello World! IGNORE THIS";
	const char * string3 = "HELLO WORLD!";

	StringTableEntry myString1;
	StringTableEntry myString2;

	U32 hash1;
	U32 hash2;

	// Add the above const char * strings in different ways
	StringTable->insert(string1);
	StringTable->insertn(string2, 12);
	StringTable->insert(string3, true);


	// Do some tests
	// 1 
	myString1 = StringTable->lookup( string1 );
	Con::printf("Test 1: string1 found? %s", (myString1) ? "YES" : "NO" );

	// 2 
	myString1 = StringTable->lookup( string2 );
	Con::printf("Test 2: string2 found? %s", (myString1) ? "YES" : "NO" );

	// 3 
	myString1 = StringTable->lookup( string3 );
	Con::printf("Test 3: string1 found? %s", (myString1) ? "YES" : "NO" );

	// 4
	myString1 = StringTable->lookup( string1 );
	Con::printf("Test 4: Same string? %s", (myString1 == string1) ? "YES" : "NO" );

	// 5
	myString1 = StringTable->lookup( string3 );
	Con::printf("Test 5: Same string? %s", (myString1 == string3) ? "YES" : "NO" );

	// 6
	myString1 = StringTable->lookup( string1 );
	myString2 = StringTable->lookup( string3 );
	Con::printf("Test 6: Same string? %s", (myString1 == myString2) ? "YES" : "NO" );

	// 7
	myString1 = StringTable->lookup( string1 );
	myString2 = StringTable->lookup( string3 , true );
	Con::printf("Test 7: Same string? %s", (myString1 == myString2) ? "YES" : "NO" );

	// 8
	hash1 = StringTable->hashString( string1 );
	hash2 = StringTable->hashString( string2 );
	Con::printf("Test 8: Same hash? %s", (hash1 == hash2) ? "YES" : "NO" );

	// 9
	hash1 = StringTable->hashString( string1 );
	hash2 = StringTable->hashStringn( string2 , 12);
	Con::printf("Test 9: Same hash? %s", (hash1 == hash2) ? "YES" : "NO" );

}

