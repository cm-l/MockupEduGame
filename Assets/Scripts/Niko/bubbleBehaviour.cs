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
           
            //Destroy(this.gameObject);
        }
    }

    //private void FixedUpdate()
    //{

    //}

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
            //Debug.Log("-------------------------------------------------------");
            //Debug.Log("Collision: " + collision.contacts[0].normal);
            //Debug.Log("Bubble value: " + gameObject.GetComponent<bubbleMath>().getrVal());
            //Debug.Log("Bubble velocity before: " + rb.velocity);
            //Debug.Log("Force added: " + (collision.contacts[0].normal * bounce));
            rb.AddForce(collision.contacts[0].normal * bounce * Time.deltaTime);
            //Debug.Log("Bubble velocity after: " + rb.velocity);
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

