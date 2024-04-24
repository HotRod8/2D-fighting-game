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

    public Button yesButton;
    public Button noButton;

    private TimerScript timerScript;  // Reference to the TimerScript

    void Start()
    {
        rematchScreen.SetActive(false);
        yesButton.onClick.AddListener(OnYesClicked);
        noButton.onClick.AddListener(OnNoClicked);

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

    private void OnYesClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // Reload the current scene
        if (timerScript != null)
            timerScript.ResetTimer();  // Restart the timer
    }

    private void OnNoClicked()
    {
        SceneManager.LoadScene("CharacterSelect");  // Load the main menu scene
    }
}
