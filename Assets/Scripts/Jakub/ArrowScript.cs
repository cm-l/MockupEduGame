using Unity.VisualScripting;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public ParticleSystem ps;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        ps.Emit(1);
    }

    private void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
    }
}
