using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public int health = 2; // counting from 0
    Renderer rndr;
    public Material[] material;

    void Start()
    {
        rndr = GetComponent<Renderer>();
    }

    public void TakeDamage(int hp)
    {
        if (hp >= 0 && hp <= health)
            rndr.material = material[hp];
    }
}
