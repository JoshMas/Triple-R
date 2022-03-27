using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreAdd : MonoBehaviour
{
    void OnTriggerEnter(Collider _other)
    {
        Game_Manager.instance.ScoreAdd(1);
    }
}