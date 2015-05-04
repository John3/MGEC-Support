//------------------------------------------------------
// Copyright 2003-2006, Hall Of Worlds, LLC.
//------------------------------------------------------

function autoLoad( %pathName )
{
   // Auto-load remaining files
   new ScriptObject( autoLoader );
   autoLoader.run( %pathName );
   autoLoader.delete();
}



function autoLoader::run( %this , %currentPath )
{
   
   //  Step #1 Locate all autoLoad.cs files
   %autoLoaderCount=0;

   %fileSpec =  %currentPath @ "*autoLoader.cs";

   for(%file = findFirstFile( %filespec ); %file !$= ""; %file = findNextFile(%filespec)) 
   { 
      %fileName[%autoLoaderCount] = %file;
      %autoLoaderCount++;
   }
   
   if( 0 == %autoLoaderCount ) return; // No files to auto-load
   
   // Step #2 Examine each file and determine which order to load them in.
   for( %count = 0; %count < %autoLoaderCount; %count++ )
   {
      %autoLoaderName = "";
      %autoLoaderDependencies = "";
      
      %file = readFile( %fileName[%count] );
      
      while( ( "" $= %autoLoaderName ) || ( "" $= %autoLoaderDependencies  ) )
      {
         %currentLine = getRecord( %file , 0 );
         %file = getRecords( %file , 1 );
         
         if( getWord( %currentLine , 0 ) $= "//AUTOLOADER" )
         {
            %autoLoaderName = getWord( %currentLine , 1 );
            %fileName[%count,autoLoaderName] = %autoLoaderName;
            %fileName[%autoLoaderName] = %count;
         }

         if( getWord( %currentLine , 0 ) $= "//LOADAFTER" )
         {
            %autoLoaderDependencies = getWord( %currentLine , 1 );
            
            if("NONE" !$= %autoLoaderDependencies)
            {
               %fileName[%count,autoLoaderDependencies] = %autoLoaderDependencies;
            }
         }
      }

      if( "" $= %autoLoaderName )
      {
         error("Autoloader file: ", %fileName[count], " does not identify itself!");
         error("Ex: //AUTOLOADER CORE");
         error("Aborting the autoload run requested for path: ", %currentPath);
         return;
      }
   }   
   
   // Step #3 Check for missing dependencies
   %autoLoaderDependencies = "";
   for( %count = 0; %count < %autoLoaderCount; %count++ )
   {
      if("" !$= %fileName[%count,autoLoaderDependencies]) 
      {
          %autoLoaderDependencies = %fileName[%count,autoLoaderDependencies] SPC %autoLoaderDependencies;
      }
   }
   if(strlen( %autoLoaderDependencies ) > 0 )
   {

      for( %count = 0; %count < %autoLoaderCount; %count++ )
      {
         %autoLoaderName = %fileName[%count,autoLoaderName];
         
         %autoLoaderDependencies = strreplace( %autoLoaderDependencies, %autoLoaderName , "" );
      }   
      %autoLoaderDependencies = strreplace( %autoLoaderDependencies, " " , "" );

      if(strlen( %autoLoaderDependencies ) > 0 )
      {
         error("Autoloader unable to continue dependencies missing : ", %autoLoaderDependencies );
         error("Aborting the autoload run requested for path: ", %currentPath);
         return;
      }
   }
   
   // Step #4 Load the files (loop over list till the are all loaded)
   for( %count = 0; %count < %autoLoaderCount; %count++ )
   {
      %autoLoadersRemaining = %fileName[%count,autoLoaderName] SPC %autoLoadersRemaining;
   }
   
   while( getWordCount(%autoLoadersRemaining ) > 0 )
   {
      %autoLoadersRemaining = nextToken( %autoLoadersRemaining , "%autoLoaderName" , " " );

      %count = %fileName[%autoLoaderName];
      %dependencies = %fileName[%count,autoLoaderDependencies];
    
      %loadOK = true;  
      
      // Check each dependency.  If any are still remaining to be loaded, fail 
      // this load for now
      
      while( getWordCount(%dependencies ) > 0 )
      {
         %dependencies = nextToken( %dependencies , "dependencyName" , " " );
         
         if( strstr( %autoLoadersRemaining , %dependencyName ) != -1 )
         {
            %loadOK = false;
         }
      }
      if( %loadOK )
      {
         exec( %fileName[%count] );
      }
      else
      {
         %autoLoadersRemaining = %autoLoadersRemaining SPC %autoLoaderName;
      }
   }

   %tmpTokens = nextToken( %tmpTokens , "theToken" , " " );
}

