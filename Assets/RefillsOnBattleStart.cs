using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillsOnBattleStart : MonoBehaviour
{
    public SO_Artifact manaBooster;
    public SO_Artifact bandaid;

    // Start is called before the first frame update
    void Start()
    {
        //Mana refill
        ManagerSingleton.Instance.manaCurrentPoints = ManagerSingleton.Instance.manaMaxPoints;


        //Special refills
        //Mana Booster Artifact handling
        if (DeckTracker.Instance.collectedArtifacts.Contains(manaBooster))
        {
            ExtraMana(1);
        }

        //Bandaid Artifact handling
        if (DeckTracker.Instance.collectedArtifacts.Contains(bandaid))
        {
            HealthRefill(4);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExtraMana(int amount)
    {
        Debug.Log("Adding " + amount + " extra juice");
        ManagerSingleton.Instance.manaCurrentPoints = ManagerSingleton.Instance.manaMaxPoints + amount;
    }

    public void HealthRefill(int amount)
    {
        ManagerSingleton.Instance.playerCurrentHealth += amount;
    }
}
