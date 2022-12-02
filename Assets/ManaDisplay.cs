using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManaDisplay : MonoBehaviour
{
    private TextMeshPro manaText;

    private void Awake()
    {
        manaText = transform.GetChild(0).GetComponent<TextMeshPro>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Default to starting mana out of max mana
        manaText.SetText($"{ManagerSingleton.Instance.manaCurrentPoints}/{ManagerSingleton.Instance.manaMaxPoints}");
    }

    // Update is called once per frame
    void Update()
    {
        //TODO move to only when mana changes to save some tiny amount of performance
        manaText.SetText($"{ManagerSingleton.Instance.manaCurrentPoints}/{ManagerSingleton.Instance.manaMaxPoints}");
    }
}
