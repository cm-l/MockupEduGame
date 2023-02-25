using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleBehaviour : MonoBehaviour
{
    Rigidbody rb;
    Vector3 direction;
    int speedModifier;
    bool isBubbleDead;
    public ParticleSystem ps;
    bubbleDestroy bDestroy;
    int scenarioNumber = followClicking.scenarioNumber;


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
        bDestroy = gameObject.GetComponent<bubbleDestroy>();
    }

    void Update()
    {
        if (isBubbleDead)
        {
            if (scenarioNumber == 0)
                bDestroy.AutoRemoveScenario0();
            else if (scenarioNumber == 1)
                bDestroy.AutoRemoveScenario1();
            else if (scenarioNumber == 2)
                bDestroy.AutoRemoveScenario2();
            else
                Debug.Log("Can't activate auto-remove " +
                    "function for given scenario in bubbleBahaviour script");
        }
    }



    IEnumerator bubbleLifeIndicator()
    {
        yield return new WaitForSeconds(7f);
        isBubbleDead = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!(collision.gameObject == GameObject.Find("SD_Prop_Cauldron_01")))
        {
            float bounce = 3000f; //amount of force to apply
            rb.AddForce(collision.contacts[0].normal * bounce * Time.deltaTime);
        }
        //if (collision.gameObject == GameObject.Find("bubble_colllider (4)"))
        //{
        //    Debug.Log("Cell collision for: " + gameObject.GetComponent<bubbleMath>().getrVal());
        //    //Invoke("checkVelocity", 0.1f);
        //}
    }

    //void checkVelocity()
    //{
    //    Vector3 vel = rb.velocity;
    //    float yVel = vel.y;
    //    //Debug.Log("Y velocity: " + yVel + " | For bubble: " + gameObject.GetComponent<bubbleMath>().getrVal());
    //    //Debug.Log("Checking velocity for: " + gameObject.GetComponent<bubbleMath>().getrVal());
    //    if (yVel > -0.000001)
    //    {
    //        Vector3 addYForce = new Vector3(0, -1f, 0);
    //        rb.AddForce(rb.position + addYForce * Time.deltaTime);
    //        Debug.Log("Force added for bubble number: " + gameObject.GetComponent<bubbleMath>().getrVal());
    //    }
    //}

}

