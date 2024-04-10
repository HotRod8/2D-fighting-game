using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEditor;

public class OptionMenu : MonoBehaviour
{
    private float previousTimeScale;

    public Slider music;
    public Slider gameVolume;
    public AudioMixer MusicVolMixer;
    public AudioMixer GameVolMixer;

    public KeyCode escapeKey = KeyCode.Escape;

    // Start is called before the first frame update
    void Start()
    {
        PauseGame();
    }

    public void PauseGame()
    {
        previousTimeScale = Time.timeScale;
        Time.timeScale = 0;
    }
    public void Continue()
    {
        Time.timeScale = previousTimeScale;
        SceneManager.LoadScene("SampleScene");
    }

    public void MusicVolume()
    {
        MusicVolMixer.SetFloat("MusicLevel", music.value);

    }

    public void GameVolume()
    {
        GameVolMixer.SetFloat("GameLevel", gameVolume.value);
    }

    void Update()
    {

        if (Input.GetKeyDown(escapeKey))
        {
            Continue();
        }
    }
}
