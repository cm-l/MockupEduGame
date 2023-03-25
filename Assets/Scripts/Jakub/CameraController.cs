using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float xSens, ySens, xRotation = 0, yRotation = 0, xMouse, yMouse, previousXRotation = 0, previousYRotation = 0;
    [HideInInspector]
    public float xDelta = 0, yDelta = 0;
    public Transform orientation;

    private void Start()
    {
        xSens = PlayerPrefs.GetFloat("xSens", 10f);
        ySens = PlayerPrefs.GetFloat("ySens", 10f);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        xMouse = Input.GetAxisRaw("Mouse X") * xSens;
        yMouse = Input.GetAxisRaw("Mouse Y") * ySens;
        xRotation -= yMouse;
        yRotation += xMouse;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        xDelta = previousXRotation - xRotation;
        yDelta = previousYRotation - yRotation;

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }

    private void LateUpdate()
    {
        previousXRotation = xRotation;
        previousYRotation = yRotation;
    }
}
