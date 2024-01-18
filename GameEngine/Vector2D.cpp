#include "Vector2D.h"
#include <cmath>

//*********************
// Operator Overloads *
//*********************

std::ostream& operator<<(std::ostream& os, const Vector2D& v)
// Outputs this Vector2D as: (x, y).
{
	os << '(' << v.x << ", " << v.y << ')';
	return os;
}

Vector2D operator*(const Vector2D& v1, const Vector2D& v2)
// Returns a Vector2D whose x and y values are the product of the
// x and y values of the specified Vector2D's.
{
	return Vector2D(v1.x * v2.x, v1.y * v2.y);
}

Vector2D operator/(const Vector2D& v1, const Vector2D& v2)
// Returns a Vector2D whose x and y values are the quotient of the
// x and y values of the specified Vector2D's.
{
	if (v2.x == 0 || v2.y == 0)
		return v1;
	
	return Vector2D(v1.x / v2.x, v1.y / v2.y);
}

Vector2D operator+(const Vector2D& v1, const Vector2D& v2)
// Returns a Vector2D whose x and y values are the sum of the x and y 
// values of the specified Vector2D's.
{
	return Vector2D(v1.x + v2.x, v1.y + v2.y);
}

Vector2D operator-(const Vector2D& v1, const Vector2D& v2)
// Returns a Vector2D whose x and y values are the difference of the
// x and y values of the specified Vector2D's.
{
	return Vector2D(v1.x - v2.x, v1.y - v2.y);
}

bool operator==(const Vector2D& v1, const Vector2D& v2)
// Returns true if the x and y values of v1 and v2 are equal.
{
	return v1.x == v2.x && v1.y == v2.y;
}

bool operator!=(const Vector2D& v1, const Vector2D& v2)
// Returns true if the x and y values of v1 and v2 are NOT equal.
{
	return v1.x != v2.x || v1.y != v2.y;
}

//***************
// Constructors *
//***************

Vector2D::Vector2D(const float& x, const float& y) : x(x), y(y)
{

}

//*********************
// Operator Overloads *
//*********************

Vector2D& Vector2D::operator*=(const Vector2D& v)
// Returns this Vector2D with x and y values that are the product of the
// x and y values of this Vector2D and v.
{
	x *= v.x;
	y *= v.y;
	return *this;
}

Vector2D& Vector2D::operator*=(const float& scale)
// Returns this scaled Vector with x and y values scaled by the
// specified amount.
{
	x *= scale;
	y *= scale;
	return *this;
}

Vector2D& Vector2D::operator/=(const Vector2D& v)
// Returns this Vector2D with x and y values that are the quotient of the
// x and y values of this Vector2D and v.
{
	if (v.x == 0 || v.y == 0)
		return *this;
	
	x /= v.x;
	y /= v.y;
	return *this;
}

Vector2D& Vector2D::operator+=(const Vector2D& v)
// Returns this Vector2D with x and y values that are the sum of the
// x and y values of this Vector2D and v2.
{
	x += v.x;
	y += v.y;
	return *this;
}

Vector2D& Vector2D::operator-=(const Vector2D& v)
// Returns this Vector2D with x and y values that are the difference of 
// the x and y values of this Vector2D and v.
{
	x -= v.x;
	y -= v.y;
	return *this;
}

//************
// Functions *
//************

Vector2D& Vector2D::add(const Vector2D& v)
// Returns this Vector2D as the sum of the x and y values of this Vector2D and the specified Vector2D.
{
	x += v.x;
	y += v.y;
	return *this;
}

Vector2D& Vector2D::add(const float& x, const float& y)
// Returns this Vector2D as the sum of the x and y values of this Vector2D and the specified x and y values.
{
	this->x += x;
	this->y += y;
	return *this;
}

float Vector2D::distance(const Vector2D& v)
// Returns the distance between this Vector2D and the specified Vector2D.
{
	return std::sqrtf((v.x - x) * (v.x - x) + (v.y - y) * (v.y - y));
}

float Vector2D::distance(const float& x, const float& y)
// Returns the distance between this Vector2D and the specified 2D coordinate.
{
	return std::sqrtf((x - this->x) * (x - this->x) + (y - this->y) * (y - this->y));
}

Vector2D& Vector2D::divide(const Vector2D& v)
// Returns this Vector2D as the quotient of the x and y values of this Vector2D and the specified Vector2D.
{
	if (v.x == 0 || v.y == 0)
		return *this;
	
	x /= v.x;
	y /= v.y;
	return *this;
}

Vector2D& Vector2D::divide(const float& x, const float& y)
// Returns this Vector2D as the quotient of the x and y values of this Vector2D and the specified x and y values.
{
	if (x == 0 || y == 0)
		return *this;
	
	this->x /= x;
	this->y /= y;
	return *this;
}

Vector2D& Vector2D::multiply(const Vector2D& v)
// Returns this Vector2D as the product of the x and y values of this Vector2D and the specified Vector2D.
{
	x *= v.x;
	y *= v.y;
	return *this;
}

Vector2D& Vector2D::multiply(const float& x, const float& y)
// Returns this Vector2D as the product of the x and y values of this Vector2D and the specified x and y values.
{
	this->x *= x;
	this->y *= y;
	return *this;
}

Vector2D& Vector2D::scale(const float& scale)
// Returns this Vector2D as the product of the x and y values of this Vector2D and the specified scale.
{
	x *= scale;
	y *= scale;
	return *this;
}

Vector2D& Vector2D::scale(const float& x, const float& y)
// Returns this Vector2D as the product of the x and y values of this Vector2D and the specified x and y scales.
{
	this->x *= x;
	this->y *= y;
	return *this;
}

Vector2D& Vector2D::subtract(const Vector2D& v)
// Returns this Vector2D as the difference of the x and y values of this Vector2D and the specified Vector2D.
{
	x -= v.x;
	y -= v.y;
	return *this;
}

Vector2D& Vector2D::subtract(const float& x, const float& y)
// Returns this Vector2D as the product of the x and y values of this Vector2D and the specified x and y values.
{
	this->x -= x;
	this->y -= y;
	return *this;
}