using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    RunningPlayer player;
    void Start()
    {
        player = GameObject.FindObjectOfType<RunningPlayer>();
    }
}
