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

    public void createBubble()
    {
        float x = 12.25f;
        float y = 3f;
        float z = 8.5f;


        float randDirectionModifierX = Random.Range(-10f, 10f);
        float randDirectionModifierY = Random.Range(-10f, 10f);
        float randDirectionModifierZ = Random.Range(-10f, 10f);
        Vector3 direction = (new Vector3(0 + randDirectionModifierX, 0 + randDirectionModifierY, 0 + randDirectionModifierZ));

        GameObject bubbleInstantiated = Instantiate(bubble);
        bubbleInstantiated.AddComponent(typeof(bubbleChange));
        Rigidbody rb = bubbleInstantiated.GetComponent<Rigidbody>();
        rb.AddForce(direction * Time.deltaTime * 100, ForceMode.Impulse);
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



        //public void Update()
        //{
        //    if(Input.GetKeyUp(KeyCode.K))
        //    {
        //        createBubble();
        //    }
        //}


    }
}