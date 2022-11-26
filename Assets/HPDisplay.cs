using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPDisplay : MonoBehaviour
{

    private TextMeshPro HPText;

    private void Awake()
    {
        HPText = transform.GetChild(0).GetComponent<TextMeshPro>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HPText.SetText(ManagerSingleton.Instance.playerCurrentHealth + "/" + ManagerSingleton.Instance.playerMaxHealth);
    }
}
