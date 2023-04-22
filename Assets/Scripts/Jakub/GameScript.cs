using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class GameScript : MonoBehaviour
{
    private PlayerController player;
    [SerializeField] private AudioClip soundtrack; 
    [SerializeField] private GameObject enemyPrefab;
    private TextMeshProUGUI informationBox;

    void Start()
    {
        //informationBox = GameObject.Find("InformationLoss").GetComponent<TextMeshProUGUI>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        PlaySoundtrack();
        Instantiate(enemyPrefab, new Vector3(0f, 3.65f, 3f), Quaternion.identity);
    }

    [SerializeField] private Canvas lostGameConfirmation;
    private bool levelsCompletedAdded = false;
    void Update()
    {
        if (player.hp < 0) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            if (!levelsCompletedAdded) {
                GameProgression.AddLevelsCompleted();
                GameProgression.UpdateGameStage();
                levelsCompletedAdded = true;
            
                Debug.Log("LevelsCompleted: " + GameProgression.GetLevelsCompleted() + "\n  Current stage: " + GameProgression.GetCurrentGameStage());
            }

            //informationBox.text = "Hej";
            ShowCanvas(lostGameConfirmation);
        }
    }

    private void PlaySoundtrack()
    {
        SoundSystemSingleton.Instance.PlayMusicSound(soundtrack);
    }
    
    public void ShowCanvas(Canvas canvasToShow) {
        canvasToShow.gameObject.SetActive(true);
    }
}
