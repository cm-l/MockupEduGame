using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public ParticleSystem ps;
    public void RemoveMe() {
        Debug.Log("Destroyable's remove function is called on " + name);
        GameObject go = Instantiate(ps.gameObject, transform.position, Quaternion.identity);
        Destroy(go, 2.0f);

        //Destroy(this.gameObject);

        // "soft" destroy
        // Not actually deleting anything, just move it away
        gameObject.GetComponent<Card>().dnPos = new Vector3(100, 100, 100);
        transform.position = new Vector3(0, -75, 0);

    }

}
