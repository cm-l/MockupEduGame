using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int bottleMaterialNumber;
    bottleChange bChange;

    void Start()
    {
        bChange = GameObject.FindGameObjectWithTag("Bottle").
            GetComponent<bottleChange>();
    }

    void Update()
    {
        bottleMaterialNumber = bChange.getBottleMaterialNumber();
        if (bottleMaterialNumber == 6)
        {
            Debug.Log("YOU WON");
        }
    }
}
