using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
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

        //TODO Smooth the movement of the camera out a lot / reduce how much it moves even more
        yaw += speedHorizontal * Input.GetAxis("Mouse X");
        pitch -= speedVertical * Input.GetAxis("Mouse Y");
        
        yaw = Mathf.Clamp(yaw, -2f, 2f);

        pitch = Mathf.Clamp(pitch, -3f, 3f);




        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        
    }
}
