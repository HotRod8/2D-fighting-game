using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //*********
    // FIELDS *
    //*********

    private GameObject player1;
    private GameObject player2;

    //**********
    // METHODS *
    //**********

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            (player1.transform.position.x + player2.transform.position.x) / 2.0f,
            transform.position.y,
            transform.position.z
            );

        if (transform.position.x < -7.0f)
        {
            transform.position = new Vector3(
                -7.0f,
                transform.position.y,
                transform.position.z
                );
        }
        else if (transform.position.x > 7.0f)
        {
            transform.position = new Vector3(
                7.0f,
                transform.position.y,
                transform.position.z
                );
        }

    }
}
