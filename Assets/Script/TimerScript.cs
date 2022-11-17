using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class TimerScript : MonoBehaviour
{
    public static float TimeLeft;
    public static bool TimerOn = false;

    public Text TimerTxt;

    void Start()
    {
        //TimerOn = true;
    }

    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft += Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                Debug.Log("Time is UP!");
                TimeLeft = 0;
                TimerOn = false;
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime -= 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ResetTime()
    {
        TimeLeft = 0;
        TimerOn = false;
    }
    public void OntargetFound()
    {
        TimeLeft = 1;
        TimerOn = false;
    }
}
