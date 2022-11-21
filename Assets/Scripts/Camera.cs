using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
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
        
        yaw = Mathf.Clamp(yaw, -15f, 15f);

        pitch = Mathf.Clamp(pitch, -6f, 19f);




        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        
    }
}
