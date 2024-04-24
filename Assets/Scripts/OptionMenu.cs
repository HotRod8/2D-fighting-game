using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEditor;

public class OptionMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;

    public GameObject backgroundUI;
    public GameObject healthBars;
    public GameObject timer;
    public GameObject player1;
    public GameObject player2;
    public GameObject controlsMenu;


    public Slider music;
    public Slider gameVolume;
    public AudioMixer MusicVolMixer;
    public AudioMixer GameVolMixer;

    public KeyCode escapeKey = KeyCode.Escape;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (controlsMenu.activeSelf)
            {
                ReturnToPauseMenu();
            }
            else
            {
                TogglePause();
            }
        }
    }
    public void ShowControls()
    {
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }
    void ReturnToPauseMenu()
    {
        controlsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    void TogglePause()
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
    public void PauseGame()
    {
        backgroundUI.SetActive(false);
        player1.SetActive(false);
        player2.SetActive(false);
        timer.SetActive(false);
        healthBars.SetActive(false);
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame()
    {
        backgroundUI.SetActive(true);
        player1.SetActive(true);
        player2.SetActive(true);
        timer.SetActive(true);
        healthBars.SetActive(true);
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void RestartGame()
    {;
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
