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

    public static timer_countdown Instance;
    private void Singleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        Singleton();
    }

    public void Start()
    {
        secondsLeft = maxTime;
        timerSlider.maxValue = maxTime;
        timerSlider.value = secondsLeft;
    }

    public void AddTime(float _time)
    {
        secondsLeft += _time;
        secondsLeft = maxTime < secondsLeft ? maxTime : secondsLeft;
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