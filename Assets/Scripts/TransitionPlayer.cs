using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class TransitionPlayer : MonoBehaviour {
    
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 0.5f;

    private void FixedUpdate() {
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 targetPosition = new Vector3(0, rb.position.y, rb.position.z);
        rb.MovePosition(Vector3.MoveTowards(rb.position, targetPosition, 0) + forwardMove);
    }
}
