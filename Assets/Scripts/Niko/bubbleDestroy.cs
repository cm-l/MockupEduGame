using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleDestroy : MonoBehaviour
{
    bool evenScript = true;
    public ParticleSystem ps;
    bottleChange bChange; 

    public void Start()
    {
        bChange = GameObject.FindGameObjectWithTag("Bottle").
            GetComponent<bottleChange>();
    }

    public void RemoveMe()
    {
        if (evenScript)
        {
            int rValue = bubbleMath.rValue;
            if (rValue % 2 == 0)
            { 
                bChange.changeMaterialUp();
                GameObject go = Instantiate(ps.gameObject, transform.position,
                    Quaternion.identity);
                Destroy(go, 2.0f);
                Destroy(this.gameObject);
            } else
            {
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
