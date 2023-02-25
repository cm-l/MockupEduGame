/* 
 * Scenario 0 -> check if the number is even
 * Scenario 1 -> check if the number is uneven
 * Scenario 2 -> check if the number is prime number
 * Scenario 3 -> check if the number can be divided by 3 or 5
 * 
 * All scenario controls cen be found in GameManager, followClicking, 
 * bubbleDestroy and bubbleBehaviour scripts
 */

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int bottleMaterialNumber;
    int scenarioNumber;
    bottleChange bChange;
    GameObject gmTextUI;
    TextMeshProUGUI textUI;
    GameObject cauldron;
    followClicking fClicking;
    int maxNumOfScenarios = 3;
    bool readyForChangingScenario;

    void Start()
    {
        bChange = GameObject.FindGameObjectWithTag("Bottle").
            GetComponent<bottleChange>();
        gmTextUI = GameObject.Find("textUI");
        textUI = gmTextUI.GetComponent<TextMeshProUGUI>();
        cauldron = GameObject.Find("SD_Prop_Cauldron_01");
        fClicking = cauldron.GetComponent<followClicking>();
        scenarioNumber = fClicking.getScenarioNumber();
        Debug.Log("Scenario: " + scenarioNumber);

        // Choose the right intoduction text for given scenario
        if (scenarioNumber == 0)
        {
            textUI.text = "Przebijaj bańki z liczbami parzystymi";
        }
        else if (scenarioNumber == 1)
        {
            textUI.text = "Przebijaj bańki z liczbami nieparzystymi";
        }
        else if (scenarioNumber == 2)
        {
            textUI.text = "Przebijaj bańki z liczbami pierwszymi";
        }
        else if (scenarioNumber == 3)
        {
            textUI.text = "Przebijaj bańki z liczbami podzielnymi przez 3 lub 5";
        }
        else
        {
            textUI.text = "ERROR: No scenario has been loaded";
        }
       


        textUI.enabled = true;
        StartCoroutine(disableText());

        readyForChangingScenario = true;
    }

    void Update()
    {
        // What happens when user wins
        bottleMaterialNumber = bChange.getBottleMaterialNumber();
        if (bottleMaterialNumber == 6)
        {
            textUI.text = "Gratulacje!";
            textUI.enabled = true;
            NextScenario();
            Invoke("LoadScene", 3);
        }
    }

    IEnumerator disableText()
    {
        yield return new WaitForSeconds(3f);
        textUI.enabled = false;

    }

    void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Scenario control
    void NextScenario()
    {
        if (readyForChangingScenario)
        {
            if (scenarioNumber < maxNumOfScenarios)
            {
                fClicking.changeScenario();
            }
            else
            {
                fClicking.setBaseScenario();
            }
            readyForChangingScenario = false;
        }
        
    }

}
