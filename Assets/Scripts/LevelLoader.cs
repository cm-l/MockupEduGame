using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 2f;

    void Update()
    {
        if(TMPController.lineController == 10){
            StartCoroutine(LoadNextLevelWithDelay());
            TMPController.lineController = 0;
        }
    }

    IEnumerator LoadNextLevelWithDelay()
    {
        // Odtwarzanie animacji przez 2 sekundy
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(2);

        // Zmiana sceny
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
