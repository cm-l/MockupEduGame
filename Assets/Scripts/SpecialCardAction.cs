using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpecialCardAction : MonoBehaviour
{
    private TooltipDisplay tooltip;
    [SerializeField] EnemyBehaviuur enemy;
    [SerializeField] List<Card> hand;
    public DeckAvailable deckAvailable;
    public DiscardPile discardPile;

    private void Awake()
    {

        // Refer to the Deck of available cards
        deckAvailable = GameObject.Find("Deck Object").GetComponent<DeckAvailable>();

        // Refer to the discard pile (graveyard)
        discardPile = GameObject.Find("Graveyard").GetComponent<DiscardPile>();

        // Grabbing references
        tooltip = gameObject.GetComponent<TooltipDisplay>();
        enemy = GameObject.Find("Enemy").GetComponent<EnemyBehaviuur>();

        hand.Add(GameObject.Find("Card Slot 1").GetComponent<Card>());
        hand.Add(GameObject.Find("Card Slot 2").GetComponent<Card>());
        hand.Add(GameObject.Find("Card Slot 3").GetComponent<Card>());
        hand.Add(GameObject.Find("Card Slot 4").GetComponent<Card>());
        // ...
    }

    public void doSpecialAction(SO_Card socard)
    {

        for (int i = 0; i < socard.effect.Count; i++)
        {
            if (socard.effect[i] == "exhaust")
            {
                
                exhaustEffect((int)socard.value[i], socard);
            }

            if (socard.effect[i] == "mana")
            {
                manaEffect((int)socard.value[i]);
            }

            if (socard.effect[i] == "gold")
            {
                goldEffect((int)socard.value[i]);
            }
            if (socard.effect[i] == "block")
            {
                
            }

            if (socard.effect[i] == "weak")
            {
                weakEffect(socard.value[i]);
            }

            if (socard.effect[i] == "hand")
            {
                handEffect((int)socard.value[i]);
            }

            if (socard.effect[i] == "block")
            {
                blockEffect((int)socard.value[i]);
            }

            if (socard.effect[i] == "toxic")
            {
                toxicEffect((int)socard.value[i]);
            }
        }

        Debug.Log("Yeah");
    }

    // BEHAVIOURS
    public void exhaustEffect(int filler, SO_Card socard)
    {
        Debug.Log("Spaghetti code :D");
    }

    public void manaEffect(int mana)
    {
        ManagerSingleton.Instance.addMana(mana);
    }

    public void goldEffect(int gold)
    {
        ManagerSingleton.Instance.gainGold(gold);
    }

    //public void harmEffect(int damage)
    //{
    //    enemy.takeDamage(damage);
    //}

    public void weakEffect(float weak)
    {
        enemy.weaknessMod -= weak;
    }

    public void handEffect(int filler)
    {
        for (int i = 0; i < hand.Count; i++)
        {
            //throw away
            hand[i].discardHand();
            hand[i].addToDiscardPile();

            //redraw
            hand[i].dealHand();
        }
    }

    public void blockEffect(int block)
    {
        enemy.damageCapability -= block;
    }

    public void toxicEffect(int toxin)
    {
        enemy.poisonAmount += toxin;
    }
}
