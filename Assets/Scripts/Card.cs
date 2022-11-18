using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    float upAmount = 0.05f;
    float speed = 0.4f;
    Vector3 dnPos;
    Vector3 upPos;
    Vector3 currPos;
    void Start()
    {
        dnPos = transform.position;
        upPos=transform.position + Vector3.up*upAmount;
        currPos=dnPos;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, currPos, speed * Time.deltaTime);
    }

    private void OnMouseEnter() {
        currPos=upPos;
    }
    private void OnMouseExit() {
        currPos=dnPos;
    }

}
