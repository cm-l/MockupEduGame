using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class TransitionScript : MonoBehaviour {
    private static float runningGameChance = 33.33f;
    private static float combatGameChance = 33.33f;
    private static float bubbleGameChance = 33.34f;
    
    private static float firstThreshhold = runningGameChance;
    private static float secondThreshhold = firstThreshhold + combatGameChance;

    private static float randomNumber;


    void Start() {
        randomNumber = UnityEngine.Random.Range(0f, 100f);
    }


    public static void RandomizeScene() {
        Debug.Log(randomNumber.ToString().Substring(0, 5) + "%");
        if (randomNumber <= firstThreshhold)
        {
            Debug.Log("RUNNING");
            SceneManager.LoadSceneAsync("AdditionScene");
        }
        else if (randomNumber <= secondThreshhold)
        {
            Debug.Log("COMBAT");
            SceneManager.LoadSceneAsync("EnemyFight_Dungeon1");
        }
        else
        {
            Debug.Log("BUBBLE");
            SceneManager.LoadSceneAsync("Niko-minigierka");
        }
    }

    
}