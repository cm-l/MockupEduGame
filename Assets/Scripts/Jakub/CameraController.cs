using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform orientation;

    float xSens, ySens, xRotation, yRotation, xMouse, yMouse, previousXRotation, previousYRotation;
    [HideInInspector] public float xDelta { get; private set; }
    [HideInInspector] public float yDelta { get; private set; }

    private static bool isCameraFrozen;
    private void Start()
    {
        isCameraFrozen = false;

        xSens = PlayerPrefs.GetFloat("xSens", 10f);
        ySens = PlayerPrefs.GetFloat("ySens", 10f);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (!isCameraFrozen) {
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
    }

    private void LateUpdate()
    {
        previousXRotation = xRotation;
        previousYRotation = yRotation;
    }

    public static void FreezeCamera() {
        isCameraFrozen = true;
    }

    public static void UnfreezeCamera() {
        isCameraFrozen = false;
    }
}
