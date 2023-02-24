using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleGenerate : MonoBehaviour
{
    public GameObject bubble;
    public int speedModifier;
    float secoundToWait = 3f;
    Vector3 direction;
    public float dirRangeXY;

    void Start()
    {
        StartCoroutine(bubbleCoolDown());
        secoundToWait = 1.75f;
    }

    public void createBubble()
    {

        float x = 12.25f;
        float y = 3f;
        float z = 8.5f;

        // Make position a bit random

        x = x + Random.Range(-1f, 1f);
        z = z + Random.Range(-1f, 1f);



        float randDirectionModifierX = Random.Range(-dirRangeXY, dirRangeXY);
        float randDirectionModifierY = Random.Range(0f, 20f);
        float randDirectionModifierZ = Random.Range(-dirRangeXY, dirRangeXY);
        direction = (new Vector3(0 + randDirectionModifierX, 0 +
            randDirectionModifierY, 0 + randDirectionModifierZ));
        //direction = (new Vector3(0, 0 +
        //  randDirectionModifierY));
        GameObject bubbleInstantiated = Instantiate(bubble);
        bubbleInstantiated.AddComponent(typeof(bubbleBehaviour));
        Rigidbody rb = bubbleInstantiated.GetComponent<Rigidbody>();
        rb.AddForce(rb.position + direction * Time.deltaTime * speedModifier);
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

    public Vector3 getVector3()
    {
        return direction;
    }

}