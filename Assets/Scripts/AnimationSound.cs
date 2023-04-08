using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class AnimationSound : MonoBehaviour {
    
    private AudioSource animSource;
    
    void Start() {
        animSource = GetComponent<AudioSource>();
    }

    public void PlayAnimationSound() {
        animSource.Play();
    }
}
