using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Artifact", menuName = "ScriptableObjects/Artifact", order = 1)]
public class SO_Artifact : ScriptableObject
{
    [Header("\nName and description")]
    public string nameOfArtifact;
    public string description;


    [Header("\nVisuals")]
    public Sprite artifactSprite;

    [Header("\nCost in shop")]
    public int costInShop;
}