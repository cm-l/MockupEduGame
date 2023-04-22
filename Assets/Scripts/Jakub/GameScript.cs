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

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        PlaySoundtrack();
        Instantiate(enemyPrefab, new Vector3(0f, 3.65f, 3f), Quaternion.identity);
    }

    [SerializeField] public Canvas lostGameConfirmationCanvas;
    private bool levelsCompletedAdded = false;

    void Update()
    {
        if (player.hp < 0) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            CameraController.FreezeCamera();

            if (!levelsCompletedAdded) {
                GameProgression.AddLevelsCompleted();
                GameProgression.UpdateGameStage();
                ManagerSingleton.Instance.playerGold -= HowMuchMoneyLost();
                levelsCompletedAdded = true;


                Debug.Log("LevelsCompleted: " + GameProgression.GetLevelsCompleted() + "\n  Current stage: " + GameProgression.GetCurrentGameStage());
            }
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
