using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldCounterScript : MonoBehaviour
{
    [SerializeField] private TextMeshPro goldAmountText;

    void Awake()
    {
        goldAmountText = transform.GetChild(0).GetComponent<TextMeshPro>();
    }


    void Start()
    {
           
    }

    void Update()
    {
        goldAmountText.SetText(("$" + ManagerSingleton.Instance.playerGold).ToString());
    }
}
