using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSound : MonoBehaviour
{
    private AudioSource animSource;
    // Start is called before the first frame update
    void Start()
    {
        animSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void PlayAnimationSound(){
        animSource.Play();
    }
}
