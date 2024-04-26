using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RematchScreen : MonoBehaviour
{
    public GameObject rematchScreen;
    public GameObject backgroundUI;
    public GameObject healthBars;
    public GameObject timerGameObject;  // This should be the GameObject that has the TimerScript
    public GameObject player1;
    public GameObject player2;

    public Button rematchButton;
    public Button changeButton;
    public Button homeButton;

    private TimerScript timerScript;  // Reference to the TimerScript

    void Start()
    {
        rematchScreen.SetActive(false);
        rematchButton.onClick.AddListener(OnRematchClicked);
        changeButton.onClick.AddListener(OnChangeClicked);
        homeButton.onClick.AddListener(OnHomeClicked);

        // Get the TimerScript from the timer GameObject
        timerScript = timerGameObject.GetComponent<TimerScript>();
        if (timerScript != null)
        {
            timerScript.onTimerComplete.AddListener(ShowRematchScreen);
            timerScript.ResetTimer();  // Start the timer
        }
    }

    void ShowRematchScreen()
    {
        // Deactivate game elements
        backgroundUI.SetActive(false);
        player1.SetActive(false);
        player2.SetActive(false);
        healthBars.SetActive(false);

        // Activate the rematch screen
        rematchScreen.SetActive(true);
    }

    private void OnRematchClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // Reload the current scene
        if (timerScript != null)
            timerScript.ResetTimer();  // Restart the timer
    }

    private void OnChangeClicked()
    {
        SceneManager.LoadScene("CharacterSelect");  // Load the character select scene
    }

    private void OnHomeClicked()
    {
        SceneManager.LoadScene("Main Menu");  // Load the main menu scene
    }
}
