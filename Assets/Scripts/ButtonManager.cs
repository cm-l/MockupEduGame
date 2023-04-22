using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System;
using TMPro;


public class ButtonManager : MonoBehaviour {

    [SerializeField] private Canvas choiceCanvas;
    [SerializeField] private AudioClip buttonClickSfx;

    public void ShowCanvas(Canvas canvasToShow) {
        canvasToShow.gameObject.SetActive(true);
    }

    public void BackButton() {
        SoundSystemSingleton.Instance.PlaySfxSound(buttonClickSfx);

        transform.parent.gameObject.SetActive(false);

        ShowCanvas(choiceCanvas);
    }

    // <<<<< PLAY / OPTIONS / QUIT >>>>>
    public void PlayButton() {
        SoundSystemSingleton.Instance.PlaySfxSound(buttonClickSfx);

        // Schowanie canvasu menu
        transform.parent.parent.gameObject.SetActive(false);
        
        // Wyświetlenie po chwili informacji o możliwości pójścia do sklepu / wylosowania minigierki
        ShowCanvas(choiceCanvas);
    }

    public void OptionsButton() {
        SoundSystemSingleton.Instance.PlaySfxSound(buttonClickSfx);

        // Schowanie canvasu menu
        transform.parent.parent.gameObject.SetActive(false);

        // Wyświetlenie canvasu Options
        ShowCanvas(choiceCanvas);
    }

    public void QuitButton() {
        SoundSystemSingleton.Instance.PlaySfxSound(buttonClickSfx);

        // Schowanie canvasu menu
        transform.parent.parent.gameObject.SetActive(false);

        // Pokazanie canvasu potwierdzenia wyjścia z gry
        ShowCanvas(choiceCanvas);
    }

    // <<<<< LEAVE CONFIRMATION >>>>>
    public void YesLeaveButton() {
        Application.Quit();
    }

    public void NoLeaveButton() {
        // Schowanie canvasu potwierdzenia wyjścia z gry
        transform.parent.parent.gameObject.SetActive(false);

        // Przywrócenie menu
        ShowCanvas(choiceCanvas);
    }

    // <<<<< SHOP / ADVENTURE >>>>>
    public void ShopButton() {
        SoundSystemSingleton.Instance.PlaySfxSound(buttonClickSfx);

        // Schowanie canvasu wyboru sklepu / minigry
        transform.parent.gameObject.SetActive(false);

        // Włączenie animacji i przejście do sceny sklepu
        Invoke("SwitchToShop", 2f);
    }

    public void GameButton() {
        SoundSystemSingleton.Instance.PlaySfxSound(buttonClickSfx);

        // Schowanie canvasu wyboru sklepu / minigry
        transform.parent.gameObject.SetActive(false);

        // Wylosowanie sceny gry
        //Invoke("RandomizeGameScene", 2f);

        Invoke("ContinueAdventure", 2f);
    }

    private void ContinueAdventure() {
        switch(GameProgression.GetCurrentGameStage()) {
            case 1: SceneManager.LoadSceneAsync("EnemyFight_Dungeon1"); break;
            case 2: SceneManager.LoadSceneAsync("EnemyFight_Dungeon2"); break;
            case 3: SceneManager.LoadSceneAsync("EnemyFight_Dungeon3"); break;
            default: Debug.Log("Uh"); break;
        }
    }

    private void SwitchToShop() {
        SoundSystemSingleton.Instance.PlaySfxSound(buttonClickSfx);

        SceneManager.LoadSceneAsync("Shop");
    }

    private void RandomizeGameScene() {
        SoundSystemSingleton.Instance.PlaySfxSound(buttonClickSfx);

        TransitionScript.RandomizeGameScene();
    }

    // <<<<< LANG / SCREEN SIZE / SOUND / MUSIC / MOUSE SENSIVITY >>>>>
    [SerializeField] private GameObject buttonToShow;
    [SerializeField] private GameObject buttonToHide;

    public void PolishButton() {
        SoundSystemSingleton.Instance.PlaySfxSound(buttonClickSfx);

        // Wyłącza siebie
        buttonToHide.SetActive(false);

        // Włącza analogiczny, drugi przycisk
        buttonToShow.SetActive(true);
        
        // "Zmienia język"
        Settings.SwitchLanguage("english");

    }

    public void EnglishButton() {
        SoundSystemSingleton.Instance.PlaySfxSound(buttonClickSfx);

        // Wyłącza siebie
        buttonToHide.SetActive(false);

        // Włącza analogiczny, drugi przycisk
        buttonToShow.SetActive(true);

        // "Zmienia język"
        Settings.SwitchLanguage("polish");
    }

