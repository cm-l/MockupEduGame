using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Threading;

public class RunningResults : MonoBehaviour
{
    private TextMeshProUGUI additionScoreBox;
    private TextMeshProUGUI subtractionScoreBox;
    private TextMeshProUGUI multiplicationScoreBox;
    private TextMeshProUGUI divisionScoreBox;
    private TextMeshProUGUI totalPointsScoreBox;
    private TextMeshProUGUI moneyEarnedBox;

    [SerializeField] private static int additionScore = 0;
    [SerializeField] private static int subtractionScore = 0;
    [SerializeField] private static int multiplicationScore = 0;
    [SerializeField] private static int divisionScore = 0;

    [SerializeField] private static int highestPossibleScore = 10;
    [SerializeField] private static int earnedPoints = 0;
    [SerializeField] private static float percentOfSuccessfulRun = 0f;

    public static int moneyEarned;
    public static int limitOfMoneyToEarn = 70;
    
    void Start() {
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
        if (percentOfSuccessfulRun <= 0)
            return 0;
        else
            return (int) percentOfSuccessfulRun * limitOfMoneyToEarn;
    }

    public static void ResetAllScores() {
        additionScore = 0;
        subtractionScore = 0;
        multiplicationScore = 0;
        divisionScore = 0;
    }
}
