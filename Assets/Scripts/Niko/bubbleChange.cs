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
        rb = gameObject.GetComponent<Rigidbody>();
        StartCoroutine(bubbleLifeIndicator());
        isBubbleDead = false;

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

