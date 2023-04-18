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
        if (player.hp < 0)
            SceneManager.LoadScene(1);
    }

    private void PlaySoundtrack()
    {
        SoundSystemSingleton.Instance.PlayMusicSound(soundtrack);
    }
}
