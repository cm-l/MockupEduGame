using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleDestroy : MonoBehaviour
{
    bool evenScript = true;
    public ParticleSystem ps;
    bottleChange bChange = new bottleChange();

    public void RemoveMe()
    {
        if (evenScript)
        {
            int rValue = bubbleMath.rValue;
            if (rValue % 2 == 0)
            {
                Debug.Log("Destroyable's remove function is called on " + name);
                bChange.changeMaterial();
                GameObject go = Instantiate(ps.gameObject, transform.position, Quaternion.identity);
                Destroy(go, 2.0f);
                Destroy(this.gameObject);
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
