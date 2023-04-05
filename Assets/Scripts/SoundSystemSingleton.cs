using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSystemSingleton : MonoBehaviour
{
    //Audio Sources
    [SerializeField] private AudioSource musicSource, sfxSource, otherNoiseSource;

    public static SoundSystemSingleton Instance { get; private set; }
    private void Awake()
    {
        // start of singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        // end of singleton pattern
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySfxSound(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayOtherSound(AudioClip clip)
    {
        otherNoiseSource.PlayOneShot(clip);
    }

    public void PlayMusicSound(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.mute = false;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void ChangeMusicPitch(float pitch)
    {
        musicSource.pitch = pitch;
    }

    public void StopTheMusic()
    {
        musicSource.mute = true;
    }

    public void PlayTheMusicAgain() {
        musicSource.mute = false;
    }

}
