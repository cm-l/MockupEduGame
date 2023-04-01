using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Potion", menuName = "ScriptableObjects/Potion", order = 1)]
public class SO_Potion : ScriptableObject
{
    [Header("\nName and description")]
    public string nameOfPotion;
    public string description;


    [Header("\nVisuals")]
    public Sprite potionSprite;

    [Header("\nCost in shop")]
    public int costInShop;
}