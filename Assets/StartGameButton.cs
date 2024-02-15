using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour {
    public int characterScene;

    public void StartGame(){
        SceneManager.LoadScene(characterScene);
    }
}