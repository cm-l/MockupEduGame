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
    [SerializeField] private AudioClip gameMusicSound;
    [SerializeField] private AudioClip successSound;



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
            textUI.text = "Pop the bubbles with even numbers!";
        }
        else if (scenarioNumber == 1)
        {
            textUI.text = "Pop the bubbles with odd numbers!";
        }
        else if (scenarioNumber == 2)
        {
            textUI.text = "Pop the bubbles with prime numbers!";
        }
        else if (scenarioNumber == 3)
        {
            textUI.text = "Pop the bubbles with numbers divisible by 3 or 5";
        }
        else
        {
            textUI.text = "ERROR: No scenario has been loaded";
        }

        textUI.enabled = true;
        StartCoroutine(disableTextAndPlayMusic());

        readyForChangingScenario = true;
    }


    void Update()
    {
        // What happens when user wins
        bottleMaterialNumber = bChange.getBottleMaterialNumber();


        // Only for tests
        // TODO delete after Z debug

        if (bottleMaterialNumber == 9 || Input.GetKeyDown(KeyCode.Z))
        {
     
            SoundSystemSingleton.Instance.StopTheMusic();
            EndGame();

            // PROBABLY NOT NEEDED
            //NextScenario();
            Invoke("LoadScene", 3);

        }
    }

    IEnumerator disableTextAndPlayMusic()
    {
        yield return new WaitForSeconds(4f);
        textUI.enabled = false;
        SoundSystemSingleton.Instance.PlayMusicSound(gameMusicSound);

    }

    void LoadScene()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene(4);
        cauldron.GetComponent<Animate>().LoadNextLevel();

        //lower bound inclusive - upper bound EXCLUSIVE
        //int indexScene = UnityEngine.Random.Range(0, 3); //TODO fix based on number in build order
        //Debug.Log("Next scene number: " + indexScene);
        //SceneManager.LoadScene(indexScene);
    }

    void EndGame()
    {
        GameObject[] bubbles = GameObject.FindGameObjectsWithTag("Bubble");
        foreach (GameObject bubble in bubbles)
        {
            bubble.GetComponentInParent<bubbleBehaviour>().popBubble();
        }
        cauldron.GetComponent<bubbleGenerate>().stopGenerating();
        Invoke("PrepareForSummary", 0.5f);
    }

    void PrepareForSummary()
    {
        textUI.text = "Gratulacje!";
        textUI.enabled = true;
        Invoke("PlayEndSound", 0.2f);
    }

    void PlayEndSound()
    {
        SoundSystemSingleton.Instance.PlaySfxSound(successSound);

    }


    // Scenario control
    // PROBABLY NOT NEEDED
    //void NextScenario()
    //{
    //    if (readyForChangingScenario)
    //    {
    //        if (scenarioNumber < maxNumOfScenarios)
    //        {
    //            fClicking.changeScenario();
    //        }
    //        else
    //        {
    //            fClicking.showMenu();
    //        }
    //        readyForChangingScenario = false;
    //    }

    //}

}
