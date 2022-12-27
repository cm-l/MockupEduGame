using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class bubbleMath : MonoBehaviour
{
    public TextMeshPro bubbleValue;
    GameObject gmText;
    void Start()
    {
        int rValue = Random.Range(-400, 400);
        Debug.Log(rValue);
        gmText = gameObject.transform.GetChild(0).gameObject;
        Debug.Log(gmText);
        bubbleValue = gmText.GetComponent<TextMeshPro>();
        Debug.Log(bubbleValue);
        bubbleValue.text = "" + rValue;
    }
}
