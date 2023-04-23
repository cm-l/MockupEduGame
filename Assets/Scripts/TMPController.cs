using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class TMPController : MonoBehaviour {
    private static TextMeshProUGUI equationBox;
    private static TextMeshProUGUI scoreboard;
    private static string equationText;
    private static string equationSymbol;

    [SerializeField] private static int score = 0;
    public static int rowCounter;
    
    void Awake() {
        rowCounter = 0;
    }

    // Czy gracz dopiero zaczął 'rundę'?
    public static bool firstRun = true;

    private static string activeSceneName;


    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        activeSceneName = SceneManager.GetActiveScene().name;
        switch (activeSceneName) {
            case "AdditionScene": equationSymbol = "+";
                                  rowCounter = 0;
                                  Debug.Log("Row counter: " + rowCounter);
                                  break;
            case "SubtractionScene": equationSymbol = "-"; break;
            case "MultiplicationScene": equationSymbol = "×"; break;
            case "DivisionScene": equationSymbol = ":"; break;
            default: Debug.Log("Uh"); break;
        }

        equationBox = GameObject.Find("EquationBox").GetComponent<TextMeshProUGUI>();
        scoreboard = GameObject.Find("Scoreboard").GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        equationBox.text = equationText;
        scoreboard.text = "Score: " + score.ToString();
    }

    public static void changeEquation(int number1, int number2) {
        equationText = number1 + " " + equationSymbol + " □ = " + number2;
        rowCounter += 1;
        // Debug.Log("Current row: " + rowCounter);
    }
    
    public static void addPoint() {
        score++;
        switch (activeSceneName) {
            case "AdditionScene": RunningResults.AdditionScoreUp(); break;
            case "SubtractionScene": RunningResults.SubtractionScoreUp(); break;
            case "MultiplicationScene": RunningResults.MultiplicationScoreUp(); break;
            case "DivisionScene": RunningResults.DivisionScoreUp(); break;
            default: Debug.Log("Uh"); break;
        }
    }

    public static void substractPoint() {
        score--;
        switch (activeSceneName) {
            case "AdditionScene": RunningResults.AdditionScoreDown(); break;
            case "SubtractionScene": RunningResults.SubtractionScoreDown(); break;
            case "MultiplicationScene": RunningResults.MultiplicationScoreDown(); break;
            case "DivisionScene": RunningResults.DivisionScoreDown(); break;
            default: Debug.Log("Uh"); break;
        }
    }

    public static int getScore() {
        return score;
    }

    public static void ResetScore() {
        score = 0;
    }

    public static void ResetRowCounter() {
        rowCounter = 0;
    }
}
