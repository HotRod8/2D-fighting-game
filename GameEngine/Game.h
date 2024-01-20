#ifndef _GAME_H
#define _GAME_H 

#include <SFML/Graphics.hpp>
#include <string>

class Game
{
public:

	//****************************
	// Constructors / Destructor *
	//****************************

	Game(const std::string& title, const int& resolutionWidth, const int& resolutionHeight, const int& frameRate);
	// Stores the specified parameters for the sf::RenderWindow in the appropriate member data.

	~Game();
	// Deallocation when the window is closed.

	//************
	// Functions *
	//************

	void launch();
	// Creates a window with the stored title, resolution, and framerate specified from the constructor call.

private:

	//*******
	// Data *
	//*******

	sf::RenderWindow*	window;
	std::string			title;
	int					resolutionWidth;
	int					resolutionHeight;
	int					frameRate;
};

#endif