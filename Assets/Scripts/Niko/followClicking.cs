using UnityEngine;

public class followClicking : MonoBehaviour
{
    public static int scenarioNumber = 0;

    private void Awake()
    {
        scenarioNumber = Random.Range(0, 5);
        //scenarioNumber = 4;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray toMouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool didHit = Physics.Raycast(toMouse, out RaycastHit rhInfo, 10f);

            if (didHit)
            {
                bubbleDestroy destScript = rhInfo.collider.GetComponent<bubbleDestroy>();

                // Scenario control
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
                    else if (scenarioNumber == 3)
                    {
                        destScript.RemoveMeScenario3();
                    }
                    else if (scenarioNumber == 4)
                    {
                        destScript.RemoveMeScenario4();
                    }
                    else
                    {
                        Debug.Log("Any scenario has been loaded");
                    }
                }
            }

        }
    }

    public int GetScenarioNumber()
    {
        return scenarioNumber;
    }
}
