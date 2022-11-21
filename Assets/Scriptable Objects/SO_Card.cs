using UnityEngine;
public enum Operation { addNumber, multiplyByNumber, raiseToPowerOfNumber }
public enum Rarity { common, rare, special }

[CreateAssetMenu(fileName = "New Math Card", menuName = "ScriptableObjects/Card", order = 1)]
public class SO_Card : ScriptableObject
{
    [Header("\nDefining attributes")]
    public int number; // n-value
    public Operation operation; // operation of card: e.g., addNumber with n = -4 will substract 4 from enemy
    public string equationDisplayed; // what the card displays: e.g., a card that adds 3 might show + (2 + 5 - 4)
    public Material cardImage; // visuals of card 

    [Header("\nNOT YET IMPLEMENTED\nMaybe will be featured later, maybe not")]
    // maybe it'll be useful sometime
    public int cost; // like mana or something
    public Rarity rarity; // for weighing rewards maybe?
}