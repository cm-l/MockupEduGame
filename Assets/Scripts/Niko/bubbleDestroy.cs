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
            bM = this.GetComponent<bubbleMath>();
            int rValue = bM.getrVal();
            if (rValue % 2 == 0)
            {
                Debug.Log("OK " + rValue);
                bChange.changeMaterialUp();
                GameObject go = Instantiate(ps.gameObject, transform.position,
                    Quaternion.identity);
                Destroy(go, 2.0f);
                Destroy(this.gameObject);
            } else
            {
                Debug.Log("MISTAKE " + rValue);
                bChange.changeMaterialDown();
                GameObject go = Instantiate(ps.gameObject, transform.position,
                Quaternion.identity);
                Destroy(go, 2.0f);
                Destroy(this.gameObject);
            }
        } else
        {
            Debug.Log("Even Script not activated");
        }
 
    }

    //Scenario 1
    public void RemoveMeScenario1()
    {
        if (evenScript)
        {
            bM = this.GetComponent<bubbleMath>();
            int rValue = bM.getrVal();
            if (rValue % 2 != 0)
            {
                Debug.Log("OK " + rValue);
                bChange.changeMaterialUp();
                GameObject go = Instantiate(ps.gameObject, transform.position,
                    Quaternion.identity);
                Destroy(go, 2.0f);
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("MISTAKE " + rValue);
                bChange.changeMaterialDown();
                GameObject go = Instantiate(ps.gameObject, transform.position,
                Quaternion.identity);
                Destroy(go, 2.0f);
                Destroy(this.gameObject);
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
            bM = this.GetComponent<bubbleMath>();
            int rValue = bM.getrVal();
            if (checkIfPrime(rValue))
            {
                Debug.Log("OK " + rValue);
                bChange.changeMaterialUp();
                GameObject go = Instantiate(ps.gameObject, transform.position,
                    Quaternion.identity);
                Destroy(go, 2.0f);
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("MISTAKE " + rValue);
                bChange.changeMaterialDown();
                GameObject go = Instantiate(ps.gameObject, transform.position,
                Quaternion.identity);
                Destroy(go, 2.0f);
                Destroy(this.gameObject);
            }
        }
        else
        {
            Debug.Log("Even Script not activated");
        }
    }

    bool checkIfPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2) return true;
        if (number % 2 == 0) return false;
        for (int i = 3; i < number; i += 1)
            if (number % i == 0)
                return false;
        return true;
    }
}
