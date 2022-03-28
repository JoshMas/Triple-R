using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class timer_countdown : MonoBehaviour
{
    public Slider timerSlider;
    public float maxTime,secondsLeft;
    public bool takingAway = false;
    public Image fillImage;
    public Color full, empty;


    public void Start()
    {
        secondsLeft = maxTime;
        timerSlider.maxValue = maxTime;
        timerSlider.value = secondsLeft;
    }

    public void Update()
    {
        if (secondsLeft < 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (takingAway && secondsLeft > 0)
        {
            secondsLeft -= Time.deltaTime;
            timerSlider.value = secondsLeft;

            fillImage.color = Color.Lerp(empty, full, secondsLeft/maxTime);
        }
    }
}