using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static int screenWidth = 1920;
    public static int screenHeight = 1080;
    public Texture2D cursorTexture;


    [SerializeField] private AudioClip gameMusic;
    void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        SoundSystemSingleton.Instance.PlayMusicSound(gameMusic);
        Screen.SetResolution(screenWidth, screenHeight, true);
    }

    public static void ChangeScreenSize(int height, int width) {
        Debug.Log("Changed screen resolution to " + height + " x " + width);
        Screen.SetResolution(height, width, false);
    }

    // Ta metoda jest na razie bezu¿yteczna i pewnie przez d³u¿szy czas bêdzie
    public static void SwitchLanguage(string lang) {
        Debug.Log("Lanuage set to " + lang);
    }

}
