using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //*********
    // FIELDS *
    //*********

    private GameObject cameraLeftWall;
    private GameObject cameraRightWall;

    private GameObject stageLeftWall;
    private GameObject stageRightWall;

    private GameObject player1;
    private GameObject player2;

    //**********
    // METHODS *
    //**********

    // Start is called before the first frame update
    void Start()
    {
        cameraLeftWall = GameObject.Find("Main Camera");
        cameraRightWall = GameObject.Find("Main Camera");

        stageLeftWall = GameObject.Find("Stage Left Wall");
        stageRightWall = GameObject.Find("Stage Right Wall");

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
