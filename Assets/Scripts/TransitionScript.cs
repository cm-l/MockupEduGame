using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class TransitionScript : MonoBehaviour {

    private static List<string> gameScenes = new List<string> { "AdditionScene", "EnemyFight_Dungeon1", "Niko-minigierka" };
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
        scenesAmount = gameScenes.Count;
        randomIndex = UnityEngine.Random.Range(0, scenesAmount);
        SceneManager.LoadSceneAsync(gameScenes[randomIndex]);
        gameScenes.RemoveAt(randomIndex);
    }

    private void ShowShopGameChoice() {
        shopGameCanvas.gameObject.SetActive(true);
    }
}