using System.Collections;
using UnityEngine;

public class bubbleGenerate : MonoBehaviour
{
    public GameObject bubble;
    public int speedModifier = 150;
    float timeToWait = 4f; // timer to wait for first bubble
    Vector3 direction;
    public float dirRangeZ = 15;
    public float dirMaxY = 16;
    bool generate = true;

    void Start()
    {
        StartCoroutine(BubbleCoolDown());
        timeToWait = 1.75f; // timer to wait for 2nd and rest of bubbles 
       
    }

    public void CreateBubble()
    {

        float x = 12.25f;
        float y = 3.5f;
        float z = 8.5f;

        // Make position a bit random
        x += Random.Range(-1f, 1f);
        z += Random.Range(-1f, 1f);

        float randDirectionModifierY = Random.Range(4f, dirMaxY);
        float randDirectionModifierZ = Random.Range(-dirRangeZ, dirRangeZ);
        direction = new Vector3(0, 0 +
            randDirectionModifierY, 0 + randDirectionModifierZ);
        GameObject bubbleInstantiated = Instantiate(bubble);
        bubbleInstantiated.AddComponent(typeof(bubbleBehaviour));
        Rigidbody rb = bubbleInstantiated.GetComponent<Rigidbody>();
        rb.AddForce(rb.position + speedModifier * Time.deltaTime * direction);
        bubbleInstantiated.AddComponent(typeof(bubbleMath));
        bubbleInstantiated.transform.position = new Vector3(x, y, z);
    }

    IEnumerator BubbleCoolDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeToWait);
            if (generate)
            {
                CreateBubble();

            }
        }

    }

    public Vector3 GetVector3()
    {
        return direction;
    }

    public void StopGenerating()
    {
        generate = false;
    }

    public void BubbleSlowDown()
    {
        speedModifier /= 2;
    }
}
