using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionMenu : MonoBehaviour
{
    public Slider music;
    public Slider gameVolume;
    public AudioMixer musicMixer;
    public AudioMixer gameVolumeMixer;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void MusicVolume()
    {
        musicMixer.SetFloat("MusicLevel", music.value);

    }

    public void GameVolume()
    {
        gameVolumeMixer.SetFloat("GameVolLevel", gameVolume.value);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
