using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Animate : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 2f;

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}

