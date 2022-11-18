using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public ParticleSystem ps;
    public void RemoveMe() {
        Debug.Log("Destroyable's remove function is called on " + name);
        GameObject go = Instantiate(ps.gameObject, transform.position, Quaternion.identity);
        Destroy(go, 10.0f);
        Destroy(this.gameObject);
    }

}
