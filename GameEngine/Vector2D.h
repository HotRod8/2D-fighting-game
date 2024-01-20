#ifndef _VECTOR2D_H
#define _VECTOR2D_H

#include <iostream>

struct Vector2D
{
	//*********************
	// Operator Overloads *
	//*********************

	friend std::ostream& operator<<(std::ostream& os, const Vector2D& v);
	// Outputs this Vector2D as: (x, y).

	friend Vector2D operator*(const Vector2D& v1, const Vector2D& v2);
	// Returns a Vector2D whose x and y values are the product of the
	// x and y values of the specified Vector2D's.

	friend Vector2D operator/(const Vector2D& v1, const Vector2D& v2);
	// Returns a Vector2D whose x and y values are the quotient of the
	// x and y values of the specified Vector2D's.

	friend Vector2D operator+(const Vector2D& v1, const Vector2D& v2);
	// Returns a Vector2D whose x and y values are the sum of the x and y 
	// values of the specified Vector2D's.

	friend Vector2D operator-(const Vector2D& v1, const Vector2D& v2);
	// Returns a Vector2D whose x and y values are the difference of the
	// x and y values of the specified Vector2D's.

	friend bool operator==(const Vector2D& v1, const Vector2D& v2);
	// Returns true if the x and y values of v1 and v2 are equal.

	friend bool operator!=(const Vector2D& v1, const Vector2D& v2);
	// Returns true if the x or y values of v1 and v2 are NOT equal.

public:
	
	//*******
	// Data *
	//*******

	float x;
	float y;
	
	//***************
	// Constructors *
	//***************

	Vector2D(const float& x = 0, const float& y = 0);

	//*********************
	// Operator Overloads *
	//*********************

	void operator*=(const Vector2D& v);
	// Multiplies the x and y values of this Vector2D with the specified Vector2D.

	void operator*=(const float& scale);
	// Multiplies the x and y values of this Vector2D with the specified scale.

	void operator/=(const Vector2D& v);
	// Divides the x and y values of this Vector2D with the specified Vector2D.

	void operator+=(const Vector2D& v);
	// Adds the x and y values of this Vector2D with the specified Vector2D.

	void operator-=(const Vector2D& v);
	// Subtracts the x and y values of this Vector2D with the specified Vector2D.

	//************
	// Functions *
	//************

	Vector2D&	add(const Vector2D& v);
	// Returns this Vector2D as the sum of the x and y values of this Vector2D and the specified Vector2D.

	Vector2D&	add(const float& x, const float& y);
	// Returns this Vector2D as the sum of the x and y values of this Vector2D and the specified x and y values.

	float		distance(const Vector2D& v);
	// Returns the distance between this Vector2D and the specified Vector2D.

	float		distance(const float& x, const float& y);
	// Returns the distance between this Vector2D and the specified 2D coordinate.

	Vector2D&	divide(const Vector2D& v);
	// Returns this Vector2D as the quotient of the x and y values of this Vector2D and the specified Vector2D.

	Vector2D&	divide(const float& x, const float& y);
	// Returns this Vector2D as the quotient of the x and y values of this Vector2D and the specified x and y values.

	bool		equals(const Vector2D& v);
	// Returns true if the x and y values of this Vector2D are equal to that of the specified Vector2D.

	bool		equals(const float& x, const float& y);
	// Returns true if the x and y values of thiv Vector2D are equal to the specified x and y values.

	Vector2D&	multiply(const Vector2D& v);
	// Returns this Vector2D as the product of the x and y values of this Vector2D and the specified Vector2D.

	Vector2D&	multiply(const float& x, const float& y);
	// Returns this Vector2D as the product of the x and y values of this Vector2D and the specified x and y values.

	Vector2D&	scale(const float& scale);
	// Returns this Vector2D as the product of the x and y values of this Vector2D and the specified scale.

	Vector2D&	scale(const float& x, const float& y);
	// Returns this Vector2D as the product of the x and y values of this Vector2D and the specified x and y scales.

	Vector2D&	subtract(const Vector2D& v);
	// Returns this Vector2D as the difference of the x and y values of this Vector2D and the specified Vector2D.

	Vector2D&	subtract(const float& x, const float& y);
	// Returns this Vector2D as the product of the x and y values of this Vector2D and the specified x and y values.

	//*******
	// Test *
	//*******

	static void	test();
	// Outputs to the terminal a sample test of this class and its functionalities.
};

#endif