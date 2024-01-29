#ifndef _ASSETMANAGER_H
#define _ASSETMANAGER_H

#include<SFML/Graphics.hpp>
#include<SFML/Audio.hpp>
#include<unordered_map>
#include<string>
#include<iostream>

using std::unordered_map;
using std::string;
using std::cout;
using std::endl;
using sf::Image;
using sf::Texture;
using sf::Sound;
using sf::SoundBuffer;
using sf::Music;

class AssetManager {
public:
    Texture defTexture; //default texture used for error checking

    AssetManager();
    //Background music
    void addMusic(string key, string filename);
    void removeMusic(string key);
    Music& getMusic(string key);
    void makeMusicPath(const string& filename);
    //Sound effects
    void addSound(string key, string filename);
    void removeSound(string key);
    const Sound& getSound(string key);
    void makeSoundEffectsPath(const string& filename);
    //Textures for Sprites
    void addTexture(string key, string filepath);
    void removeTexture(string key);
    const Texture& getTexture(string key); //Const reference for cost effectiveness
    void makeTexturePath(const string& path);
    //Image lib has the flipHorizontal, loadFromFile, and saveToFile functions. Use'm.
private:
    unordered_map<string, Texture> textureMap;
    unordered_map<string, SoundBuffer> audioMap;
    unordered_map<string, Music> musicMap;
    string texturePath;
    string musicPath;
    string soundEffectsPath;
};

#endif // !1