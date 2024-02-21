using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour {
    //public int characterScene; // 0 is false, and all pos are true
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
    }
    void Update ()
    {
        selectIndicator.SetActive (selected);
    }
}