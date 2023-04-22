using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using System;


public class TransitionScript : MonoBehaviour {

    private static string cardsGameName1 = "EnemyFight_Dungeon1";
    private static string cardsGameName2 = "EnemyFight_Dungeon2";
    private static string cardsGameName3 = "EnemyFight_Dungeon3";

    private static string runningGameName = "AdditionScene";
    private static string combatGameName = "PiJ-minigra";
    private static string cauldronGameName = "Niko-minigierka";
    private static string shopSceneName = "Shop";

    private static List<string> gameScenes;

    private static int randomIndex;
    private static int scenesAmount; 

    [SerializeField] private Canvas menuCanvas;
    [SerializeField] private Canvas shopGameCanvas;

    public static bool cameFromAnotherScene = false;

    void Start() {
        if(cameFromAnotherScene) {
            menuCanvas.gameObject.SetActive(false);
            Invoke("ShowShopGameChoice", 1.2f);
        }
    }

     public static void RandomizeGameScene() {
        gameScenes = GetGameScenes(GameProgression.GetCurrentGameStage());
        scenesAmount = gameScenes.Count;
        randomIndex = UnityEngine.Random.Range(0, scenesAmount);
        float delay = 0.1f;
        var mainThread = SynchronizationContext.Current;
        Task.Delay(TimeSpan.FromSeconds(delay)).ContinueWith(_ =>
            mainThread.Post(__ => LoadNextScene(gameScenes[randomIndex]), null));
    }

    public static void LoadNextScene(string sceneName) {
        SceneManager.LoadSceneAsync(sceneName);
    }

    private void ShowShopGameChoice() {
        shopGameCanvas.gameObject.SetActive(true);
    }

    private static List<string> GetGameScenes(int currentGameStage) {
        if (currentGameStage == 1) {
            return new List<string> {
                cardsGameName1, cardsGameName1, cardsGameName1, cardsGameName1, cardsGameName1, cauldronGameName, runningGameName, runningGameName, shopSceneName, combatGameName
            };
        } else if (currentGameStage == 2) {
            return new List<string> {
                cardsGameName2, cardsGameName2, cardsGameName2, cardsGameName2, cardsGameName2, cardsGameName2, cardsGameName2, cardsGameName2, cauldronGameName, cauldronGameName,
                cauldronGameName, cauldronGameName, runningGameName, runningGameName, shopSceneName, shopSceneName, shopSceneName, combatGameName, combatGameName, combatGameName
            };
        } else if (currentGameStage == 3) {
            return new List<string> {
                cardsGameName3, cardsGameName3, cardsGameName3, cardsGameName3, cardsGameName3, cardsGameName3, cardsGameName3, cardsGameName3, cardsGameName3, cardsGameName3,
                cardsGameName3, cardsGameName3, cauldronGameName, cauldronGameName, runningGameName, runningGameName, runningGameName, runningGameName, shopSceneName, combatGameName 
            };
        } else if(currentGameStage == 4) {
            return new List<string> { "TheEndWin" };
        } else {
            return new List<string>();
        }
    }
}