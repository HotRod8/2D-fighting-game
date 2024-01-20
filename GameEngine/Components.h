#ifndef _COMPONENTS_H
#define _COMPONENTS_H

#include <SFML/Graphics.hpp>
#include "Vector2D.h"

struct Collision
{

};

struct Input
{
	//*******
	// Data *
	//*******

	bool left;
	bool right;
	bool up;
	bool down;
	bool shoot;

	//***************
	// Constructors *
	//***************

	Input() : left(false), right(false), up(false), down(false), shoot(false) {}
};

struct Lifespan
{
	//*******
	// Data *
	//*******

	int lifespan;		// the number of frames this life remains
	int frameCreated;

	//***************
	// Constructors *
	//***************

	Lifespan(const int& duration = 0, const int& frameCreated = 0)
		: lifespan(duration), frameCreated(frameCreated) {}
};

struct Score
{
	//*******
	// Data *
	//*******
	
	int score;

	//***************
	// Constructors *
	//***************

	Score(const int& s = 0) : score(s) {}
};

struct Shape
{
	//*******
	// Data *
	//*******

	sf::CircleShape circle;

	//***************
	// Constructors *
	//***************

	Shape(const float& radius, const int& points, const sf::Color& fillColor, const sf::Color& outlineColor, const float& outlineThickness)
		: circle(radius, points)
	{
		circle.setFillColor(fillColor);
		circle.setOutlineColor(outlineColor);
		circle.setOutlineThickness(outlineThickness);
		circle.setOrigin(radius, radius);
	}
};

struct Transform
{
	//*******
	// Data *
	//*******

	Vector2D position = { 0.0, 0.0 };
	Vector2D velocity = { 0.0, 0.0 };
	float angle = 0;

	//***************
	// Constructors *
	//***************

	Transform(const Vector2D& position, const Vector2D& velocity, const float& angle)
		: position(position), velocity(velocity), angle(angle) {}
};

#endif