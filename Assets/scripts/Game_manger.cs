using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;
    [SerializeField] private int score;

    public void Awake()
    {
        instance = this;
    }

    public void ScoreAdd(int _amount)
    {
        score += _amount;
    }
}

