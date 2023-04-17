using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BubbleStatsScript : MonoBehaviour
{
    int ok;
    int mistake;
    int notPopped;
    GameObject OKnum;
    GameObject MISTAKESnum;
    GameObject notPOPPEDnum;

    void Start()
    {
        OKnum = GameObject.Find("OKnum");
        MISTAKESnum = GameObject.Find("MISTAKESnum");
        notPOPPEDnum = GameObject.Find("notPOPPEDnum");
        ok = GameManager.ok;
        mistake = GameManager.mistake;
        notPopped = GameManager.notPopped;
        OKnum.GetComponent<TextMeshProUGUI>().text = ok.ToString();
        MISTAKESnum.GetComponent<TextMeshProUGUI>().text = mistake.ToString();
        notPOPPEDnum.GetComponent<TextMeshProUGUI>().text = notPopped.
            ToString();
    }
}
