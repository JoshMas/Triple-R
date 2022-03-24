using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer_countdown : MonoBehaviour
{
    public Text textDisplay;
    public float secondsLeft = 30;
    public bool takingAway = false;


    public void Start()
    {
        textDisplay.text = "00: " + (int)secondsLeft;
    }

    public void Update()
    {
        if (takingAway && secondsLeft > 0)
        {
            secondsLeft -= Time.deltaTime;
            textDisplay.text = "00: " + (int)secondsLeft;
        }
    }
}