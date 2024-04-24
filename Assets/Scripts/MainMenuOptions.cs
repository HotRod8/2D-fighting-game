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
        // Check if Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // If the controls menu is active, return to the pause menu
            if (controlsMenu.activeSelf)
            {
                ReturnToPauseMenu();
            }
            // Otherwise, toggle pause/resume game
            else
            {
                TogglePause();
            }
        }
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

    // Method to return from controls menu to pause menu
    void ReturnToPauseMenu()
    {
        controlsMenu.SetActive(false);
        pauseMenu.SetActive(true);
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

    public void ShowControls()
    {
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void RestartGame()
    {
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
