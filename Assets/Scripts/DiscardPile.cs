using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiscardPile : MonoBehaviour
{

    public List<SO_Card> discardedCards;
    private TextMeshPro numberOfDiscardedCards;

    // Start is called before the first frame update
    void Awake()
    {
        numberOfDiscardedCards = gameObject.GetComponent<TextMeshPro>();
    }

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        updateNumberOfDiscardedCards();
    }

    public void updateNumberOfDiscardedCards()
    {
        numberOfDiscardedCards.SetText((discardedCards.Count).ToString());
    }
}
