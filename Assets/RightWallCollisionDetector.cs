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
        if (collision.gameObject.name == "Camera Right Wall")
        {
            collisionDetected = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Camera Right Wall")
        {
            collisionDetected = false;
        }
    }
}
