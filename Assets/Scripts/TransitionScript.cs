using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;
using UnityEngine;
using System;


public class TransitionScript : MonoBehaviour {

    private static string cardsGameName = "EnemyFight_Dungeon1";
    private static string runningGameName = "AdditionScene";
    private static string combatGameName = "PiJ-minigraIntro";
    private static string cauldronGameName = "Niko-minigierka";
    private static string shopSceneName = "Shop";

    // Szanse [%]
    // Stage 1.
    private static int cardsGameProbabilityS1 = 20;
    private static int runningGameProbabilityS1 = 20;
    private static int combatGameProbabilityS1 = 20;
    private static int cauldronGameProbabilityS1 = 20;
    private static int shopProbabilityS1 = 0;

    // Stage 2.
    private static int cardsGameProbabilityS2 = 20;
    private static int runningGameProbabilityS2 = 20;
    private static int combatGameProbabilityS2 = 20;
    private static int cauldronGameProbabilityS2 = 20;
    private static int shopProbabilityS2 = 0;

    // Stage 3.
    private static int cardsGameProbabilityS3 = 20;
    private static int runningGameProbabilityS3 = 20;
    private static int combatGameProbabilityS3 = 20;
    private static int cauldronGameProbabilityS3 = 20;
    private static int shopProbabilityS3 = 0;

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

        float delay = 2f;
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
        if (currentGameStage == 1)
            return GetProbability(cardsGameProbabilityS1, runningGameProbabilityS1, combatGameProbabilityS1, cauldronGameProbabilityS1, shopProbabilityS1);
        else if (currentGameStage == 2)
            return GetProbability(cardsGameProbabilityS2, runningGameProbabilityS2, combatGameProbabilityS2, cauldronGameProbabilityS2, shopProbabilityS2);
        else if (currentGameStage == 3)
            return GetProbability(cardsGameProbabilityS3, runningGameProbabilityS3, combatGameProbabilityS3, cauldronGameProbabilityS3, shopProbabilityS3);
        else if (currentGameStage == 4)
            return new List<string> { "TheEndWin" };
        else 
            return new List<string>();
    }

    private static List<string> GetProbability(int cardsProbability, int runningProbability, int combatProbability, int cauldronProbability, int shopProbability) {
        List<string> probabilities = new List<string>(); ;

        for (int i = 1; i <= cardsProbability; i++)
            probabilities.Add(cardsGameName);

        for (int j = 1; j <= runningProbability; j++)
            probabilities.Add(runningGameName);

        for (int k = 1; k <= combatProbability; k++)
            probabilities.Add(combatGameName);

        for (int l = 1; l <= cauldronProbability; l++)
            probabilities.Add(cauldronGameName);

        for (int m = 1; m <= shopProbability; m++)
            probabilities.Add(shopSceneName);

        return probabilities;
    }
}
        /*if (currentGameStage == 1) {
            return new List<string> {
                cardsGameName, cardsGameName, cardsGameName, cardsGameName, cardsGameName, cardsGameName, cardsGameName, runningGameName, runningGameName, runningGameName,
                runningGameName, runningGameName, combatGameName, combatGameName, combatGameName, cauldronGameName, cauldronGameName, cauldronGameName,  shopSceneName, shopSceneName
            };
        } else if (currentGameStage == 2) {
            return new List<string> {
                cardsGameName, cardsGameName, cardsGameName, cardsGameName, cardsGameName, cardsGameName, cardsGameName, runningGameName, runningGameName, runningGameName,
                runningGameName, runningGameName, combatGameName, combatGameName, combatGameName, cauldronGameName, cauldronGameName, cauldronGameName,  shopSceneName, shopSceneName
            };
        } else if (currentGameStage == 3) {
            return new List<string> {
                cardsGameName, cardsGameName, cardsGameName, cardsGameName, cardsGameName, cardsGameName, cardsGameName, runningGameName, runningGameName, runningGameName,
                runningGameName, runningGameName, combatGameName, combatGameName, combatGameName, cauldronGameName, cauldronGameName, cauldronGameName,  shopSceneName, shopSceneName
            };
        } else if(currentGameStage == 4) {
            return new List<string> { "TheEndWin" };
        } else {
            return new List<string>();
        }*/