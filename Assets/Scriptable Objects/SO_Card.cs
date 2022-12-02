using UnityEngine;


public enum OffensiveAction { dealDamage, multiplyByNumber, raiseToPowerOfNumber, none }

public enum Rarity { common, rare, special }

public enum DefensiveAction { heal, block, barricade, none }

public enum SpecialAction { draw, sacrifice, none }

public enum UniqueAction { discard, none}


[CreateAssetMenu(fileName = "New Card", menuName = "ScriptableObjects/Card", order = 1)]
public class SO_Card : ScriptableObject
{
    [Header("\nDefining attributes")]
    //public string equationDisplayed = ""; // what the card displays: e.g., a card that adds 3 might show + (2 + 5 - 4)
    public Material cardImage; // visuals of card 
    public string uniqueActionDescriptor; //for very special cards (changes card text to this)
    public string uniqueActionSuffix; //for somewhat special cards (appends this at the end of card text)
    public AudioClip playSound; //sound when played

    [Header("\nOffense")]
    public float damageNumber = 0; // n-value
    public OffensiveAction offensiveAction; // operation of card: e.g., dealDamage with n = 4 will substract 4 from enemy

    [Header("\nDefense")]
    //public DefensiveAction defensiveAction = DefensiveAction.none; // op
    public int healAmount = 0;
    public int blockAmount = 0;
    public int barricadeAmount = 0;

    [Header("\nSpecial")]
    //public SpecialAction specialAction = SpecialAction.none; // op
    public int drawAmount = 0;
    public int sacrificeAmount = 0;


    [Header("\nNOT YET IMPLEMENTED\nMaybe will be featured later, maybe not")]
    // maybe it'll be useful sometime
    public int cost; // like mana or something
    public Rarity rarity; // for weighing rewards maybe?
}