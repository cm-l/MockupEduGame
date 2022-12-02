using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickParticle : MonoBehaviour
{ 
    private ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        //initialize an array the size of our current particle count
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[ps.particleCount];
         //*pass * this array to GetParticles...
        int num = ps.GetParticles(particles);
        Debug.Log("Found " + num + " active particles.");
        for (int i = 0; i < num; i++)
        {
            if (particles[i].position.z > 5) // large local z: let particle drop down
                particles[i].velocity -= Vector3.up * 0.1f;
            if (particles[i].position.x > 1) // positive x: make it red
                particles[i].color = Color.red;
            if (particles[i].position.x < -1) // negative x: make it die
                particles[i].lifetime = 0;
        }
        // re-assign modified array
        ps.SetParticles(particles, num);
    }
}
