using UnityEngine;

public class CameraEyes : MonoBehaviour {
    public Transform player;
    Vector3 offset;

    void Start() {
        offset = transform.position - player.position;
    }

    void Update() {
        Vector3 targetPos = transform.position = player.position + offset;
    }
}