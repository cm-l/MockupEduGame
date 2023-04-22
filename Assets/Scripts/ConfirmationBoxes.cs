using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ConfirmationBoxes : MonoBehaviour {

    [SerializeField] public Canvas lostGameConfirmationCanvas;
    [SerializeField] public Canvas wonGameConfirmationCanvas;
 
    public static void ShowCanvas(Canvas canvasToShow) {
        canvasToShow.gameObject.SetActive(true);
        Debug.Log("Pyk");
    }
   
}
