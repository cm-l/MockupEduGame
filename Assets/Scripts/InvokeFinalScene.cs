using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InvokeFinalScene : MonoBehaviour {
 
    void Start()
    {
        Invoke("TurnOnLastScene", 15f);
    }

    private void TurnOnLastScene() {
        SceneManager.LoadScene("TheEnd");
    }
}
