using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleInteract : MonoBehaviour
{
    public GameObject bubble;
    public float speed;



    void Start()
    {
        StartCoroutine(bubbleCoolDown());
    }

    public void createBubble ()
    {
        float x = Random.Range(11.4f, 13.3f);
        float y = 3f;
        float z = Random.Range(7.5f, 9.1f);

        var bubbleInstantiated = Instantiate(bubble);
        bubbleInstantiated.AddComponent(typeof(bubbleChangeVelocity));
        bubbleInstantiated.AddComponent(typeof(bubbleMath));
        bubbleInstantiated.transform.position = new Vector3(x, y, z);
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
