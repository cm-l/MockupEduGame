using Unity.VisualScripting;
using UnityEngine;

public class BowScript : MonoBehaviour
{
    public GameObject arrow;
    [SerializeField] private AudioClip loadSound, releaseSound;

    public void LoadBow()
    {
        SoundSystemSingleton.Instance.PlaySfxSound(loadSound);
    }

    public void ShootArrow()
    {
        Vector3 parentTransform = transform.parent.transform.position;

        Instantiate(arrow, new Vector3(parentTransform.x, parentTransform.y - 0.1f, parentTransform.z), 
            transform.parent.transform.rotation);

        SoundSystemSingleton.Instance.PlaySfxSound(releaseSound);
    }
}
