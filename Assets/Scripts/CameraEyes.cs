using UnityEngine;

public class CameraEyes : MonoBehaviour
{
    public Transform player;
    Vector3 offset;

    void Start()
    {
        offset = transform.position - player.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = transform.position = player.position + offset;
        //targetPos.x = 0;
        //transform.position = targetPos;
    }
}