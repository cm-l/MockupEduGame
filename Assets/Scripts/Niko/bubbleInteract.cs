using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleInteract : MonoBehaviour
{
    public GameObject bubble;
    

    void Start()
    {
        StartCoroutine(bubbleCoolDown());
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    Vector3 mousePos = Input.mousePosition;
        //    {
        //        Debug.Log(mousePos.x);
        //        Debug.Log(mousePos.y);
        //    }
        //}
    }

    public void createBubble ()
    {
        float x = Random.Range(11.4f, 13.3f);
        float y = Random.Range(1.75f, 2.6f);
        float z = Random.Range(7.5f, 9.1f);

        bubble.transform.position = new Vector3(x, y, z);
        Instantiate(bubble);
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
