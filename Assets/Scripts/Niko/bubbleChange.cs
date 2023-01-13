using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleChange : MonoBehaviour
{
    Rigidbody rb;
    Vector3 direction;
    float speed = 35;
    Vector3 limit = new Vector3(1, 1, 1);
    bool isBubbleDead;
    public ParticleSystem ps;



    void Start()
    {
        //float randDirectionModifierX = Random.Range(-10f, 10f);
        //float randDirectionModifierY = Random.Range(-10f, 10f);
        //float randDirectionModifierZ = Random.Range(-10f, 10f);
        //direction = (new Vector3(0 + randDirectionModifierX, 0 + randDirectionModifierY, 0 + randDirectionModifierZ));
        rb = gameObject.GetComponent<Rigidbody>();
        //rb.AddForce(direction * Time.deltaTime * speed);
        StartCoroutine(bubbleLifeIndicator());
        isBubbleDead = false;
        //StartCoroutine(addForceCor());

    }

    void Update()
    {
        if (isBubbleDead)
        {
            Debug.Log("Bubble ended its life");
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (rb.velocity == Vector3.zero)
        {
            direction = -direction;
            rb.AddForce(direction * Time.deltaTime * speed);
        }
    }

    IEnumerator bubbleLifeIndicator()
    {
        yield return new WaitForSeconds(5f);
        isBubbleDead = true;
    }

    //IEnumerator addForceCor()
    //{
    //    while (true)
    //    {
    //        createBubble();

    //        yield return new WaitForSeconds(2f);

    //    }
    //}

}

