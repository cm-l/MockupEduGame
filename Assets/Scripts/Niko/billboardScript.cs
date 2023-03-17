using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billboardScript : MonoBehaviour
{
    //private Camera cam;
    //Transform camPosition;
    Vector3 cameraPosition;

    void Start()
    {
        //cam = Camera.main;
        //camPosition = cam.transform;
        cameraPosition = new Vector3(18.5f, 4.8f, 11.65f);
    }

    void Update()
    {
        transform.LookAt(-cameraPosition);
        transform.rotation = Quaternion.Euler(5.708f, -110.248f, 0f);
    }
}
