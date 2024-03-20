using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoController : MonoBehaviour
{
    // Fields

    private float speed = 10.0f;

    public KeyCode leftKey = KeyCode.LeftArrow;
    public KeyCode rightKey = KeyCode.RightArrow;
    public KeyCode upKey = KeyCode.UpArrow;
    public KeyCode downKey = KeyCode.DownArrow;

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
        bool isOnGround = animator.GetBool("isOnGround");
        //bool isCrouching = animator.GetBool("isCrouching");
        float xInput = Input.GetAxisRaw("P2_Horizontal");
        float yInput = Input.GetAxisRaw("P2_Vertical");

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


        if (xInput < 0.0f) // moving forward
        {
            animator.SetBool("isMovingForward", true);
            animator.SetBool("isMovingBackward", false);

        }
        else if (xInput > 0.0f) // moving backward
        {
            animator.SetBool("isMovingBackward", true);
            animator.SetBool("isMovingForward", false);

        }
        else // idle
        {
            animator.SetBool("isMovingBackward", false);
            animator.SetBool("isMovingForward", false);

        }

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
}
