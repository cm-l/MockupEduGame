using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleChange : MonoBehaviour
{
    Rigidbody rb;
    Vector3 direction;
    int speedModifier;
    Vector3 limit = new Vector3(1, 1, 1);
    bool isBubbleDead;
    public ParticleSystem ps;
    //int timeToWait;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        StartCoroutine(bubbleLifeIndicator());
        isBubbleDead = false;
        direction = GameObject.Find("SD_Prop_Cauldron_01").
            GetComponent<bubbleGenerate>().getVector3();
        speedModifier = GameObject.Find("SD_Prop_Cauldron_01").
            GetComponent<bubbleGenerate>().speedModifier;
        speedModifier = speedModifier / 4;
        //timeToWait = 1;
    }

    void Update()
    {
        if (isBubbleDead)
        {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        //Invoke("checkVelocity", timeToWait);
        //Debug.Log(rb.velocity);
    }

    IEnumerator bubbleLifeIndicator()
    {
        yield return new WaitForSeconds(5f);
        isBubbleDead = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!(collision.gameObject == GameObject.Find("SD_Prop_Cauldron_01")))
        {
            float bounce = 10f; //amount of force to apply
            Debug.Log(collision.contacts[0].normal);
            rb.AddForce(collision.contacts[0].normal * bounce);
            //Debug.Log(collision.gameObject);
        }
     
    }


    //void checkVelocity()
    //{
    //    if (rb.velocity == Vector3.zero)
    //    {
    //        Debug.Log("My Vector3 equals to zero!");
    //        direction = -direction;
    //        rb.AddForce(direction * Time.deltaTime * speedModifier);
    //    }
    //    timeToWait = 0;
    //}

}

