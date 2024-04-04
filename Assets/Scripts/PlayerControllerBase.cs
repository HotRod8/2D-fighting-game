using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBase : MonoBehaviour
{
    //*************************************************************
    // Common input that is shared by both players and extended   *
    // by classes 'PlayerOneController' and 'PlayerTwoController' *
    //*************************************************************

    // Fields

    protected float speed = 10.0f;    // omni-directional speed of player
    protected Animator animator;      // controls which animations are played
    protected Rigidbody2D body;       // the bounds or 'body' of the player

    // move forward key
    // move backward key
    // move up key
    // move down key

    // high punch key
    // low punch key
    // high kick key
    // low kick key

    // Start is called before the first frame update
    protected void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        
    }

    public void HighKick()
    {
        OnHighKick();
    }

    public void HighPunch()
    {
        OnHighPunch();
    }

    public void LowKick()
    {
        OnLowKick();
    }

    public void LowPunch()
    {
        OnLowPunch();
    }

    //****************************************************************************
    // These methods below are intended to be overridden and have their specific *
    // 'animator' field determine the appropriate animations to be played.       *
    //****************************************************************************

    protected void OnHighKick()
    { }

    protected void OnHighPunch()
    { }

    protected void OnLowKick()
    { }

    protected void OnLowPunch()
    { }
}
