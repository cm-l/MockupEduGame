using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;



public class Settings : MonoBehaviour {

    public static int screenWidth = 1920;
    public static int screenHeight = 1080;
 
    public static float mouseSensitivity;
    [SerializeField] private Texture2D cursorTexture;
    [SerializeField] private Vector2 cursorHotspot;

    private static bool gamePaused;
    private static bool gamePausePressed;

    [SerializeField] private AudioClip gameMusic;
    private string currentSceneName;

    void Start() {
        if (cursorTexture == null) {
            Cursor.SetCursor(null, cursorHotspot, CursorMode.Auto);
            cursorHotspot = new Vector2(0, 0);

        } else {
            Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
        }

        currentSceneName = SceneManager.GetActiveScene().name;

        gamePaused = false;
        gamePausePressed = false;

        mouseSensitivity = 10f;

        SoundSystemSingleton.Instance.PlayMusicSound(gameMusic);
        SoundSystemSingleton.Instance.ChangeMusicVolume(1f);
        
        Screen.SetResolution(screenWidth, screenHeight, true);    
    }
    
    [SerializeField] private Canvas gamePauseCanvas;
    [SerializeField] private Canvas inGameOptionsCanvas;
    [SerializeField] private Canvas leaveMinigameConfirmationCanvas;

    void Update() {
        // <<<<< PAUZOWANIE GRY >>>>>
        if (Input.GetKeyDown(KeyCode.Escape) && gamePaused)
            ResumeGame();
        else if (Input.GetKeyDown(KeyCode.Escape) && !string.Equals(currentSceneName, "TransitionScene")) 
            PauseGame();
      
        if (gamePaused) {
            Time.timeScale = 0;
            
            if (gamePausePressed) {
                gamePausePressed = false;
                gamePauseCanvas.gameObject.SetActive(true);
                CameraMovement.FreezeCamera();
            }
        }
        else {
            Time.timeScale = 1;
            gamePauseCanvas.gameObject.SetActive(false);
            inGameOptionsCanvas.gameObject.SetActive(false);
            leaveMinigameConfirmationCanvas.gameObject.SetActive(false);
            CameraMovement.UnfreezeCamera();
        }

        // <<<<< ... >>>>>
    }

    // TODO: NAPRAWIĆ, ŻEBY NIE DAŁO SIĘ ODPALIĆ PAUZY W MENU GRY
    private static void PauseGame() {
        gamePaused = true;
        gamePausePressed = true;
    }

    public static void ResumeGame() {
        gamePaused = false;
        gamePausePressed = false;
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
