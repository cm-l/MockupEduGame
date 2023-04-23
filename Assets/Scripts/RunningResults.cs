using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using TMPro;


public class RunningResults : MonoBehaviour {

    [SerializeField] private static int additionScore = 0;
    [SerializeField] private static int subtractionScore = 0;
    [SerializeField] private static int multiplicationScore = 0;
    [SerializeField] private static int divisionScore = 0;

    [SerializeField] private static int highestPossibleScore = 40;
    [SerializeField] private static int earnedPoints = 0;
    [SerializeField] private static float percentOfSuccessfulRun = 0f;

    [SerializeField] private static int moneyEarned;
    [SerializeField] private static int limitOfMoneyToEarn = 70;
    
    private TextMeshProUGUI additionScoreBox;
    private TextMeshProUGUI subtractionScoreBox;
    private TextMeshProUGUI multiplicationScoreBox;
    private TextMeshProUGUI divisionScoreBox;
    private TextMeshProUGUI totalPointsScoreBox;
    private TextMeshProUGUI moneyEarnedBox;
    
    void Start() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        ButtonManager.pointsAdded = false;

        additionScoreBox = GameObject.Find("AdditionScoreBox").GetComponent<TextMeshProUGUI>();
        subtractionScoreBox = GameObject.Find("SubtractionScoreBox").GetComponent<TextMeshProUGUI>();
        multiplicationScoreBox = GameObject.Find("MultiplicationScoreBox").GetComponent<TextMeshProUGUI>();
        divisionScoreBox = GameObject.Find("DivisionScoreBox").GetComponent<TextMeshProUGUI>();
        totalPointsScoreBox = GameObject.Find("SummaryScoreBox").GetComponent<TextMeshProUGUI>();
        moneyEarnedBox = GameObject.Find("MoneyEarnedBox").GetComponent<TextMeshProUGUI>();

        additionScoreBox.text = additionScore.ToString();
        subtractionScoreBox.text = subtractionScore.ToString();
        multiplicationScoreBox.text = multiplicationScore.ToString();
        divisionScoreBox.text = divisionScore.ToString();
        totalPointsScoreBox.text = TMPController.getScore().ToString();

        percentOfSuccessfulRun = (float)earnedPoints / highestPossibleScore;
        Debug.Log("Success rate: " + percentOfSuccessfulRun);
        moneyEarned = CalculateMoneyEarned();
       
        moneyEarnedBox.text = "You earned $" + moneyEarned + "!";

        // Dodawanie pieniêdzy do karcianki
        try {
            ManagerSingleton.Instance.playerGold += moneyEarned;
        }
        catch (NullReferenceException e) {
            Debug.Log("Najpierw odpal karciankê, to wtedy kasa siê doda poprawnie.\n" + e);
        }
    }

    public static void AdditionScoreUp() {
        additionScore++;
        earnedPoints++;
    }

    public static void AdditionScoreDown() {
        additionScore--;
        earnedPoints--;
    }

    public static void SubtractionScoreUp() {
        subtractionScore++;
        earnedPoints++;
    }

    public static void SubtractionScoreDown() {
        subtractionScore--;
        earnedPoints--;
    }

    public static void MultiplicationScoreUp() {
        multiplicationScore++;
        earnedPoints++;
    }

    public static void MultiplicationScoreDown() {
        multiplicationScore--;
        earnedPoints--;
    }

    public static void DivisionScoreUp() {
        divisionScore++;
        earnedPoints++;
    }

    public static void DivisionScoreDown() {
        divisionScore--;
        earnedPoints--;
    }

    private static int CalculateMoneyEarned() {
        if (percentOfSuccessfulRun <= 0 || float.IsNaN(percentOfSuccessfulRun))
            return 0;
        else
            return (int)Math.Round(percentOfSuccessfulRun * limitOfMoneyToEarn, MidpointRounding.AwayFromZero);
    }

    public static void ResetAllScores() {
        additionScore = 0;
        subtractionScore = 0;
        multiplicationScore = 0;
        divisionScore = 0;
    }
}
