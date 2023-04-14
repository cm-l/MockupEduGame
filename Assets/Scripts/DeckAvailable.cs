using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeckAvailable : MonoBehaviour
{
    public List<SO_Card> availableCards;
    public TextMeshPro numberOfCardsLeftInDeckText;
    public DiscardPile discarded;

    // Start is called before the first frame update
    void Awake()
    {
        // Playable (available) cards are the cards the player has in their possesion
        //availableCards = DeckTracker.Instance.collectedCards;

        for (int i = 0; i < DeckTracker.Instance.collectedCards.Count; i++)
        {
            availableCards.Add(DeckTracker.Instance.collectedCards[i]);
        }

        // How many cards are left in the deck (playable pile)?
        numberOfCardsLeftInDeckText = transform.GetChild(0).gameObject.GetComponent<TextMeshPro>();

        // Shuffle the deck before handing it off to the player
        Shuffle<SO_Card>(availableCards);

        // Refer to discarded cards
        discarded = GameObject.Find("Graveyard").GetComponent<DiscardPile>();


    }


    // Update is called once per frame
    void Update()
    {
        numberOfCardsLeftInDeckText.SetText((availableCards.Count).ToString());
    }

    public void Shuffle<T>(List<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }

    public void Refill()
    {

        for (int i = 0; i < discarded.discardedCards.Count; i++)
        {
            if (discarded.discardedCards[i].rarity != Rarity.special)
            {
                availableCards.Add(discarded.discardedCards[i]);
            }
        }
        // Empty the discard pile
        discarded.discardedCards.Clear();
        // Shuffle deck
        Shuffle<SO_Card>(availableCards);
    }

}
