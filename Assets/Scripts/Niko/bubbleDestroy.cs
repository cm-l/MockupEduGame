using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleDestroy : MonoBehaviour
{
    public ParticleSystem ps;

    public void RemoveMe()
    {
        Debug.Log("Destroyable's remove function is called on " + name);
        GameObject go = Instantiate(ps.gameObject, transform.position, Quaternion.identity);
        Destroy(go, 2.0f);
        Destroy(this.gameObject);
    }
}
