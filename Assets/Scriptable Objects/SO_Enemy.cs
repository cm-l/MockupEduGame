using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Encounter", menuName = "ScriptableObjects/Enemy", order = 1)]
public class SO_Enemy : ScriptableObject
{
    [Header("\nNumber stats")]
    public int startingNumber;
    public int goalNumber;
    public int damage;


    [Header("\nVisuals")]
    public Material enemySpriteMaterial;
}