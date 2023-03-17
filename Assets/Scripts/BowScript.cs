using UnityEngine;

public class BowScript : MonoBehaviour
{
    public GameObject arrow;

    public void ShootArrow()
    {
        Vector3 parentTransform = transform.parent.transform.position;

        Instantiate(arrow, new Vector3(parentTransform.x, parentTransform.y - 0.1f, parentTransform.z), transform.parent.transform.rotation);
    }
}
