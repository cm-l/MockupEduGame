using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using TMPro;


public class BubbleStatsScript : MonoBehaviour {
    
    [SerializeField] private static int poppedCorrectly;
    [SerializeField] private static int poppedMistakenly;
    [SerializeField] private static int poppedNotInTime;

    [SerializeField] private static int amountOfBubblesInRun;
    [SerializeField] private static float percentOfSuccessfulRun = 0f;

    [SerializeField] private static int moneyEarned;
    [SerializeField] private static int limitOfMoneyToEarn = 70;

    private TextMeshProUGUI poppedCorrectlyBox;
    private TextMeshProUGUI poppedMistakenlyBox;
    private TextMeshProUGUI poppedNotInTimeBox;
    private TextMeshProUGUI totalPointsScoreBox;
    private TextMeshProUGUI moneyEarnedBox;

    void Start() {
        poppedCorrectly = GameManager.ok;
        poppedMistakenly = GameManager.mistake;
        poppedNotInTime = GameManager.notPopped;

        poppedCorrectlyBox = GameObject.Find("poppedCorrectlyBox").GetComponent<TextMeshProUGUI>();
        poppedMistakenlyBox = GameObject.Find("poppedMistakenlyBox").GetComponent<TextMeshProUGUI>();
        poppedNotInTimeBox = GameObject.Find("poppedNotInTimeBox").GetComponent<TextMeshProUGUI>();
        totalPointsScoreBox = GameObject.Find("SummaryScoreBox").GetComponent<TextMeshProUGUI>();
        moneyEarnedBox = GameObject.Find("MoneyEarnedBox").GetComponent<TextMeshProUGUI>();

        poppedCorrectlyBox.text = poppedCorrectly.ToString();
        poppedMistakenlyBox.text = poppedMistakenly.ToString();
        poppedNotInTimeBox.text = poppedNotInTime.ToString();

        amountOfBubblesInRun = poppedCorrectly + poppedMistakenly + poppedNotInTime;
        percentOfSuccessfulRun = (float) poppedCorrectly / amountOfBubblesInRun;
        Debug.Log("Success rate: " + percentOfSuccessfulRun);
        totalPointsScoreBox.text = CalculateTotalScore();

        moneyEarned = CalculateMoneyEarned();
        moneyEarnedBox.text = "You earned $" + moneyEarned + "!";

        // Dodawanie pieniêdzy do karcianki
        ManagerSingleton.Instance.playerGold += moneyEarned;
        Debug.Log("Money in game: " + ManagerSingleton.Instance.playerGold);
    }

    private static int CalculateMoneyEarned() {
        if (percentOfSuccessfulRun <= 0 || float.IsNaN(percentOfSuccessfulRun))
            return 0;
        else
            return (int)Math.Round(percentOfSuccessfulRun * limitOfMoneyToEarn, MidpointRounding.AwayFromZero);
    }

    private static string CalculateTotalScore() {
        return poppedCorrectly + "/" + amountOfBubblesInRun;
    }
}
