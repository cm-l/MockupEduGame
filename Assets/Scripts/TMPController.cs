using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class TMPController : MonoBehaviour
{
    public static TextMeshProUGUI equationBox;
    public static TextMeshProUGUI scoreboard;
    string activeSceneName;
    public static string equationSymbol;
    public static int score = 0;
    public static int lineController = 0;

    public static string equationText;

    void Start()
    {
        activeSceneName = SceneManager.GetActiveScene().name;
        switch (activeSceneName)
        {
            case "AdditionScene": equationSymbol = "+"; break;
            case "SubtractionScene": equationSymbol = "-"; break;
            case "MultiplicationScene": equationSymbol = "*"; break;
            case "DivisionScene": equationSymbol = ":"; break;
            default: Debug.Log("Uh"); break;
        }


        // equationSymbol
        equationBox = GameObject.Find("EquationBox").GetComponent<TextMeshProUGUI>();
        scoreboard = GameObject.Find("Scoreboard").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        equationBox.text = equationText;
        scoreboard.text = "Punkty: " + score.ToString();
    }

    public static void addPoint()
    {
        score++;
    }

    public static void substractPoint()
    {
        score--;
    }
    public static void changeEquation(int number1, int number2)
    {
        equationText = number1 + " " + equationSymbol + " □ = " + number2;
        lineController += 1;
        Debug.Log(lineController);
    }
 
}
