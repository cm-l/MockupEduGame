using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleInteract : MonoBehaviour
{
    public GameObject bubble;
    Rigidbody bubbleInstantiatedRigidbody;
    public float speed;



    void Start()
    {
        StartCoroutine(bubbleCoolDown());
    }

    void Update()
    {
    
    }

    public void createBubble ()
    {
        float x = Random.Range(11.4f, 13.3f);
        float y = Random.Range(1.75f, 2.6f);
        float z = Random.Range(7.5f, 9.1f);

        var bubbleInstantiated = Instantiate(bubble);
        bubbleInstantiated.transform.position = new Vector3(x, y, z);
        bubbleInstantiatedRigidbody = bubbleInstantiated.GetComponent<Rigidbody>();
        float randDirectionModifierX = Random.Range(-10f, 10f);
        float randDirectionModifierY = Random.Range(-10f, 10f);
        float randDirectionModifierZ = Random.Range(-10f, 10f);
        //Freeze all rotations
        //bubbleInstantiatedRigidbody.constraints = RigidbodyConstraints.FreezeRotation;

        bubbleInstantiatedRigidbody.AddForce(new Vector3(0 + randDirectionModifierX, 0+ randDirectionModifierY, 0+randDirectionModifierZ) * speed);
        //Debug.Log("X:" + randDirectionModifierX);
        //Debug.Log("Y:" + randDirectionModifierY);
        //Debug.Log("Z:" + randDirectionModifierZ);

    }

    IEnumerator bubbleCoolDown()
    {
        while (true)
        {
            createBubble();
            yield return new WaitForSeconds(5f);
        }
    }

    
}
