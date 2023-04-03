using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public int screenWidth = 800;
    public int screenHeight = 600;

    [SerializeField] private AudioClip gameMusic;
    void Start()
    {
        SoundSystemSingleton.Instance.PlayMusicSound(gameMusic);
        Screen.SetResolution(screenWidth, screenHeight, false);
    }

    public static void ChangeScreenSize(int height, int width) {
        Debug.Log("Changed screen resolution to " + height + " x " + width);
        Screen.SetResolution(width, height, false);
    }


}