    public void ScreenSizeDropdownChange(int index) {
        switch (index) {
            case 0: Settings.ChangeScreenSize(1920, 1080); break;
            case 1: Settings.ChangeScreenSize(1366, 768); break;
            case 2: Settings.ChangeScreenSize(800, 600); break;
        }
    }

    public void MusicOnButton() {
        SoundSystemSingleton.Instance.StopTheMusic();

        // Wyłącza siebie
        buttonToHide.SetActive(false);

        // Włącza analogiczny, drugi przycisk
        buttonToShow.SetActive(true);
    }

    public void MusicOffButton() {
        SoundSystemSingleton.Instance.PlayTheMusicAgain();

        // Wyłącza siebie
        buttonToHide.SetActive(false);

        // Włącza analogiczny, drugi przycisk
        buttonToShow.SetActive(true);
    }

    public void SoundOnButton() {
        SoundSystemSingleton.Instance.TurnOffSound();

        // Wyłącza siebie
        buttonToHide.SetActive(false);

        // Włącza analogiczny, drugi przycisk
        buttonToShow.SetActive(true);
    }

    public void SoundOffButton() {
        SoundSystemSingleton.Instance.TurnOnSound();

        // Wyłącza siebie
        buttonToHide.SetActive(false);

        // Włącza analogiczny, drugi przycisk
        buttonToShow.SetActive(true);
    }
   
    [SerializeField] private Slider musicVolumeSlider;

    public void MusicVolumeSlider() {
        Debug.Log("Music volume value: " + musicVolumeSlider.value);
        SoundSystemSingleton.Instance.ChangeMusicVolume(musicVolumeSlider.value);
    }

    [SerializeField] private Slider soundVolumeSlider;

    public void SoundVolumeSlider() {
        Debug.Log("Sound volume value: " + soundVolumeSlider.value);
        SoundSystemSingleton.Instance.ChangeSoundVolume(soundVolumeSlider.value);
    }

    [SerializeField] private Slider mouseSensivitySlider;

    public void MouseSensivitySlider() {
        Debug.Log("Mouse sens value: " + mouseSensivitySlider.value);
        Settings.ChangeMouseSensivity(mouseSensivitySlider.value);
    }

    // <<<<< GAME PAUSE >>>>>
    public void ResumeGameButton() {
        Settings.ResumeGame();
    }

    public void ShowLeaveMinigameConfirmation() {
        SoundSystemSingleton.Instance.PlaySfxSound(buttonClickSfx);

        ShowCanvas(choiceCanvas);
    }

    public void BackToMenuButton() {
        // Wyłączenie canvasu 'startowego'
        TransitionScript.cameFromAnotherScene = false;

        // Powrót do tunelu
        SceneManager.LoadSceneAsync("TransitionScene");
    }

    public void StayInGameButton() {
        SoundSystemSingleton.Instance.PlaySfxSound(buttonClickSfx);

        transform.parent.parent.gameObject.SetActive(false);
    }

    // Metoda do wracanka np. ze sklepu
    public void BackToMainGameButton() {
        SoundSystemSingleton.Instance.PlaySfxSound(buttonClickSfx);

        // Wyłączenie canvasu 'startowego' (play / options / quit)
        TransitionScript.cameFromAnotherScene = true;

        // Dodanie punkciku progresji
        GameProgression.AddLevelsCompleted();
        GameProgression.UpdateGameStage();
        Debug.Log("LevelsCompleted: " + GameProgression.GetLevelsCompleted() + "\n  Current stage: " + GameProgression.GetCurrentGameStage());
       
        // Resetowanie RunningGame
        TMPController.ResetScore();
        RunningResults.ResetAllScores();

        // Powrót do głównej gierki
        Invoke("ChangeScene", 2f);
    }

    // <<<<< COMBAT GAME >>>>>
    public void ContinueToCombatButton() {
        SceneManager.LoadSceneAsync("PiJ-minigra");
    }

    public void WonGameConfirmationButton() {
        try {
            ManagerSingleton.Instance.playerGold += 100;
            Invoke("ChangeScene", 2f);
        }
        catch (NullReferenceException e) {
            // handle the exception
            Debug.Log("Najpierw odpal scenę karcianki. (" + e + ")");
            Invoke("ChangeScene", 2f);
        }

    }

    public void LostGameConfirmationButton() {
        Invoke("ChangeScene", 2f);
    }

    private void ChangeScene() {
        switch (GameProgression.GetCurrentGameStage()) {
            case 1: SceneManager.LoadSceneAsync("EnemyFight_Dungeon1"); break;
            case 2: SceneManager.LoadSceneAsync("EnemyFight_Dungeon2"); break;
            case 3: SceneManager.LoadSceneAsync("EnemyFight_Dungeon3"); break;
            case 4: SceneManager.LoadSceneAsync("TheEndWin"); break;
            default: Debug.Log("Uh"); break;
        }
    }
}
