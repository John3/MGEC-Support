#include "console/simBase.h"

// 1 - Include this directory to get ALL math features
#include "math/mMath.h" 

void dumpMatrix( const char* message , MatrixF & theMatrix )
{
	Con::printf("%s", message );

	// Row 0
	Con::printf("%04.2f %04.2f %04.2f %04.2f", 
		         theMatrix[MatrixF::idx( 0 , 0 )],
		         theMatrix[MatrixF::idx( 1 , 0 )],
		         theMatrix[MatrixF::idx( 2 , 0 )],
		         theMatrix[MatrixF::idx( 3 , 0 )] );
	// Row 1
	Con::printf("%04.2f %04.2f %04.2f %04.2f", 
		         theMatrix[MatrixF::idx( 0 , 1 )],
		         theMatrix[MatrixF::idx( 1 , 1 )],
		         theMatrix[MatrixF::idx( 2 , 1 )],
		         theMatrix[MatrixF::idx( 3 , 1 )] );
	// Row 2
	Con::printf("%04.2f %04.2f %04.2f %04.2f", 
		         theMatrix[MatrixF::idx( 0 , 2 )],
		         theMatrix[MatrixF::idx( 1 , 2 )],
		         theMatrix[MatrixF::idx( 2 , 2 )],
		         theMatrix[MatrixF::idx( 3 , 2 )] );
	// Row 3
	Con::printf("%04.2f %04.2f %04.2f %04.2f\n", 
		         theMatrix[MatrixF::idx( 0 , 3 )],
		         theMatrix[MatrixF::idx( 1 , 3 )],
		         theMatrix[MatrixF::idx( 2 , 3 )],
		         theMatrix[MatrixF::idx( 3 , 3 )] );
}

ConsoleFunction(ch10_exer_009a, void, 1, 1, "")
{
	MatrixF tMatrix; // Translation Matrix
	MatrixF rMatrix; // Rotation Matrix
	MatrixF sMatrix; // Scaling Matrix

	tMatrix.identity();
	rMatrix.identity();
	sMatrix.identity();

	Point3F tVec( 3.0f , 4.0f, 5.0f );                            // Translation vector
	Point3F rVec( mDegToRad( 70.0f ), 0.0f, mDegToRad( 32.1f ) ); // Rotation vector
	Point3F sVec( 3.0f , 4.0f, 5.0f );                            // Scaling vector

	tMatrix.setPosition( tVec ); // Set translation matrix
	rMatrix.set( rVec );         // Set rotation matrix
	sMatrix.scale( sVec );       // Set scaling matrix

	dumpMatrix( "   Translation Matrix", tMatrix );
	dumpMatrix( "      Rotation Matrix", rMatrix );
	dumpMatrix( "       Scaling Matrix", sMatrix );
}

ConsoleFunction(ch10_exer_009b, void, 1, 1, "")
{
	MatrixF tMatrix; // Translation Matrix
	MatrixF rMatrix; // Rotation Matrix
	MatrixF sMatrix; // Scaling Matrix

	tMatrix.identity();
	rMatrix.identity();
	sMatrix.identity();

	Point3F tVec( 3.0f , 4.0f, 5.0f );              // Translation vector
	Point3F rVec( 0.0f, 0.0f, mDegToRad( 32.1f ) ); // Rotation vector
	Point3F sVec( 3.0f , 4.0f, 5.0f );              // Scaling vector

	// Set up translation matrix manually
	tMatrix[MatrixF::idx( 3 , 0 )] = tVec.x;
	tMatrix[MatrixF::idx( 3 , 1 )] = tVec.y;
	tMatrix[MatrixF::idx( 3 , 2 )] = tVec.z;

	// Set up rotation matrix manually
	// Temporary X-Axis rotation matrix 
	MatrixF xMatrix; 
	xMatrix.identity();
	xMatrix[MatrixF::idx( 1 , 1 )] = mCos( mDegToRad( 70.0f ) );
	xMatrix[MatrixF::idx( 1 , 2 )] = -mSin( mDegToRad( 70.0f ) );
	xMatrix[MatrixF::idx( 2 , 1 )] = mSin( mDegToRad( 70.0f ) );
	xMatrix[MatrixF::idx( 2 , 2 )] = mCos( mDegToRad( 70.0f ) );

	// Temporary Z-Axis rotation matrix 
	MatrixF zMatrix; 
	zMatrix.identity();
	zMatrix[MatrixF::idx( 0 , 0 )] = mCos( mDegToRad( 32.1f ) );
	zMatrix[MatrixF::idx( 0 , 1 )] = -mSin( mDegToRad( 32.1f ) );
	zMatrix[MatrixF::idx( 1 , 0 )] = mSin( mDegToRad( 32.1f ) );
	zMatrix[MatrixF::idx( 1 , 1 )] = mCos( mDegToRad( 32.1f ) );
	
	// Combine Rotation
	rMatrix.mul( xMatrix );
	rMatrix.mul( zMatrix );

	// Set up scaling matrix manually
	sMatrix[MatrixF::idx( 0 , 0 )] = sVec.x;
	sMatrix[MatrixF::idx( 1 , 1 )] = sVec.y;
	sMatrix[MatrixF::idx( 2 , 2 )] = sVec.z;

	dumpMatrix( "Translation Matrix", tMatrix );
	dumpMatrix( "   Rotation Matrix", rMatrix );
	dumpMatrix( "    Scaling Matrix", sMatrix );
}

ConsoleFunction(ch10_exer_009c, void, 1, 1, "")
{
	MatrixF tMatrix; // Translation Matrix
	MatrixF rMatrix; // Rotation Matrix
	MatrixF sMatrix; // Scaling Matrix

	MatrixF workMatrix; 

	tMatrix.identity();
	rMatrix.identity();
	sMatrix.identity();

	Point3F tVec( 3.0f , 4.0f, 5.0f );               // Translation vector
	Point3F rVec( 0.0f , 0.0f, mDegToRad( 45.0f ) ); // Rotation vector
	Point3F sVec( 3.0f , 4.0f, 5.0f );               // Scaling vector

	tMatrix.setPosition( tVec ); // Set translation matrix
	rMatrix.set( rVec );         // Set rotation matrix
	sMatrix.scale( sVec );       // Set scaling matrix

	// A Initialize, then apply Rotation, Scaling, and Translation to work vector
	workMatrix.identity();
	workMatrix.mul( rMatrix );
	workMatrix.mul( sMatrix );
	workMatrix.mul( tMatrix );
	dumpMatrix( "A - rot -> scal -> trans ", workMatrix );

	// B Initialize, then apply Translation, Scaling, and Rotation to work vector
	workMatrix.identity();
	workMatrix.mul( tMatrix );
	workMatrix.mul( sMatrix );
	workMatrix.mul( rMatrix );
	dumpMatrix( "B - trans -> scal -> rot ", workMatrix );

	// C Initialize, then apply Scaling, Rotation, and Translation to work vector
	workMatrix.identity();
	workMatrix.mul( sMatrix );
	workMatrix.mul( rMatrix );
	workMatrix.mul( tMatrix );
	dumpMatrix( "C - scal -> rot -> trans ", workMatrix );

	// D Initialize, then apply Scaling, Translation, and Rotation to work vector
	workMatrix.identity();
	workMatrix.mul( sMatrix );
	workMatrix.mul( tMatrix );
	workMatrix.mul( rMatrix );
	dumpMatrix( "D - scal -> trans -> rot ", workMatrix );

}
