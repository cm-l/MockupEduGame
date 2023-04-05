using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionLogic : MonoBehaviour
{
    public int potionIndex;
    [SerializeField] private SO_Potion scriptablePotion;
    private TooltipDisplay tooltip;
    private Image potionSprite;
    [SerializeField] Sprite emptyPotion;
    [SerializeField] EnemyBehaviuur enemy;
    [SerializeField] List<Card> hand;

    private void Awake()
    {
        // Grabbing references
        potionSprite = gameObject.GetComponent<Image>();
        tooltip = gameObject.GetComponent<TooltipDisplay>();
        enemy = GameObject.Find("Enemy").GetComponent<EnemyBehaviuur>();

        hand.Add(GameObject.Find("Card Slot 1").GetComponent<Card>());
        hand.Add(GameObject.Find("Card Slot 2").GetComponent<Card>());
        hand.Add(GameObject.Find("Card Slot 3").GetComponent<Card>());
        hand.Add(GameObject.Find("Card Slot 4").GetComponent<Card>());
        // ...
    }


    // Start is called before the first frame update
    void Start()
    {

        // n-th potion
        scriptablePotion = DeckTracker.Instance.collectedPotions[potionIndex];

    }

    // Update is called once per frame
    void Update()
    {
        // Keep checking it?
        // n-th potion
        scriptablePotion = DeckTracker.Instance.collectedPotions[potionIndex];

        if (scriptablePotion != null)
        {

            // image
            potionSprite.sprite = scriptablePotion.potionSprite;



            // Tooltip gets filled with info relating to potion
            tooltip.header = scriptablePotion.nameOfPotion;
            tooltip.content = scriptablePotion.description;

        }

        // empty potion display
        else if (scriptablePotion == null)
        {
            tooltip.header = "No potion!";
            tooltip.content = "Either you already drank it or haven't collected any. :(";
            potionSprite.sprite = emptyPotion;
            potionSprite.color = Color.black;

        }
    }

    // Remove potion
    public void drinkDown()
    {
        DeckTracker.Instance.removePotionAt(potionIndex);
    }

    // Effect invoker
    public void callPotionBehaviours()
    {
        for (int i = 0; i < scriptablePotion.effect.Count; i++)
        {
            if (scriptablePotion.effect[i] == "heal")
            {
                healthPotion((int)scriptablePotion.value[i]);
            }

            if (scriptablePotion.effect[i] == "mana")
            {
                manaPotion((int)scriptablePotion.value[i]);
            }

            if (scriptablePotion.effect[i] == "gold")
            {
                goldPotion((int)scriptablePotion.value[i]);
            }

            if (scriptablePotion.effect[i] == "harm")
            {
                harmPotion((int)scriptablePotion.value[i]);
            }

            if (scriptablePotion.effect[i] == "weak")
            {
                weakPotion(scriptablePotion.value[i]);
            }

            if (scriptablePotion.effect[i] == "hand")
            {
                handPotion((int)scriptablePotion.value[i]);
            }

            if (scriptablePotion.effect[i] == "block")
            {
                blockPotion((int)scriptablePotion.value[i]);
            }
        }
    }

    // --- POTION BEHAVIOURS ---
    public void healthPotion(int health)
    {
        ManagerSingleton.Instance.Heal(health);
    }

    public void manaPotion(int mana)
    {
        ManagerSingleton.Instance.addMana(mana);
    }

    public void goldPotion(int gold)
    {
        ManagerSingleton.Instance.gainGold(gold);
    }

    public void harmPotion(int damage)
    {
        enemy.takeDamage(damage);
    }

    public void weakPotion(float weak)
    {
        enemy.weaknessMod -= weak;
    }

    public void handPotion(int filler)
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

    public void blockPotion(int block)
    {
        ManagerSingleton.Instance.Block(block); //BUGGED
    }
}
