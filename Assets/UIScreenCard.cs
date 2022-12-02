using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScreenCard : MonoBehaviour
{
    //Reward pool 
    //TODO rewrite into some other data structure to support weighting probabilities
    public List<SO_Card> cardRewardPool; //this could be a HashSet but list is visible in inspector for testing

    //Card Scriptable Object
    public SO_Card cardScriptableObject;


    // Start is called before the first frame update
    void Start()
    {
        //Select a random card from reward pool
        int randomIndexInList = Random.Range(0, cardRewardPool.Count);
        cardScriptableObject = cardRewardPool[randomIndexInList];

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
}
