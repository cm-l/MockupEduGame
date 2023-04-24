using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum OffensiveAction { dealDamage, multiplyByNumber, raiseToPowerOfNumber, none }

public enum Rarity { standard, common, rare, epic, legendary }
//the cost of a card depends on its rarity
//common - 120, rare - 240, epic - 500, legendary - 700
//standard cards cannot be bought in the shop - they are only available in the starter deck

public enum DefensiveAction { heal, block, barricade, none }

public enum SpecialAction { draw, sacrifice, pay, none }

public enum UniqueAction { discard, none}


[CreateAssetMenu(fileName = "New Card", menuName = "ScriptableObjects/Card", order = 1)]
public class SO_Card : ScriptableObject
{
    [Header("\nDefining attributes")]
    //public string equationDisplayed = ""; // what the card displays: e.g., a card that adds 3 might show + (2 + 5 - 4)
    public Material cardImage; // visuals of card 
    public Material cardArt; //art of card
    public string uniqueActionDescriptor; //for very special cards (changes card text to this)
    public string uniqueActionSuffix; //for somewhat special cards (appends this at the end of card text)
    public AudioClip playSound; //sound when played
    public string cardText; // what the card says

    [Header("\nOffense")]
    public float damageNumber = 0; // n-value
    public OffensiveAction offensiveAction; // operation of card: e.g., dealDamage with n = 4 will substract 4 from enemy

    [Header("\nDefense")]
    //public DefensiveAction defensiveAction = DefensiveAction.none; // op
    public int healAmount = 0;
    public int blockAmount = 0;
    public int barricadeAmount = 0;

    [Header("\nOther default behaviours")]
    //public SpecialAction specialAction = SpecialAction.none; // op
    public int drawAmount = 0;
    public int sacrificeAmount = 0;
    public int payAmount = 0;


    [Header("\nMana & Rarity")]
    // maybe it'll be useful sometime
    public int cost; // like mana or something
    public Rarity rarity; // for weighing rewards maybe?

    [Header("\nSpecial Effects")]
    // Define the ""dictionary"" - Unity nie serializuje slownikow xddddd wiec robimy dwie listy super
    public List<string> effect;
    public List<float> value;


}