using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class InvokeFinalScene : MonoBehaviour {
 
    void Start() {
        Invoke("TurnOnLastScene", 14f);
    }

    private void TurnOnLastScene() {
        SceneManager.LoadScene("TheEnd");
    }
}
