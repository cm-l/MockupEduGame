using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    private PlayerController player;
    [SerializeField] private AudioClip soundtrack; 
    [SerializeField] private GameObject enemyPrefab;

    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        PlaySoundtrack();
        Instantiate(enemyPrefab, new Vector3(0f, 3.65f, 3f), Quaternion.identity);
    }

    void Update()
    {
        if (player.hp < 0) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            GameProgression.AddLevelsCompleted();
            GameProgression.UpdateGameStage();
            Debug.Log("LevelsCompleted: " + GameProgression.GetLevelsCompleted() + "\n  Current stage: " + GameProgression.GetCurrentGameStage());

            switch (GameProgression.GetCurrentGameStage()) {
                case 1: SceneManager.LoadSceneAsync("EnemyFight_Dungeon1"); break;
                case 2: SceneManager.LoadSceneAsync("EnemyFight_Dungeon2"); break;
                case 3: SceneManager.LoadSceneAsync("EnemyFight_Dungeon3"); break;
                case 4: SceneManager.LoadSceneAsync("TheEnd"); break;
                default: Debug.Log("Uh"); break;
            }
        }
    }

    private void PlaySoundtrack()
    {
        SoundSystemSingleton.Instance.PlayMusicSound(soundtrack);
    }
}
