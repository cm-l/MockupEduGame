using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleGenerate : MonoBehaviour
{
    public GameObject bubble;
    public float speed;

    void Start()
    {
        StartCoroutine(bubbleCoolDown());
    }

    public void createBubble ()
    {
        float x = 12.25f;
        float y = 3f;
        float z = 8.5f;

        var bubbleInstantiated = Instantiate(bubble);
        bubbleInstantiated.AddComponent(typeof(bubbleChange));
        bubbleInstantiated.AddComponent(typeof(bubbleMath));
        bubbleInstantiated.transform.position = new Vector3(x, y, z);
    }

    IEnumerator bubbleCoolDown()
    {
        while (true)
        {
            createBubble();

            yield return new WaitForSeconds(2f);

        }
    }

    
}
