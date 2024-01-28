#include "Game.h"
#include "AssetManager.h"
#include <string>

int main()
{   
    string  title = "2D Game";
    int     resolutionWidth = 1280;
    int     resolutionHeight = 720;
    int     frameRate = 60;
    Game    game(title, resolutionWidth, resolutionHeight, frameRate);

    game.launch();

    return 0;
}
