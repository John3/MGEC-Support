//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------

package exercisePackage_005
{
function startexercise005()
{  
}

function fadeScreenOutandIn( %start, %outTime, %waitTime, %inTime )
{
   serverConnection.schedule( %start , setBlackout , true, %outTime );

   serverConnection.schedule( %start + %outTime + %waitTime , 
                              setBlackout , false, %inTime );
}
};


