/* 
 * Scenario 0 -> check if the number is even
 * Scenario 1 -> check if the number is uneven
 * Scenario 2 -> check if the number is prime number
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
    int maxNumOfScenarios = 2;
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
        if (scenarioNumber == 1)
        {
            textUI.text = "Przebijaj bańki z liczbami nieparzystymi";
        }
        if (scenarioNumber == 2)
        {
            textUI.text = "Przebijaj bańki z liczbami pierwszymi";
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
