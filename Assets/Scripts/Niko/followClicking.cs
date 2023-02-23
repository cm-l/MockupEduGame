/* 
 * Scenario 0 -> check if the number is even
 * Scenario 1 -> check if the number is uneven
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followClicking : MonoBehaviour
{
    public int scenarioNumber;

    private void Start()
    {
        scenarioNumber = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray toMouse = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rhInfo;
            bool didHit = Physics.Raycast(toMouse, out rhInfo, 10f);

            if (didHit)
            {
                bubbleDestroy destScript = rhInfo.collider.GetComponent<bubbleDestroy>();

                if (destScript)
                {
                    if (scenarioNumber == 0)
                    {
                        destScript.RemoveMeScenario0();
                    }
                    else if (scenarioNumber == 1)
                    {
                        destScript.RemoveMeScenario1();
                    }
                    else if (scenarioNumber == 2)
                    {
                        destScript.RemoveMeScenario2();
                    }
                    else
                    {
                        Debug.Log("Any scenario has been loaded");
                    }
                }
            }

        }
    }

    public void changeScenario()
    {
        scenarioNumber++;
        Debug.Log("Scenario changed");
    }
}
