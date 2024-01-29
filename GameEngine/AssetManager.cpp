#include"AssetManager.h"

AssetManager::AssetManager() : texturePath("./Assets/Images/"), soundEffectsPath("./Assets/Audio/Sound_Effects/"), musicPath("./Assets/Audio/Music/")
{
    defTexture.loadFromFile(texturePath + "error_texture.png");
}


void AssetManager::addMusic(string key, string filename)
{
    if (!musicMap[key].openFromFile(musicPath + filename))
    {
        cout << "Unable to open sound file." << endl;
    }
}
void AssetManager::removeMusic(string key) {
    if (musicMap[key].getStatus() != sf::Music::Status::Stopped)
        musicMap[key].stop();
    musicMap.erase(key);
}
Music& AssetManager::getMusic(string key) {
    return musicMap[key];
}
void AssetManager::makeMusicPath(const string& path) {
    musicPath = path;
}

void AssetManager::addSound(string key, string filename)
{
    if (!audioMap[key].loadFromFile(soundEffectsPath + filename))
    {
        cout << "Unable to open sound file." << endl;
    }
}
void AssetManager::removeSound(string key) {
    Sound(audioMap[key]).stop();
    audioMap.erase(key);
}
const Sound& AssetManager::getSound(string key) {
    return Sound(audioMap[key]);
}
void AssetManager::makeSoundEffectsPath(const string& path) {
    soundEffectsPath = path;
}

void AssetManager::makeTexturePath(const string& path)
{
    texturePath = path;
}
void AssetManager::addTexture(string key, string filename)
{
    if (!textureMap[key].loadFromFile(texturePath + filename))
    {
        textureMap[key] = defTexture;
    }
}
void AssetManager::removeTexture(string key) {
    textureMap.erase(key);
}
const Texture& AssetManager::getTexture(string key) {
    return textureMap[key];
}