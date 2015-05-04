//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
echo("\n--------- Loading t2dSceneObject Utilities ---------");   

// Note: This function assumes that the new position may be anywhere in %boundsBox
// Note2: Objects that do not receive or send collisions are ignored
function getSafeSpawnPosition( %container , %size , %boundsBox , %maxIter) 
{
   %ulX = getWord( %boundsBox , 0 );
   %ulY = getWord( %boundsBox , 1 );
   %lrX = getWord( %boundsBox , 2 );
   %lrY = getWord( %boundsBox , 3 );
   
   %radius = %size / 2;
   
   %foundPosition = false;
   for( %iter = 0; (%iter < %maxIter) && ( false == %foundPosition); %iter++ )
   {
      // Randomly select a point inside the 'legal' spawn area
      %tmpX = getRandom( %ulX , %lrX );
      %tmpY = getRandom( %ulY , %lrY );

      %overlapDetected = false;
      for( %count = 0 ; (%count < %container.getCount()) && (false == %overlapDetected) ; %count++)
      {
         %obj = %container.getObject( %count );
         
         if( ( true == %obj.getCollisionActiveSend() ) || ( true == %obj.getCollisionActiveReceive() ) ) 
         {
         
            %objRadius = t2dVectorLength( %obj.getSize() ) / 2;
         
            %distanceBetween = t2dVectorLength( t2dVectorSub( %obj.getPosition(), %tmpX SPC %tmpY ) );
         
            if( %distanceBetween < (%objRadius + %radius ) ) %overlapDetected = true;
         }
      }      
      if( false == %overlapDetected ) %foundPosition = true;
   }
   
   if (true == %foundPosition ) return (%tmpX SPC %tmpY );
   return "";   
}

function calculateLinkPoints() //EFM specific to starcastle
{
   %vecLen = t2dVectorLength( "0.7 0.7" );
   %LinkPoints      = 0.0      SPC  -%vecLen SPC
                      0.7      SPC  -0.7     SPC
                      %vecLen  SPC   0.0     SPC
                      0.7      SPC   0.7     SPC
                      0.0      SPC  %vecLen  SPC
                      -0.7     SPC   0.7     SPC
                      -%vecLen SPC   0.0     SPC
                      -0.7     SPC  -0.7;
                      
   return %LinkPoints;
}
