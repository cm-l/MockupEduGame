using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    private int numberOfRowsBeforeChange = 10; // wcze�niej 10!

    void Update() {
        // Tu nastepuje zmiana sceny na kolejne "dzialanie"
        if(TMPController.rowCounter == numberOfRowsBeforeChange) {
            StartCoroutine(LoadNextLevelWithDelay());
            TMPController.rowCounter = 0;
        }
    }

    public Animator transition;
    public float transitionTime = 2f;

    IEnumerator LoadNextLevelWithDelay() {
        // Odtwarzanie animacji przez 2 sekundy
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2);

        // Zmiana sceny
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}