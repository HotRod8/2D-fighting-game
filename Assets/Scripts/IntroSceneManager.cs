using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneManager : MonoBehaviour
{
    public GameObject buttonText;
    private float timer;

    public int activeElement;
    public StartGameButton startButton;

    // Update is called once per frame
    void Update()
    {
        //it flickers the "Press Start" text
        timer += Time.deltaTime;
        if (timer > 0.6f)
        {
            timer = 0;
            buttonText.SetActive(!buttonText.activeInHierarchy);
        }

        //Where Start == space
        if(Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("Jump"))
        {
            //then load the level
            Debug.Log("load");
            startButton.selected = true;
            StartCoroutine("LoadLevel");
            startButton.transform.localScale *= 1.2f;
        }
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadSceneAsync("select", LoadSceneMode.Single);
    }
}
