using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerOneController : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;

    //**********************
    // Fields for Player 1 *
    //**********************

    public GameObject punchPoint;
    public GameObject kickPoint;
    public GameObject sweepPoint;
    public float punchRadius;
    public float kickRadius;
    public float sweepRadius;
    public float punchDamage;
    public float kickDamage;
    public float sweepDamage;
    public LayerMask enemies;

    public float moveSpeed = 10.0f;

    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode moveUpKey = KeyCode.W;
    public KeyCode moveDownKey = KeyCode.S;
    public KeyCode punchKey = KeyCode.G;
    public KeyCode kickKey = KeyCode.H;
    public KeyCode blockKey = KeyCode.B;
    public KeyCode escapeKey = KeyCode.Escape;

    private Animator animator;
    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private AudioSource soundEffects;
    public AudioClip punchSound;
    public AudioClip kickSound;
    public AudioClip sweepSound;
    public AudioClip landingSound;

    private int punchTimer = 0;
    private int kickTimer = 0;
    private int sweepTimer = 0;

    private bool isOnGroundBefore = false;


    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player 1");
        player2 = GameObject.Find("Player 2");

        // Components for Player 1
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        soundEffects = GetComponent<AudioSource>();
    }

    public void Pause()
    {
        SceneManager.LoadScene("OptionMenuScreen");
    }

    // Update is called once per frame
    void Update()
    {
        if (punchTimer > 0)
        {
            if (punchTimer == 4) { StopPunch(); }
            if (punchTimer < 120) { ++punchTimer; }
            else { punchTimer = 0; }
        }
        else if (kickTimer > 0)
        {
            if (kickTimer == 6) { StopKick(); }
            if (kickTimer < 120) { ++kickTimer; }
            else { kickTimer = 0; }
        }
        else if (sweepTimer > 0)
        {
            if (sweepTimer == 7) { StopSweep(); }
            if (sweepTimer < 120) { ++sweepTimer; }
            else { sweepTimer = 0; }
        }

        //*************************
        // Pause Method *
        //*************************

        if (Input.GetKeyDown(escapeKey))
        {
            Pause();
        }

        //*************************
        // KEY / CONTROLLER INPUT *
        //*************************

        // Gets x-axis and y-axis input from both keyboard and controller.
        float xInput = Input.GetAxisRaw("P1_Horizontal");
        float yInput = Input.GetAxisRaw("P1_Vertical");

        bool moveRightKeyPressed = xInput > 0.0f;
        bool moveLeftKeyPressed = xInput < 0.0f;
        bool moveUpKeyPressed = yInput > 0.0f;
        bool moveDownKeyPressed = yInput < 0.0f;
        bool blockKeyPressed = Input.GetKey(blockKey);

        // Sets the first parameter to TRUE if the second parameter is TRUE, otherwise FALSE.
        if (Input.GetKey(punchKey) && !hasAttacked())
        {
            StartPunch();
        }
        else if (Input.GetKey(kickKey) && !hasAttacked())
        {
            StartKick();
        }
        animator.SetBool("isBlocking", blockKeyPressed);

        //**********************
        // COLLISION DETECTION *
        //**********************

        bool isOnGround = animator.GetBool("isOnGround");

        //**********************
        // LANDING SOUND LOGIC *
        //**********************

        if (!isOnGroundBefore && isOnGround)
        {
            LandingSound();
        }

        isOnGroundBefore = isOnGround;

        //***********
        // VELOCITY *
        //***********

        // Calculate the new velocity based on input.
        Vector2 movement = new Vector2(xInput, yInput);

        // Only move player when not crouching and not blocking.
        if ((isOnGround && moveDownKeyPressed) || blockKeyPressed)
        {
            body.velocity = Vector2.zero;
        }
        else
        {
            body.velocity = movement * moveSpeed;
        }

        //*************************
        // FACING DIRECTION LOGIC *
        //*************************

        // Flips Player 1 horizontally based on both players' x-coordinates.
        // Note: transform is a component that contains an entity's position, rotation, and scale.
        sprite.flipX = player1.transform.position.x > player2.transform.position.x ? true : false;

        // flipX = false = facing right
        // flipX = true  = facing left
        animator.SetBool("isFacingRight", !sprite.flipX);

        //********************************
        // MOVE FORWARD / BACKWARD LOGIC *
        //********************************

        bool isFacingRight = animator.GetBool("isFacingRight");

        animator.SetBool("isMovingForward", (moveRightKeyPressed && isFacingRight) || (moveLeftKeyPressed && !isFacingRight));
        animator.SetBool("isMovingBackward", (moveRightKeyPressed && !isFacingRight) || (moveLeftKeyPressed && isFacingRight));

        //***********************
        // MOVE UP / DOWN LOGIC *
        //***********************

        animator.SetBool("isMovingUp", moveUpKeyPressed);
        animator.SetBool("isMovingDown", moveDownKeyPressed);
    }

    //*********************
    // SOUND EFFECT LOGIC *
    //*********************

    public void PunchSound()
    {
        soundEffects.clip = punchSound;
        soundEffects.Play();
    }

    public void KickSound()
    {
        soundEffects.clip = kickSound;
        soundEffects.Play();
    }

    public void SweepSound()
    {
        soundEffects.clip = sweepSound;
        soundEffects.Play();
    }

    public void LandingSound()
    {
        soundEffects.clip = landingSound;
        soundEffects.Play();
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
    public void StartPunch()
    {
        animator.SetBool("isPunching", true);
        ++punchTimer;
    }
    public void StopPunch()
    {
        animator.SetBool("isPunching", false);
    }
    public void StartKick()
    {
        animator.SetBool("isKicking", true);
        ++kickTimer;
    }
    public void StopKick()
    {
        animator.SetBool("isKicking", false);
    }
    public void StartSweep()
    {
        animator.SetBool("isPunching", true);
        ++sweepTimer;
    }
    public void StopSweep()
    {
        animator.SetBool("isPunching", false);
    }
    private bool hasAttacked()
    {
        return (punchTimer > 0 || kickTimer > 0 || sweepTimer > 0);
    }

    public void punch()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(punchPoint.transform.position, punchRadius, enemies);

        foreach (Collider2D enemyGameObject in enemy)
        {
            UnityEngine.Debug.Log("Punched Player 2");
            player2.GetComponent<PlayerTwoHealth>().health -= punchDamage;
        }
    }

    public void kick()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(kickPoint.transform.position, kickRadius, enemies);

        foreach (Collider2D enemyGameObject in enemy)
        {
           UnityEngine.Debug.Log("Kicked Player 2");
           player2.GetComponent<PlayerTwoHealth>().health -= kickDamage;
        }
    }

    public void sweep()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(sweepPoint.transform.position, sweepRadius, enemies);

        foreach (Collider2D enemyGameObject in enemy)
        {
            UnityEngine.Debug.Log("Swept Player 2");
            player2.GetComponent<PlayerTwoHealth>().health -= sweepDamage;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(punchPoint.transform.position, punchRadius);
        Gizmos.DrawWireSphere(kickPoint.transform.position, kickRadius);
        Gizmos.DrawWireSphere(sweepPoint.transform.position, sweepRadius);
    }
}
