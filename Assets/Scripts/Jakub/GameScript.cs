using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using TMPro;

public class GameScript : MonoBehaviour
{
    private PlayerController player;
    [SerializeField] private AudioClip soundtrack; 
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private TextMeshProUGUI informationBox;
    public EnemyController enemy;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        PlaySoundtrack();
        Instantiate(enemyPrefab, new Vector3(0f, 3.65f, 3f), Quaternion.identity);

        enemy = GameObject.FindWithTag("Enemy").GetComponent<EnemyController>();
    }

    [SerializeField] public Canvas winGameConfirmationCanvas;
    [SerializeField] public Canvas lostGameConfirmationCanvas;
    private bool hasEnded = false;

    void Update()
    {
        // Wygrana
        if (enemy.GetEnemyHP() < 0 && !hasEnded) {
            hasEnded = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            CameraController.FreezeCamera();

            GameProgression.AddLevelsCompleted();
            GameProgression.UpdateGameStage();
            
            try {
                ManagerSingleton.Instance.playerGold += 100;   
            } catch (NullReferenceException e) {
                Debug.Log("Najpierw odpal scenê karcianki. (" + e + ")");
            }

            Debug.Log("LevelsCompleted: " + GameProgression.GetLevelsCompleted() + "\n  Current stage: " + GameProgression.GetCurrentGameStage());
            ConfirmationBoxes.ShowCanvas(winGameConfirmationCanvas);
        }

        // Przegrana
        if (player.hp < 0 && !hasEnded) {
            hasEnded = true;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            CameraController.FreezeCamera();

            GameProgression.AddLevelsCompleted();
            GameProgression.UpdateGameStage();

            try {
                ManagerSingleton.Instance.playerGold -= HowMuchMoneyLost();
            }
            catch (NullReferenceException e) {
                Debug.Log("Najpierw odpal scenê karcianki. (" + e + ")");
                informationBox.text = "You have lost $" + 0;
            }
            

            Debug.Log("LevelsCompleted: " + GameProgression.GetLevelsCompleted() + "\n  Current stage: " + GameProgression.GetCurrentGameStage());
 
            informationBox.text = "You have lost $"+ HowMuchMoneyLost();
            ConfirmationBoxes.ShowCanvas(lostGameConfirmationCanvas);
        }

    }

    private void PlaySoundtrack()
    {
        SoundSystemSingleton.Instance.PlayMusicSound(soundtrack);
    }

    private static int HowMuchMoneyLost() {
        try {
            if (ManagerSingleton.Instance.playerGold >= 100)
                return 100;
            else
                return ManagerSingleton.Instance.playerGold;
        }
        catch (NullReferenceException e) {
            // handle the exception
            Debug.Log("Najpierw odpal scenê karcianki. (" + e + ")");
            return 0;
        }
    }
}
