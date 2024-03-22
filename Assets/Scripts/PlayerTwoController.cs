using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoController : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;

    //**********************
    // Fields for Player 2 *
    //**********************

    public float moveSpeed = 10.0f;

    public KeyCode moveLeftKey = KeyCode.LeftArrow;
    public KeyCode moveRightKey = KeyCode.RightArrow;
    public KeyCode moveUpKey = KeyCode.UpArrow;
    public KeyCode moveDownKey = KeyCode.DownArrow;
    public KeyCode overheadKey = KeyCode.P;
    public KeyCode punchKey = KeyCode.O;
    public KeyCode kickKey = KeyCode.I;
    public KeyCode blockKey = KeyCode.U;

    private Animator animator;
    private Rigidbody2D body;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");

        // Components for Player 2
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //*************************
        // KEY / CONTROLLER INPUT *
        //*************************

        // Gets x-axis and y-axis input from both keyboard and controller.
        float xInput = Input.GetAxisRaw("P2_Horizontal");
        float yInput = Input.GetAxisRaw("P2_Vertical");

        bool moveRightKeyPressed = xInput > 0.0f;
        bool moveLeftKeyPressed = xInput < 0.0f;
        bool moveUpKeyPressed = yInput > 0.0f;
        bool moveDownKeyPressed = yInput < 0.0f;

        // Sets the first parameter to TRUE if the second parameter is TRUE, otherwise FALSE.
        animator.SetBool("isPunching", Input.GetKey(punchKey));
        animator.SetBool("isKicking", Input.GetKey(kickKey));
        animator.SetBool("isOverhead", Input.GetKey(overheadKey));
        animator.SetBool("isBlocking", Input.GetKey(blockKey));

        //***********
        // VELOCITY *
        //***********

        // Calculate the new velocity based on input.
        Vector2 movement = new Vector2(xInput, yInput);
        body.velocity = movement * moveSpeed;

        //************
        // COLLISION *
        //************

        bool isOnGround = animator.GetBool("isOnGround");

        //*************************
        // FACING DIRECTION LOGIC *
        //*************************

        // Flips Player 2 horizontally based on both players' x-coordinates.
        // Note: transform is a component that contains an entity's position, rotation, and scale.
        sprite.flipX = player1.transform.position.x > player2.transform.position.x ? false : true;

        // flipX = false = facing right
        // flipX = true  = facing left
        animator.SetBool("isFacingRight", sprite.flipX);

        //********************************
        // MOVE FORWARD / BACKWARD LOGIC *
        //********************************

        bool isFacingRight = animator.GetBool("isFacingRight");
        //bool isFacingRight = false;

        animator.SetBool("isMovingForward", (moveRightKeyPressed && !isFacingRight) || (moveLeftKeyPressed && isFacingRight));
        animator.SetBool("isMovingBackward", (moveRightKeyPressed && isFacingRight) || (moveLeftKeyPressed && !isFacingRight));

        //***********************
        // MOVE UP / DOWN LOGIC *
        //***********************

        animator.SetBool("isMovingUp", moveUpKeyPressed);
        animator.SetBool("isMovingDown", moveDownKeyPressed);
    }

    //*********************************
    // COLLISION ENTER / EXIT METHODS *
    //*********************************

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
