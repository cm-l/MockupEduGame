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
        float randDirectionModifier = Random.Range(10f, 20f);
        bubbleInstantiatedRigidbody.AddForce(new Vector3(0, 0, 0) * speed);
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
