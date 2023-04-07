using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BubbleDestroy : MonoBehaviour
{
    bool evenScript = true;
    public ParticleSystem ps;
    BottleChange bChange;
    BubbleMath bM;
    [SerializeField] private AudioClip popSound;


    public void Start()
    {
        bChange = GameObject.FindGameObjectWithTag("Bottle").
            GetComponent<BottleChange>();
    }

    //Scenario 0
    public void RemoveMeScenario0()
    {
        if (evenScript)
        {
            bM = this.GetComponent<BubbleMath>();
            int rValue = bM.GetrVal();
            if (rValue % 2 == 0)
            {
                Debug.Log("OK " + rValue);
                bChange.ChangeMaterialUp();
                GameObject go = Instantiate(ps.gameObject, transform.position,
                    Quaternion.identity);
                SoundSystemSingleton.Instance.PlaySfxSound(popSound);

                Destroy(go, 2.0f);
                Destroy(this.gameObject);
            } else
            {
                Debug.Log("MISTAKE " + rValue);
                bChange.ChangeMaterialDown();
                GameObject go = Instantiate(ps.gameObject, transform.position,
                Quaternion.identity);
                SoundSystemSingleton.Instance.PlaySfxSound(popSound);

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
            bM = this.GetComponent<BubbleMath>();
            int rValue = bM.GetrVal();
            if (rValue % 2 != 0)
            {
                Debug.Log("OK " + rValue);
                bChange.ChangeMaterialUp();
                GameObject go = Instantiate(ps.gameObject, transform.position,
                    Quaternion.identity);
                SoundSystemSingleton.Instance.PlaySfxSound(popSound);

                Destroy(go, 2.0f);
                Destroy(this.gameObject);

            }
            else
            {
                Debug.Log("MISTAKE " + rValue);
                bChange.ChangeMaterialDown();
                GameObject go = Instantiate(ps.gameObject, transform.position,
                Quaternion.identity);
                SoundSystemSingleton.Instance.PlaySfxSound(popSound);

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
            bM = this.GetComponent<BubbleMath>();
            int rValue = bM.GetrVal();
            if (CheckIfPrime(rValue))
            {
                Debug.Log("OK " + rValue);
                bChange.ChangeMaterialUp();
                GameObject go = Instantiate(ps.gameObject, transform.position,
                    Quaternion.identity);
                SoundSystemSingleton.Instance.PlaySfxSound(popSound);

                Destroy(go, 2.0f);
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("MISTAKE " + rValue);
                bChange.ChangeMaterialDown();
                GameObject go = Instantiate(ps.gameObject, transform.position,
                Quaternion.identity);
                SoundSystemSingleton.Instance.PlaySfxSound(popSound);

                Destroy(go, 2.0f);
                Destroy(this.gameObject);
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
            bM = this.GetComponent<BubbleMath>();
            int rValue = bM.GetrVal();
            if (((rValue % 3 == 0) || (rValue % 5 == 0)) && (rValue != 0))
            {
                Debug.Log("OK " + rValue);
                bChange.ChangeMaterialUp();
                GameObject go = Instantiate(ps.gameObject, transform.position,
                    Quaternion.identity);
                SoundSystemSingleton.Instance.PlaySfxSound(popSound);

                Destroy(go, 2.0f);
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("MISTAKE " + rValue);
                bChange.ChangeMaterialDown();
                GameObject go = Instantiate(ps.gameObject, transform.position,
                Quaternion.identity);
                SoundSystemSingleton.Instance.PlaySfxSound(popSound);

                Destroy(go, 2.0f);
                Destroy(this.gameObject);
            }
        }
        else
        {
            Debug.Log("Even Script not activated");
        }
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

    //AUTO-REMOVE
    public void AutoRemoveScenario0()
    {
        if (evenScript)
        {
            bM = this.GetComponent<BubbleMath>();
            int rValue = bM.GetrVal();
            if (rValue % 2 == 0)
            {
                bChange.ChangeMaterialDown();
                GameObject go = Instantiate(ps.gameObject, transform.position,
                    Quaternion.identity);
                SoundSystemSingleton.Instance.PlaySfxSound(popSound);

                Destroy(go, 2.0f);
                Destroy(this.gameObject);
            }
            else
            {
                GameObject go = Instantiate(ps.gameObject, transform.position,
                Quaternion.identity);
                SoundSystemSingleton.Instance.PlaySfxSound(popSound);

                Destroy(go, 2.0f);
                Destroy(this.gameObject);
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
            bM = this.GetComponent<BubbleMath>();
            int rValue = bM.GetrVal();
            if (rValue % 2 != 0)
            {
                bChange.ChangeMaterialDown();
                GameObject go = Instantiate(ps.gameObject, transform.position,
                    Quaternion.identity);
                SoundSystemSingleton.Instance.PlaySfxSound(popSound);

                Destroy(go, 2.0f);
                Destroy(this.gameObject);
            }
            else
            {
                GameObject go = Instantiate(ps.gameObject, transform.position,
                Quaternion.identity);
                SoundSystemSingleton.Instance.PlaySfxSound(popSound);

                Destroy(go, 2.0f);
                Destroy(this.gameObject);
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
            bM = this.GetComponent<BubbleMath>();
            int rValue = bM.GetrVal();
            if (CheckIfPrime(rValue))
            {
                bChange.ChangeMaterialDown();
                GameObject go = Instantiate(ps.gameObject, transform.position,
                    Quaternion.identity);
                SoundSystemSingleton.Instance.PlaySfxSound(popSound);

                Destroy(go, 2.0f);
                Destroy(this.gameObject);
            }
            else
            {
                GameObject go = Instantiate(ps.gameObject, transform.position,
                Quaternion.identity);
                SoundSystemSingleton.Instance.PlaySfxSound(popSound);

                Destroy(go, 2.0f);
                Destroy(this.gameObject);
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
            bM = this.GetComponent<BubbleMath>();
            int rValue = bM.GetrVal();
            if (((rValue % 3 == 0) || (rValue % 5 == 0)) && (rValue != 0))
            {
                bChange.ChangeMaterialDown();
                GameObject go = Instantiate(ps.gameObject, transform.position,
                    Quaternion.identity);
                SoundSystemSingleton.Instance.PlaySfxSound(popSound);

                Destroy(go, 2.0f);
                Destroy(this.gameObject);
            }
            else
            {
                GameObject go = Instantiate(ps.gameObject, transform.position,
                Quaternion.identity);
                SoundSystemSingleton.Instance.PlaySfxSound(popSound);

                Destroy(go, 2.0f);
                Destroy(this.gameObject);
            }
        }
        else
        {
            Debug.Log("Even Script not activated");
        }
    }
}
