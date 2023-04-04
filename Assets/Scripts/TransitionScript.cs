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
    public static bool cameFromAnotherScene = false;
    [SerializeField] private Canvas menuCanvas;
    [SerializeField] private Canvas shopGameCanvas;

    void Start() {
        randomNumber = UnityEngine.Random.Range(0f, 100f);
        if(cameFromAnotherScene) {
            menuCanvas.gameObject.SetActive(false);
            Invoke("ShowShopGameChoice", 1.2f);
        }
    }

    public static void RandomizeScene() {
        if (randomNumber <= firstThreshhold) {
            SceneManager.LoadSceneAsync("AdditionScene");
        }
        else if (randomNumber <= secondThreshhold) {
            SceneManager.LoadSceneAsync("EnemyFight_Dungeon1");
        }
        else {
            SceneManager.LoadSceneAsync("Niko-minigierka");
        }
    }

    private void ShowShopGameChoice() {
        shopGameCanvas.gameObject.SetActive(true);
    }
}