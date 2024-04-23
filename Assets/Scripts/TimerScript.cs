using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float timeLeft;
    public bool timerOn = true;

    public TextMeshProUGUI timerTxt;

    void Start()
    {
        //Each round should last a minute at most
        timeLeft = 60;
        timerTxt = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (OptionMenu.isPaused)
        {
            PauseTimer();
        }
        else
        {
            ResumeTimer();
        }

        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                updateTimer(timeLeft);
            }
            else
            {
                Debug.Log("TIME'S UP!");
                timeLeft = 0;
                timerOn = false;
            }
        }
    }


    void updateTimer(float time)
    {
        float seconds = Mathf.FloorToInt(time % 60);

        if (seconds > 0)
            timerTxt.text = seconds.ToString();
        else timerTxt.text = "0";
    }

    public void PauseTimer()
    {
        timerOn = false;
    }

    public void ResumeTimer()
    {
        timerOn = true;
    }
}
