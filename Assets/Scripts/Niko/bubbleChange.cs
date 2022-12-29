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
        float randDirectionModifierX = Random.Range(-10f, 10f);
        float randDirectionModifierY = Random.Range(-10f, 10f);
        float randDirectionModifierZ = Random.Range(-10f, 10f);
        direction = (new Vector3(0 + randDirectionModifierX, 0 + randDirectionModifierY , 0 + randDirectionModifierZ));
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(direction * Time.deltaTime * speed);
        StartCoroutine(bubbleLifeIndicator());
        isBubbleDead = false;
    }

    // Update is called once per frame
    void Update()
    {

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

        if (isBubbleDead)
        {
            Debug.Log("Bubble ended its life");
            //GameObject go = Instantiate(ps.gameObject, transform.position,
            //        Quaternion.identity);
            //Destroy(go, 2.0f);
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
}

