using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOneController : MonoBehaviour
{
    // Fields

    public float speed = 10.0f;

    public KeyCode leftKey     = KeyCode.A;
    public KeyCode rightKey    = KeyCode.D;
    public KeyCode upKey       = KeyCode.W;
    public KeyCode downKey     = KeyCode.S;
    
    private Animator animator;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //********
        // INPUT *
        //********

        bool isOnGround = animator.GetBool("isOnGround");
        bool isCrouching = animator.GetBool("isCrouching");
        
        float xInput = Input.GetAxisRaw("P1_Horizontal");
        float yInput = Input.GetAxisRaw("P1_Vertical");

        Vector2 movement = new Vector2(xInput, yInput);
        body.velocity = movement * speed;

        if (yInput < 0.0f) // moving down
        {
            if (isOnGround)
            {
                animator.SetBool("isCrouching", true);

                animator.SetBool("isMovingDown", false);
                animator.SetBool("isMovingUp", false);
            }
            else
            {
                animator.SetBool("isMovingDown", true);

                animator.SetBool("isCrouching", false);
                animator.SetBool("isMovingUp", false);
            }
        }
        else if (yInput > 0.0f) // moving up
        {
            animator.SetBool("isMovingUp", true);

            animator.SetBool("isCrouching", false);
            animator.SetBool("isMovingDown", false);
        }
        else // idle
        {
            animator.SetBool("isCrouching", false);
            animator.SetBool("isMovingDown", false);
            animator.SetBool("isMovingUp", false);
        }
        
        
        if (xInput > 0.0f) // moving forward
        {
            animator.SetBool("isMovingForward", true);
            animator.SetBool("isMovingBackward", false);

        }
        else if (xInput < 0.0f) // moving backward
        {
            animator.SetBool("isMovingBackward", true);
            animator.SetBool("isMovingForward", false);

        }
        else // idle
        {
            animator.SetBool("isMovingBackward", false);
            animator.SetBool("isMovingForward", false);
        }

        // sets isPunching to true or false if key pressed or not pressed
        animator.SetBool("isPunching", Input.GetKey(KeyCode.G));
        animator.SetBool("isKicking", Input.GetKey(KeyCode.H));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            animator.SetBool("isOnGround", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            animator.SetBool("isOnGround", false);
        }
    }

    //*****************
    // Helper Methods *
    //*****************

    void ClearAnimatorBools()
    // Sets all the boolean values in the animator to false
    {
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            if (parameter.type == AnimatorControllerParameterType.Bool)
            {
                animator.SetBool(parameter.name, false);
            }
        }
    }
}
