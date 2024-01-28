#include "Game.h"
#include "AssetManager.h"

//****************************
// Constructors / Destructor *
//****************************

Game::Game(const std::string& title, const int& resolutionWidth, const int& resolutionHeight, const int& frameRate)
// Stores the specified parameters in the appropriate member data.
	: window(nullptr)
	, title(title)
	, resolutionWidth(resolutionWidth)
	, resolutionHeight(resolutionHeight)
	, frameRate(frameRate)
{

}

Game::~Game()
{
	delete window;
}

//************
// Functions *
//************

void Game::launch()
// Creates a window with the stored title, resolution, and framerate specified from the constructor call.
{
    window = new sf::RenderWindow(sf::VideoMode(resolutionWidth, resolutionHeight), title);

    window->setFramerateLimit(frameRate);

    AssetManager assetManager;

    assetManager.addTexture("mario", "mario.png");
    assetManager.addSound("coin", "coin.wav");
    assetManager.addMusic("overworld", "overworld.wav");

    sf::Sprite marioSprite(assetManager.getTexture("mario"));
    sf::Sound coinSound = assetManager.getSound("coin");

    marioSprite.scale(sf::Vector2f(32, 32));

    assetManager.getMusic("overworld").play();

    while (window->isOpen())
    {
        sf::Event event;

        while (window->pollEvent(event))
        {
            if (event.type == sf::Event::Closed)
            {
                window->close();
            }

            if (event.type == sf::Event::KeyPressed)
            {
                coinSound.play();
            }
        }

        window->clear();
        window->draw(marioSprite);
        window->display();
    }
}