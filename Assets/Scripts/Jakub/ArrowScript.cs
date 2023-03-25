using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public ParticleSystem ps;

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
        ps.Emit(1);
    }

    void FixedUpdate()
    {
     //   if (ps && ps.IsAlive())
     //      Destroy(gameObject);
    }

    private void OnParticleCollision(GameObject other)
    {
        Destroy(gameObject);
    }
}
