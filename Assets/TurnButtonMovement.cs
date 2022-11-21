using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnButtonMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            clickedOnAnimation();
        }
    }

    public void clickedOnAnimation()
    {
        LeanTween.scale(gameObject, new Vector3(0.5f, 0.5f, 0.5f), 0.08f).setEaseInCubic().setOnComplete(popBackUp);
    }

    public void popBackUp()
    {
        LeanTween.scale(gameObject, new Vector3(1f, 1f, 1f), 0.95f).setEaseOutElastic();
    }
}
