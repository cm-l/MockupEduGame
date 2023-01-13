using System.Collections;
using System.Collections.Generic;
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

    public void RemoveMe()
    {
        if (evenScript)
        {
            bM = this.GetComponent<bubbleMath>();
            int rValue = bM.getrVal();
            if (rValue % 2 == 0 && rValue != 0)
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
}
