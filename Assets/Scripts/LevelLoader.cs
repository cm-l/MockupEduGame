using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class LevelLoader : MonoBehaviour {
    
    private int numberOfRowsBeforeChange = 10; // Ile szeregów przeciwników
    private float timeElapsed;

    void Update() {
        // Tu nastepuje zmiana sceny na kolejne "dzialanie"
        if(TMPController.rowCounter == numberOfRowsBeforeChange) {
            //StartCoroutine(LoadNextLevelWithDelay());
            StartCourtineWithDelay();
            TMPController.rowCounter = 0;
        }

        timeElapsed += Time.deltaTime;
        if(SceneManager.GetActiveScene().name.Equals("Cutscene") & timeElapsed > 30f){
            SceneManager.LoadScene("TransitionScene");
        }

        if(bottleChange.bottleMaterialNumber == 9 ){
            //StartCoroutine(LoadNextLevelWithDelay());
            Invoke("StartCourtineWithDelay", 2f);
        }
    }

    [SerializeField] private Animator transition;
    [SerializeField] private int transitionTime = 3;

    IEnumerator LoadNextLevelWithDelay() {
        // Odtwarzanie animacji przez [transitionTime] sekund
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        // Zmiana sceny + | - | * | /
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartCourtineWithDelay(){
        StartCoroutine(LoadNextLevelWithDelay());
    }
}