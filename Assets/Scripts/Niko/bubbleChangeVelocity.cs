using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleChangeVelocity : MonoBehaviour
{
    Rigidbody rb;
    Vector3 direction;
    float speed = 35;
   
    void Start()
    {
        float randDirectionModifierX = Random.Range(-10f, 10f);
        float randDirectionModifierY = Random.Range(-10f, 10f);
        float randDirectionModifierZ = Random.Range(-10f, 10f);
        direction = (new Vector3(0 + randDirectionModifierX, 0 + randDirectionModifierY , 0 + randDirectionModifierZ));
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(direction * Time.deltaTime * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity == Vector3.zero)
        {
            rb.AddForce(direction * Time.deltaTime * speed, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (rb)
        {
            //Debug.Log("Doszło do zmiany ruchu");
            direction = -direction;
            rb.AddForce(direction * Time.deltaTime * 300);
            //Debug.Log("Doszło do zmiany kierunku");

            //foreach (ContactPoint contact in collision.contacts)
            //{
            //    //Debug.DrawRay(contact.point, contact.normal, Color.red);
            //    Debug.Log(contact.normal);
            //}

            //directionController = 20;
            //rb.AddForce(directionController * newDirection);
        }
    }
}
