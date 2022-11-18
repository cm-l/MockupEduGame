using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour
{
    public float minIntensity = 0.5f;
    public float maxIntensity = 15f;
    float random;
    Light myLight;
    
    private void Start() {
        myLight = GetComponent<Light>();
        random = Random.Range(5.0f, 65535.0f);
    }
    void Update()
    {
        float noise = Mathf.PerlinNoise(random, Time.time);
        myLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);
    }
}
