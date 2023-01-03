using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam : MonoBehaviour
{
    public float speedHorizontal = 1.0f;
    public float speedVertical = 1.0f;
    float yaw = 0.0f;
    float pitch = 0.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yaw += speedHorizontal * Input.GetAxis("Mouse X");
        pitch -= speedVertical * Input.GetAxis("Mouse Y");
        
        yaw = Mathf.Clamp(yaw, -30f, 30f);

        pitch = Mathf.Clamp(pitch, -6f, 30f);




        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        
    }
}
