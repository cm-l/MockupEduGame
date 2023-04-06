using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public static int screenWidth = 1920;
    public static int screenHeight = 1080;
    
    public Texture2D cursorTexture;
    public static float mouseSensitivity;

    private static bool gamePaused;

    [SerializeField] private AudioClip gameMusic;
    void Start()
    {
        gamePaused = false;

        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        mouseSensitivity = 1f;

        SoundSystemSingleton.Instance.PlayMusicSound(gameMusic);
        SoundSystemSingleton.Instance.ChangeMusicVolume(0.2f);
        
        Screen.SetResolution(screenWidth, screenHeight, true);    
    }
    

    [SerializeField] private Canvas gamePauseCanvas;
    void Update() {
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

        /*
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float sensitivityX = mouseX * sensitivity;
        float sensitivityY = mouseY * sensitivity;
        */
    }
    public static void ChangeMouseSensivity(float mouseSensValue) {
        mouseSensitivity = mouseSensValue;
    }

    public static void ChangeScreenSize(int height, int width) {
        Debug.Log("Changed screen resolution to " + height + " x " + width);
        Screen.SetResolution(height, width, true);
    }

    // Ta metoda jest na razie bezu¿yteczna i pewnie przez d³u¿szy czas bêdzie
    public static void SwitchLanguage(string lang) {
        Debug.Log("Lanuage set to " + lang);
    }

    // TODO: NAPRAWIÆ ¯EBY NIE DA£O SIÊ ODPALIÆ PAUZY W MENU GRY
    private static void PauseGame() {
        gamePaused = true;
    }

    public static void ResumeGame() {
        gamePaused = false;
    }


}
