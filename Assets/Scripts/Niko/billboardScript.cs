using UnityEngine;

public class billboardScript : MonoBehaviour
{
    Vector3 cameraPosition;


    void Start()
    {
        cameraPosition = new Vector3(18.5f, 4.8f, 11.65f);
    }

    void Update()
    {
        transform.LookAt(-cameraPosition);
        transform.rotation = Quaternion.Euler(5.708f, -110.248f, 0f);
    }

}