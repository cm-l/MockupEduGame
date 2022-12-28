using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleDestroy : MonoBehaviour
{
    bool evenScript = true;
    public ParticleSystem ps;

    public void RemoveMe()
    {
        if (evenScript)
        {
            int rValue = bubbleMath.rValue;
            if (rValue % 2 == 0)
            {
                Debug.Log("Destroyable's remove function is called on " + name);
                GameObject go = Instantiate(ps.gameObject, transform.position, Quaternion.identity);
                Destroy(go, 2.0f);
                Destroy(this.gameObject);
                //Debug.Log(rValue);
            } else
            {
                Debug.Log("MISTAKE");
            }
        } else
        {
            Debug.Log("Even Script not activated");
        }
 
    }
}
