using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Encounter", menuName = "ScriptableObjects/Enemy", order = 1)]
public class SO_Enemy : ScriptableObject
{
    [Header("\nNumber stats")]
    public int startingNumber;
    public int damage;


    [Header("\nVisuals")]
    public Material enemySpriteMaterial;

    [Header("\nSounds")]
    public AudioClip enemyMusicTrack;
    public AudioClip enemyAttackSound;
    public AudioClip enemyDeathNoise;

    [Header("\nRewards")]
    public int lowerGoldRange = 20;
    public int upperGoldRange = 70;
}