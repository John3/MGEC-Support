//------------------------------------------------------
// Copyright 2003-2007, Hall Of Worlds, LLC.
//------------------------------------------------------
echo("\n--------- Loading Math Utilities ---------");

function checkPointInBox( %point , %box , %scale ) 
{
   // Re-scale box if requested
   if( ( %scale !$= "" ) && ( %scale != 1.0 ) )
   {
      %boxUL = getWords( %box , 0 , 1 );
      %boxLR = getWords( %box , 2 , 3 );
      %box   = t2DVectorScale( %boxUL , %scale ) SPC t2DVectorScale( %boxLR , %scale );
   }
   
   %ulx = getWord( %box , 0 );
   %uly = getWord( %box , 1 );
   %lrx = getWord( %box , 2 );
   %lry = getWord( %box , 3 );
   
   %px = getWord( %point , 0 );
   %py = getWord( %point , 1 );
   
   return( (%px >= %ulx) && (%py >= %uly) && (%px <= %lrx) && (%py <= %lry) );   
}

function angleToVector( %angle )
{
   %x = mFloatLength(mSin(mDegToRad(%angle)),3);
   %y = mFloatLength(-mCos(mDegToRad(%angle)),3);
   return %x SPC %y;
}


function vectorToAngle( %vector ) 
{ 
   %initialAngle = t2dAngleBetween( "0.0 -1.0" , %vector);
   
   %right = ( t2dVectorDot( "1.0 0.0" , %vector ) >= 0 ) ? 1 : 0;
   
   return  %right ? %initialAngle : 360.0 - %initialAngle;
}

// FOR CONSOLE: Since you can't type ~
function inv( %val )
{
   return ~%val;
}


function calculateCentroid( %pointList )
{
   // NO POINTS CASE
   if ("" $= %pointList) 
      return ""; 
      
   %totalPoints = getWordCount( %pointList );      

   // ONE POINT CASE (IS CENTROID)
   if ( %totalPoints == 2 ) 
      return %pointList;  

   // TWO POINTS CASE (CENTROID IS POINT ON LINE BETWEEN)
   if ( %totalPoints == 4 ) 
   {
      // Centroid is point in middle of line
      return t2dVectorScale( t2dVectorAdd( getWords( %pointList , 0 , 1 ) , getWords( %pointList , 2 , 3 ) ) , 0.5 );
   }
   
   // THREE POINTS CASE (CENTROID IS SUM OF POINTS / 3)
   if ( %totalPoints == 6 ) 
   {
      %Ax = getWord( %pointList , 0 );
      %Ay = getWord( %pointList , 1 );
      %Bx = getWord( %pointList , 2 );
      %By = getWord( %pointList , 3 );
      %Cx = getWord( %pointList , 4 );
      %Cy = getWord( %pointList , 5 );
      
      %centroid = t2dVectorAdd( %Ax SPC %Ay , %Bx SPC %By );
      %centroid = t2dVectorAdd( %centroid   , %Cx SPC %Cy );
      %centroid = t2dVectorScale( %centroid , 1/3 );

      return %centroid;
   }
   
   // N > 3 N-POLYGON CASE (CENTROID IS SUM OF TRIANGLE CENTROIDS OVER FRACTIONS OF AREA SUMS)
   // http://www.saltspring.com/brochmann/math/centroid/centroid.html 

   // WARNING!!! REQUIRES TRAVERSAL OF CONSECUTIVE EDGES, WILL FAIL FOR RANDOM TRAVERSALS
   // WARNING!!! REQUIRES TRAVERSAL OF CONSECUTIVE EDGES, WILL FAIL FOR RANDOM TRAVERSALS
   // WARNING!!! REQUIRES TRAVERSAL OF CONSECUTIVE EDGES, WILL FAIL FOR RANDOM TRAVERSALS

   for( %count = 4 ; %count < %totalPoints; %count+=2 )
   {
      %Ax = getWord( %pointList , 0 );
      %Ay = getWord( %pointList , 1 );
      %Bx = getWord( %pointList , %count-2 );
      %By = getWord( %pointList , %count-1 );
      %Cx = getWord( %pointList , %count );
      %Cy = getWord( %pointList , %count+1 );
      
      %centroid = t2dVectorAdd( %Ax SPC %Ay , %Bx SPC %By );
      %centroid = t2dVectorAdd( %centroid   , %Cx SPC %Cy );
      %centroid = t2dVectorScale( %centroid , 1/3 );
      %centroidList = %centroidList SPC %centroid;

      %triangleArea = mAbs( (%Bx * %Ay - %Ax * %By ) + ( %Cx * %By - %Bx * %Cy ) + ( %Ax * %Cy - %Cx * %Ay ) ) / 2;
      %triangleAreaList = %triangleAreaList SPC %triangleArea;

      %polyArea = %polyArea + %triangleArea;
   }

   %centroidList = trim( %centroidList );
   %triangleAreaList = trim( %triangleAreaList );
   
   %areaListCount = getWordCount( %triangleAreaList );
   for(%count = 0; %count < %areaListCount ; %count++ )
   {
      %areaFractionList = %areaFractionList SPC ( getWord( %triangleAreaList , %count ) / %polyArea );
   }
   %areaFractionList = trim( %areaFractionList );
   
   %centroidListCount = getWordCount( %centroidList );

   %centroid = "0 0";
   for( %count = 0 ; %count < %centroidListCount / 2 ; %count++ )
   {
      %triangleFraction = getWord( %areaFractionList , %count ) ;
      %Ax = getWord( %centroidList , %count * 2 ) * %triangleFraction;
      %Ay = getWord( %centroidList , %count * 2 + 1) * %triangleFraction;
      %centroid = t2dVectorAdd( %centroid ,  (%Ax SPC %Ay ) );
   }
   error( %centroidList );
   error( %triangleAreaList );
   error( %polyArea );
   error( %areaFractionList );
   return %centroid;

}



function RotateVectorOnZ(%Vec,%angle)
{        
   %X = GetWord(%Vec,0);
   %Y = GetWord(%Vec,1);
   %Z = GetWord(%Vec,2);
   %rdAngle=mDegToRad(%angle);
   %rX = (%X*mCos(%rdAngle))-(%Y*mSin(%rdAngle));
   %rY = (%X*mSin(%rdAngle))+(%Y*mCos(%rdAngle));
   %rZ = %Z;
   return %rX SPC %rY SPC %rZ;
}

function RotateVectorOnY(%Vec,%angle)
{
   %X = GetWord(%Vec,0);
   %Y = GetWord(%Vec,1);
   %Z = GetWord(%Vec,2);
   %rdAngle=mDegToRad(%angle);
   %rX = (%X*mCos(%rdAngle))+(%Z*mSin(%rdAngle));
   %rY = %Y;
   %rZ = (%X*mSin(%rdAngle))-(%Z*mCos(%rdAngle));
   return %rX SPC %rY SPC %rZ;
}

function RotateVectorOnX(%Vec,%angle)
{
   %X = GetWord(%Vec,0);
   %Y = GetWord(%Vec,1);
   %Z = GetWord(%Vec,2);
   %rdAngle=mDegToRad(%angle);
   %rX = %X;
   %rY = (%X*mCos(%rdAngle))-(%Y*mSin(%rdAngle));
   %rZ = (%X*mSin(%rdAngle))+(%Y*mCos(%rdAngle));
   return %rX SPC %rY SPC %rZ;
}

