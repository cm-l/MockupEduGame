using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class bubbleMath : MonoBehaviour
{
    public static int rValue;
    public TextMeshPro bubbleValue;
    GameObject gmText;
    void Start()
    {
        rValue = Random.Range(0, 20);
        gmText = gameObject.transform.GetChild(0).gameObject;
        bubbleValue = gmText.GetComponent<TextMeshPro>();
        bubbleValue.text = "" + rValue;
    }
}
