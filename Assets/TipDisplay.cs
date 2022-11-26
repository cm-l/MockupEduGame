using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TipDisplay : MonoBehaviour
{
    public TextMeshProUGUI tipText;
    public EnemyBehaviuur enemy;

    // Start is called before the first frame update
    void Awake()
    {
        tipText = gameObject.GetComponent<TextMeshProUGUI>();
        enemy = GameObject.Find("Enemy").GetComponent<EnemyBehaviuur>();
    }

    // Update is called once per frame
    void Update()
    {
        //TODO consider moving this out of update to save a tiny bit of performance maybe
        tipText.SetText(enemy.enemyScriptableObject.goalNumber + " needed to win!");
    }
}
