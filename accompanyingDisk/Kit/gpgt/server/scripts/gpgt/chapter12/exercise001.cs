//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
package exercisePackage_001
{
function startexercise001()
{  
   
}

function debugTest0()
{
   %local0  = 100;
   $global0 = "Torque Rocks!";
   echo("In debugTest0 %local0  == ", %local0 );
   echo("In debugTest0 $global0 == ", $global0 );
}

function debugTest1()
{
   for(%i = 0x1; %i < 0x10; %i = %i << 1 )
   {
      switch( %i )
      {
      case 0x1: 
         echo("%i == 1");
      case 0x2: 
         echo("%i == 2");
      case 0x3: 
         echo("%i == 3");
      case 0x4: 
         echo("%i == 4");
      case 0x8: 
         echo("%i == 8");
      }
   }
}

function debugTest2()
{
   for(%i = 0x0; %i < 100; %i++ )
   {
      %j = mLog( %i );
   }
}

};

