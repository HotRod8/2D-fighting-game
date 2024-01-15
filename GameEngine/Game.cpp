#include "Game.h"

//****************************
// Constructors / Destructor *
//****************************

Game::Game(const std::string& title, const unsigned int& resolutionWidth, const unsigned int& resolutionHeight, const unsigned int& frameRate)
// Stores the specified parameters in the appropriate member data.
	: window(nullptr), title(title), resolutionWidth(resolutionWidth), resolutionHeight(resolutionHeight), frameRate(frameRate)
{

}

Game::~Game()
{
	delete window;
}

void Game::launch()
// Creates a window with the stored title, resolution, and framerate specified from the constructor call.
{
	window = new sf::RenderWindow(sf::VideoMode(resolutionWidth, resolutionHeight), title);

	window->setFramerateLimit(frameRate);
	
	while (window->isOpen())
	{
		sf::Event event;

		window->pollEvent(event);

		if (event.type == sf::Event::Closed)
		{
			window->close();
		}

		window->clear();
		window->display();
	}
}