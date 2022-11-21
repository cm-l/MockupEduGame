using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckAvailable : MonoBehaviour
{
    public List<SO_Card> availableCards;

    // Start is called before the first frame update
    void Awake()
    {
        // Playable (available) cards are the cards the player has in their possesion
        availableCards = DeckTracker.Instance.collectedCards;

        // Shuffle the deck before handing it off to the player
        Shuffle<SO_Card>(availableCards);


    }


    // Update is called once per frame
    void Update()
    {
        
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
}
