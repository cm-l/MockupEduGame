using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bubbleDestroy : MonoBehaviour
{
    bool evenScript = true;
    public ParticleSystem ps;
    bottleChange bChange;
    bubbleMath bM;
    [SerializeField] private AudioClip popSound;
   

    public void Start()
    {
        bChange = GameObject.FindGameObjectWithTag("Bottle").
            GetComponent<bottleChange>();
    }

    //Scenario 0
    public void RemoveMeScenario0()
    {
        if (evenScript)
        {
            int rValue = prepareRValueForChecking();
            if (rValue % 2 == 0)
            {
                PerformActionsForPoppedCorrectly(rValue);
            }
            else
            {
                PerformActionsForPoppedIncorrectly(rValue);
            }
        }
        else
        {
            Debug.Log("Even Script not activated");
        }
 
    }


    //Scenario 1
    public void RemoveMeScenario1()
    {
        if (evenScript)
        {
            int rValue = prepareRValueForChecking();
            if (rValue % 2 != 0)
            {
                PerformActionsForPoppedCorrectly(rValue);
            }
            else
            {
                PerformActionsForPoppedIncorrectly(rValue);
            }
        }
        else
        {
            Debug.Log("Even Script not activated");
        }
    }

    //Scenario 2
    public void RemoveMeScenario2()
    {
        if (evenScript)
        {
            int rValue = prepareRValueForChecking();
            if (CheckIfPrime(rValue))
            {
                PerformActionsForPoppedCorrectly(rValue);
            }
            else
            {
                PerformActionsForPoppedIncorrectly(rValue);
            }
        }
        else
        {
            Debug.Log("Even Script not activated");
        }
    }

    //Scenario 3
    public void RemoveMeScenario3()
    {
        if (evenScript)
        {
            int rValue = prepareRValueForChecking();
            if (((rValue % 3 == 0) || (rValue % 5 == 0)) && (rValue != 0))
            {
                PerformActionsForPoppedCorrectly(rValue);
            }
            else
            {
                PerformActionsForPoppedIncorrectly(rValue);
            }
        }
        else
        {
            Debug.Log("Even Script not activated");
        }
    }

    // Scenario 4
    public void RemoveMeScenario4()
    {
        if (evenScript)
        {
            int rValue = prepareRValueForChecking();
            if (CheckIfComposite(rValue))
            {
                PerformActionsForPoppedCorrectly(rValue);
            }
            else
            {
                PerformActionsForPoppedIncorrectly(rValue);
            }
        }
        else
        {
            Debug.Log("Even Script not activated");
        }
    }

    //AUTO-REMOVE
    public void AutoRemoveScenario0()
    {
        if (evenScript)
        {
            int rValue = prepareRValueForChecking();
            if (rValue % 2 == 0)
            {
                PerformActionsForNotPoppedInTime(rValue);

            }
            else
            {
                PopTheBubbleWithoutConsequences();
            }
        }
        else
        {
            Debug.Log("Even Script not activated");
        }
    }


    public void AutoRemoveScenario1()
    {
        if (evenScript)
        {
            int rValue = prepareRValueForChecking();
            if (rValue % 2 != 0)
            {
                PerformActionsForNotPoppedInTime(rValue);

            }
            else
            {
                PopTheBubbleWithoutConsequences();
            }
        }
        else
        {
            Debug.Log("Even Script not activated");
        }
    }


    public void AutoRemoveScenario2()
    {
        if (evenScript)
        {
            int rValue = prepareRValueForChecking();
            if (CheckIfPrime(rValue))
            {
                PerformActionsForNotPoppedInTime(rValue);
            }
            else
            {
                PopTheBubbleWithoutConsequences();
            }
        }
        else
        {
            Debug.Log("Even Script not activated");
        }
    }

    public void AutoRemoveScenario3()
    {
        if (evenScript)
        {
            int rValue = prepareRValueForChecking();
            if (((rValue % 3 == 0) || (rValue % 5 == 0)) && (rValue != 0))
            {
                PerformActionsForNotPoppedInTime(rValue);

            }
            else
            {
                PopTheBubbleWithoutConsequences();
            }
        }
        else
        {
            Debug.Log("Even Script not activated");
        }
    }


    public void AutoRemoveScenario4()
    {
        if (evenScript)
        {
            int rValue = prepareRValueForChecking();
            if (CheckIfComposite(rValue))
            {
                PerformActionsForNotPoppedInTime(rValue);

            }
            else
            {
                PopTheBubbleWithoutConsequences();
            }
        }
        else
        {
            Debug.Log("Even Script not activated");
        }
    }



    private void PerformActionsForPoppedCorrectly(int rValue)
    {
        Debug.Log("OK " + rValue);
        GameManager.ok++;
        bChange.ChangeMaterialUp();
        GameObject go = Instantiate(ps.gameObject, transform.position,
            Quaternion.identity);
        SoundSystemSingleton.Instance.PlaySfxSound(popSound);

        Destroy(go, 2.0f);
        Destroy(this.gameObject);
    }

    private void PerformActionsForPoppedIncorrectly(int rValue)
    {
        Debug.Log("MISTAKE " + rValue);
        GameManager.mistake++;
        bChange.ChangeMaterialDown();
        GameObject go = Instantiate(ps.gameObject, transform.position,
        Quaternion.identity);
        SoundSystemSingleton.Instance.PlaySfxSound(popSound);

        Destroy(go, 2.0f);
        Destroy(this.gameObject);
    }

    private int prepareRValueForChecking()
    {
        bM = this.GetComponent<bubbleMath>();
        int rValue = bM.GetrVal();
        return rValue;
    }
    private void PerformActionsForNotPoppedInTime(int rValue)
    {
        bChange.ChangeMaterialDown();
        GameManager.notPopped++;
        GameObject go = Instantiate(ps.gameObject, transform.position,
            Quaternion.identity);
        SoundSystemSingleton.Instance.PlaySfxSound(popSound);
        Debug.Log("Not in time: " + rValue);
        Destroy(go, 2.0f);
        Destroy(this.gameObject);
    }

    private void PopTheBubbleWithoutConsequences()
    {
        GameObject go = Instantiate(ps.gameObject, transform.position,
        Quaternion.identity);
        SoundSystemSingleton.Instance.PlaySfxSound(popSound);

        Destroy(go, 2.0f);
        Destroy(this.gameObject);
    }

    bool CheckIfPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;
        for (int i = 3; i < number; i += 1)
            if (number % i == 0)
                return false;
        return true;
    }

    bool CheckIfComposite(int number)
    {
        bool isComposite = !CheckIfPrime(number);
        if (number == 0 || number == 1)
        {
            isComposite = false;
        }
        return isComposite;
    }

}
