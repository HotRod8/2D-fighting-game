#include <SFML/Graphics.hpp>
#include <string>

class Game
{
public:

	//****************************
	// Constructors / Destructor *
	//****************************

	Game(const std::string& title, const unsigned int& resolutionWidth, const unsigned int& resolutionHeight, const unsigned int& frameRate);
	// Stores the specified parameters in the appropriate member data.

	~Game();
	// Deallocation when the window is closed.

	//************
	// Functions *
	//************

	void launch();
	// Creates a window with the stored title, resolution, and framerate specified from the constructor call.

protected:

	//*******
	// Data *
	//*******

	sf::RenderWindow* window;
	std::string	title;
	unsigned int resolutionWidth;
	unsigned int resolutionHeight;
	unsigned int frameRate;
};