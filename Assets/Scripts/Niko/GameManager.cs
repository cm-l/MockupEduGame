using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int bottleMaterialNumber;
    bottleChange bChange;
    GameObject gmTextUI;
    TextMeshProUGUI textUI;

    void Start()
    {
        bChange = GameObject.FindGameObjectWithTag("Bottle").
            GetComponent<bottleChange>();
        gmTextUI = GameObject.Find("textUI");
        textUI = gmTextUI.GetComponent<TextMeshProUGUI>();
        textUI.enabled = true;
        StartCoroutine(disableText());
    }

    void Update()
    {
        bottleMaterialNumber = bChange.getBottleMaterialNumber();
        if (bottleMaterialNumber == 6)
        {
            Debug.Log("YOU WON");
        }
    }

    IEnumerator disableText()
    {
        yield return new WaitForSeconds(3f);
        textUI.enabled = false;

    }

}
