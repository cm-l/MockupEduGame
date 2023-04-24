using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyDamageText : MonoBehaviour
{

    public TextMeshPro damageIndicator;
    public EnemyBehaviuur enemyBhv;

    // Start is called before the first frame update
    void Awake()
    {
        try
        {
            damageIndicator = gameObject.GetComponent<TextMeshPro>();
            enemyBhv = GameObject.Find("Enemy").GetComponent<EnemyBehaviuur>();
        } catch { }
        }

    // Update is called once per frame
    void Update()
    {
        try
        {
            damageIndicator.SetText("Enemy DMG: " + enemyBhv.damageCapability.ToString());
        } catch { }
    }
}
