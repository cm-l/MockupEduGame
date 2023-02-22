using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleGenerate : MonoBehaviour
{
    public GameObject bubble;
    public int speedModifier;
    float secoundToWait = 3f;

    void Start()
    {
        StartCoroutine(bubbleCoolDown());
        secoundToWait -= 2;
    }

    public void createBubble()
    {
        float x = 12.25f;
        float y = 3f;
        float z = 8.5f;


        float randDirectionModifierX = Random.Range(-10f, 10f);
        float randDirectionModifierY = Random.Range(10f, 20f);
        float randDirectionModifierZ = Random.Range(-10f, 10f);
        Vector3 direction = (new Vector3(0 + randDirectionModifierX, 0 + randDirectionModifierY, 0 + randDirectionModifierZ));

        GameObject bubbleInstantiated = Instantiate(bubble);
        bubbleInstantiated.AddComponent(typeof(bubbleChange));
        Rigidbody rb = bubbleInstantiated.GetComponent<Rigidbody>();
        rb.AddForce(direction * Time.deltaTime * speedModifier);
        bubbleInstantiated.AddComponent(typeof(bubbleMath));
        bubbleInstantiated.transform.position = new Vector3(x, y, z);
    }

    IEnumerator bubbleCoolDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(secoundToWait);

            createBubble();
        }

    }
}