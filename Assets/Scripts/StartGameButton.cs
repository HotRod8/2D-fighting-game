using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour {
    public Button startButton;
    ////Only uses pos nums that have scenes.

    //public void StartGame(){
    //    SceneManager.LoadScene("0");
    //}

    //public void UpdateGame() {
    //    SceneManager.LoadScene(characterScene);
    //}

    public GameObject selectIndicator;

    public bool selected;

    void Start ()
    {
        selectIndicator.SetActive (false);
        startButton.onClick.AddListener(OnStartClicked);
    }

    void OnStartClicked ()
    {
        selectIndicator.SetActive(selected);
        SceneManager.LoadScene("CharacterSelect");
    }
}