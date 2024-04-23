using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEditor;

public class MainMenuOptions : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;

    public GameObject mainMenu;
    public Slider music;
    public Slider gameVolume;
    public AudioMixer MusicVolMixer;
    public AudioMixer GameVolMixer;

    public KeyCode escapeKey = KeyCode.Escape;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }

        }
    }

    public void PauseGame()
    {
        mainMenu.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame()
    {
        mainMenu.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void RestartGame()
    {
        ;
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

}
