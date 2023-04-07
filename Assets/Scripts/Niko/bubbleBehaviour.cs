using System.Collections;
using UnityEngine;

public class BubbleBehaviour : MonoBehaviour
{
    Rigidbody rb;
    bool isBubbleDead;
    public ParticleSystem ps;
    BubbleDestroy bDestroy;
    int scenarioNumber = FollowClicking.scenarioNumber;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        StartCoroutine(BubbleLifeIndicator());
        isBubbleDead = false;        
        bDestroy = gameObject.GetComponent<BubbleDestroy>();
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
            else if (scenarioNumber == 3)
                bDestroy.AutoRemoveScenario3();
            else
                Debug.Log("Can't activate auto-remove " +
                    "function for given scenario in bubbleBahaviour script");
        }
    }

    IEnumerator BubbleLifeIndicator()
    {
        yield return new WaitForSeconds(7f);
        isBubbleDead = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!(collision.gameObject == GameObject.Find("SD_Prop_Cauldron_01")))
        {
            float bounce = 3000f; //amount of force to apply
            rb.AddForce(bounce * Time.deltaTime * collision.contacts[0].normal);
        }
    }
  
    public void PopBubble()
    {
        isBubbleDead = true;
    }

}
