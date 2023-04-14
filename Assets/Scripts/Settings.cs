using System.Collections.Generic;
using System.Collections;
using UnityEngine;


public class Settings : MonoBehaviour {

    public static int screenWidth = 1920;
    public static int screenHeight = 1080;
 
    public static float mouseSensitivity;

    private static bool gamePaused;

    [SerializeField] private AudioClip gameMusic;

    void Start() {
        gamePaused = false;

        mouseSensitivity = 1f;

        SoundSystemSingleton.Instance.PlayMusicSound(gameMusic);
        SoundSystemSingleton.Instance.ChangeMusicVolume(1f);
        
        Screen.SetResolution(screenWidth, screenHeight, true);    
    }
    
    [SerializeField] private Canvas gamePauseCanvas;
    void Update() {
        // <<<<< PAUZOWANIE GRY >>>>>
        if(Input.GetKeyDown(KeyCode.Escape) && gamePaused)
            ResumeGame();
        else if (Input.GetKeyDown(KeyCode.Escape)) 
            PauseGame();
      
        if (gamePaused) {
            Time.timeScale = 0;
            gamePauseCanvas.gameObject.SetActive(true);
        }
        else {
            Time.timeScale = 1;
            gamePauseCanvas.gameObject.SetActive(false);
        }

        // <<<<< ... >>>>>
    }

    // TODO: NAPRAWIĆ, ŻEBY NIE DAŁO SIĘ ODPALIĆ PAUZY W MENU GRY
    private static void PauseGame() {
        gamePaused = true;
    }

    public static void ResumeGame() {
        gamePaused = false;
    }

    public static void ChangeMouseSensivity(float mouseSensValue) {
        mouseSensitivity = mouseSensValue;
    }

    public static void ChangeScreenSize(int height, int width) {
        Debug.Log("Changed screen resolution to " + height + " x " + width);
        Screen.SetResolution(height, width, true);
    }

    // Ta metoda jest na razie bezużyteczna i pewnie przez dłuższy czas będzie
    public static void SwitchLanguage(string lang) {
        Debug.Log("Lanuage set to " + lang);
    }
}
