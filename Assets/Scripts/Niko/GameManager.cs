/* 
 * Scenario 0 -> check if the number is even
 * Scenario 1 -> check if the number is uneven
 * Scenario 2 -> check if the number is prime number
 * Scenario 3 -> check if the number can be divided by 3 or 5
 * 
 * All scenario controls cen be found in GameManager, followClicking, 
 * bubbleDestroy and bubbleBehaviour scripts
 */

using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int bottleMaterialNumber;
    int scenarioNumber;
    BottleChange bChange_N;
    GameObject gmTextUI;
    TextMeshProUGUI textUI;
    TextMeshProUGUI userTask;
    GameObject cauldron;
    FollowClicking fClicking;
    [SerializeField] private AudioClip gameMusicSound;
    [SerializeField] private AudioClip successSound;
    bool inGameMode;
    int avgFrameRate;
    bool checkFPS;
    int fpsTarget;




    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        fpsTarget = 60;
        Application.targetFrameRate = fpsTarget;
        bChange_N = GameObject.FindGameObjectWithTag("Bottle").
            GetComponent<BottleChange>();
        gmTextUI = GameObject.Find("textUI");
        textUI = gmTextUI.GetComponent<TextMeshProUGUI>();
        userTask = GameObject.Find("User Task").GetComponent<TextMeshProUGUI>();
        userTask.enabled = false;
        cauldron = GameObject.Find("SD_Prop_Cauldron_01");
        fClicking = cauldron.GetComponent<FollowClicking>();
        scenarioNumber = fClicking.GetScenarioNumber();

        // Choose the right intoduction text for given scenario
        if (scenarioNumber == 0)
        {
            textUI.text = "Pop the bubbles with even numbers";
            userTask.text = "Pop the bubbles with even numbers";
        }
        else if (scenarioNumber == 1)
        {
            textUI.text = "Pop the bubbles with odd numbers";
            userTask.text = "Pop the bubbles with odd numbers";
        }
        else if (scenarioNumber == 2)
        {
            textUI.text = "Pop the bubbles with prime numbers";
            userTask.text = "Pop the bubbles with prime numbers";
        }
        else if (scenarioNumber == 3)
        {
            textUI.text = "Pop the bubbles with numbers divisible by 3 or 5";
            userTask.text = "Pop the bubbles with numbers divisible by 3 or 5";
        }
        else
        {
            textUI.text = "ERROR: Any scenario has been loaded";
        }

        textUI.enabled = true;
        StartCoroutine(DisableTextAndPlayMusic());
        inGameMode = true;
        checkFPS = true;
        Invoke("SetSpeedModifier", 4.1f);
    }


    void Update()
    {
        // What happens when user wins
        bottleMaterialNumber = bChange_N.GetBottleMaterialNumber();

        if (bottleMaterialNumber == 9)
        {
     
            SoundSystemSingleton.Instance.StopTheMusic();
            if(inGameMode)
            {
                EndGame();
                Invoke("LoadScene", 3);
                inGameMode = false;
            }
            

        }

        // Check FPS
        if (checkFPS)
        {
            float current = (int)(1f / Time.unscaledDeltaTime); ;
            current = Time.frameCount / Time.time;
            avgFrameRate = (int)current;
            Invoke("StopCheckingFPS", 4f);
        }


    }

    IEnumerator DisableTextAndPlayMusic()
    {
        yield return new WaitForSeconds(4f);
        textUI.enabled = false;
        SoundSystemSingleton.Instance.PlayMusicSound(gameMusicSound);
        GameObject.FindGameObjectWithTag("Bottle").transform.position = new Vector3(17.63f, 4.28f, 10.1f);
        userTask.enabled = true;

    }

    void LoadScene()
    {
        cauldron.GetComponent<Animate>().LoadNextLevel();

        //lower bound inclusive - upper bound EXCLUSIVE
        //int indexScene = UnityEngine.Random.Range(0, 3); //TODO fix based on number in build order
        //SceneManager.LoadScene(indexScene);
    }

    void EndGame()
    {
        GameObject[] bubbles = GameObject.FindGameObjectsWithTag("Bubble");
        foreach (GameObject bubble in bubbles)
        {
            bubble.GetComponentInParent<BubbleBehaviour>().PopBubble();
        }
        cauldron.GetComponent<BubbleGenerate>().StopGenerating();
        Invoke("PrepareForSummary", 1f);
    }

    void PrepareForSummary()
    {
        textUI.text = "Congratulations!";
        textUI.enabled = true;
        userTask.enabled = false;
        SoundSystemSingleton.Instance.PlayOtherSound(successSound);
    }

    void StopCheckingFPS()
    {
        checkFPS = false;
    }

    void SetSpeedModifier()
    {
        if (!checkFPS)
        {
            Debug.Log("Setting speed modifier");
            Debug.Log("FPS:" + avgFrameRate);
            if (avgFrameRate <= 30)
            {
                fpsTarget = 30;
                gameObject.GetComponent<BubbleGenerate>().BubbleSlowDown();
            }
        }
    }

}

