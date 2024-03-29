using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWallCollisionDetector : MonoBehaviour
{
    public static bool collisionDetected = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //*********************************
    // COLLISION ENTER / EXIT METHODS *
    //*********************************

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Stage Right Wall")
        {
            collisionDetected = true;
            Debug.Log("RIGHT WALL ENTER");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Stage Right Wall")
        {
            collisionDetected = false;
            Debug.Log("RIGHT WALL EXIT");
        }
    }
}
