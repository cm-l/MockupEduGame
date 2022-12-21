using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleChangeVelocity : MonoBehaviour
{
    Rigidbody rb;
    Vector3 direction;
    float speed = 35;
    Vector3 limit = new Vector3(1, 1, 1);
   
    void Start()
    {
        float randDirectionModifierX = Random.Range(-10f, 10f);
        float randDirectionModifierY = Random.Range(-10f, 10f);
        float randDirectionModifierZ = Random.Range(-10f, 10f);
        direction = (new Vector3(0 + randDirectionModifierX, 0 + randDirectionModifierY , 0 + randDirectionModifierZ));
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(direction * Time.deltaTime * speed);
    }

    // Update is called once per frame
    //void Update()
    //{

        //Debug.Log(rb.velocity);
        //if (rb.velocity == Vector3.zero)
        //{
        //    Debug.Log("Force added");
        //    rb.AddForce(direction * Time.deltaTime * speed);
        //}

        //if (Vector3.Distance(direction, limit) <= 1f)
        //{
        //    Debug.Log("TOO SMALL");
        //}
    //}

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (rb)
    //    {
    //        direction = -direction;
    //    }
    //}

    private void FixedUpdate()
    {
        Debug.Log(rb.velocity);
        if (rb.velocity == Vector3.zero)
        {
            direction = -direction;
            Debug.Log("Direction changed");
            rb.AddForce(direction * Time.deltaTime * speed);
            Debug.Log("Force added");
        }
    }
}

