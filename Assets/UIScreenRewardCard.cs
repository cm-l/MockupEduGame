using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIScreenRewardCard : MonoBehaviour
{
    //Reward pool 
    //TODO rewrite into some other data structure to support weighting probabilities
    public List<SO_Card> cardRewardPool; //this should be a HashSet but list is visible in inspector for testing

    //Enemy encounter pool
    public List<SO_Enemy> enemyEncounterPool; //same as above

    //Card Scriptable Object
    public SO_Card cardScriptableObject;

    //Next enemy encounter is set in the manager singleton to carry over scenes
    public SO_Enemy nextEnemyViaRewards;

    // Start is called before the first frame update
    void Start()
    {
        //Select a random card from reward pool
        int randomIndexInList = Random.Range(0, cardRewardPool.Count);
        cardScriptableObject = cardRewardPool[randomIndexInList];

        //Select random enemy from enemy pool
        int randomIndexInEnemyPool = Random.Range(0, enemyEncounterPool.Count);
        nextEnemyViaRewards = enemyEncounterPool[randomIndexInEnemyPool];

        // refer to SO:
        // to set equation displayed on card:
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(Card.operationTextSetter(cardScriptableObject));

        //Set mana/whatever cost on card display
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().SetText(cardScriptableObject.cost.ToString());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void addCardToCollection()
    {
        DeckTracker.Instance.collectedCards.Add(cardScriptableObject);
    }

    public void headInThisDirection()
    {
        Debug.Log("You decided to go towards " + nextEnemyViaRewards.name);
        ManagerSingleton.Instance.nextEncounteredEnemy = nextEnemyViaRewards;

        //Make an animation of fading out happen - fading in happens on start of other scene

        //Actually load in the selected scene
        //lower bound inclusive - upper bound EXCLUSIVE
        int indexScene = Random.Range(0, 3); //TODO fix based on number in build order
        SceneManager.LoadScene(indexScene);
    }
}
