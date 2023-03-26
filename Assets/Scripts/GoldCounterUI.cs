using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldCounterUI : MonoBehaviour
{
    [SerializeField] private TMP_Text goldAmountText;

    void Update()
    {
        goldAmountText.text = (("$" + ManagerSingleton.Instance.playerGold).ToString());
    }
}
