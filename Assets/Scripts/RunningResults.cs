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

    [SerializeField] private static int additionScore = 0;
    [SerializeField] private static int subtractionScore = 0;
    [SerializeField] private static int multiplicationScore = 0;
    [SerializeField] private static int divisionScore = 0;
    
    void Start() {
        additionScoreBox = GameObject.Find("AdditionScoreBox").GetComponent<TextMeshProUGUI>();
        subtractionScoreBox = GameObject.Find("SubtractionScoreBox").GetComponent<TextMeshProUGUI>();
        multiplicationScoreBox = GameObject.Find("MultiplicationScoreBox").GetComponent<TextMeshProUGUI>();
        divisionScoreBox = GameObject.Find("DivisionScoreBox").GetComponent<TextMeshProUGUI>();
        totalPointsScoreBox = GameObject.Find("SummaryScoreBox").GetComponent<TextMeshProUGUI>();

        additionScoreBox.text = additionScore.ToString();
        subtractionScoreBox.text = subtractionScore.ToString();
        multiplicationScoreBox.text = multiplicationScore.ToString();
        divisionScoreBox.text = divisionScore.ToString();
        totalPointsScoreBox.text = TMPController.getScore().ToString();

        Timer timer = new Timer(state =>
        {
            // Code to execute after 1 second
            Console.WriteLine("One second has passed.");
        }, null, 1000, Timeout.Infinite);
    }

    public static void AdditionScoreUp() {
        additionScore++;
    }

    public static void AdditionScoreDown() {
        additionScore--;
    }

    public static void SubtractionScoreUp() {
        subtractionScore++;
    }

    public static void SubtractionScoreDown() {
        subtractionScore--;
    }

    public static void MultiplicationScoreUp() {
        multiplicationScore++;
    }

    public static void MultiplicationScoreDown() {
        multiplicationScore--;
    }

    public static void DivisionScoreUp() {
        divisionScore++;
    }

    public static void DivisionScoreDown() {
        divisionScore--;
    }

    public static void ResetAllScores() {
        additionScore = 0;
        subtractionScore = 0;
        multiplicationScore = 0;
        divisionScore = 0;
    }
}
