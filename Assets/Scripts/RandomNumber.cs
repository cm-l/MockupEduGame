using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class RandomNumber : MonoBehaviour {

    private static int additionSubtractionLimiter;
    private static int multiplicationDivisionBottomLimiter;
    private static int multiplicationDivisionLimiter;

    private static int GetLimiterForAddSubt() {
        if (GameProgression.GetCurrentGameStage() >= 3) {
            return 50;
        } else if (GameProgression.GetCurrentGameStage() == 2) {
            return 35;
        } else {
            return 20;
        }
    }

    private static int GetLimiterForMultDiv() {
        if (GameProgression.GetCurrentGameStage() >= 3) {
            return 10;
        } else if (GameProgression.GetCurrentGameStage() == 2) {
            return 8;
        } else {
            return 6;
        }
    }

    private static int GetBottomLimiterForMultDiv() {
        if (GameProgression.GetCurrentGameStage() >= 3) {
            return 4;
        } else if (GameProgression.GetCurrentGameStage() == 2) {
            return 3;
        } else {
            return 2;
        }
    }

    public static int[] AdditionEquation() {
        int firstEquationNumber;
        int resultEquationNumber;

        additionSubtractionLimiter = GetLimiterForAddSubt();

        do {
            firstEquationNumber = Random.Range(1, additionSubtractionLimiter + 1);
            resultEquationNumber = Random.Range(1, additionSubtractionLimiter + 1);
        } while(firstEquationNumber >= resultEquationNumber);

        int secondEquationNumber = resultEquationNumber - firstEquationNumber;
        
        return new []{ firstEquationNumber, secondEquationNumber, resultEquationNumber };
    }

    public static int[] SubtractionEquation() {
        int firstEquationNumber;
        int resultEquationNumber;

        additionSubtractionLimiter = GetLimiterForAddSubt();

        do {
            firstEquationNumber = Random.Range(1, additionSubtractionLimiter + 1);
            resultEquationNumber = Random.Range(1, additionSubtractionLimiter + 1);
        } while(firstEquationNumber < resultEquationNumber);

        int secondEquationNumber = firstEquationNumber - resultEquationNumber;

        return new[] { firstEquationNumber, secondEquationNumber, resultEquationNumber };
    }

    public static int[] MultiplicationEquation() {
        multiplicationDivisionBottomLimiter = GetBottomLimiterForMultDiv();
        multiplicationDivisionLimiter = GetLimiterForMultDiv();

        int firstEquationNumber = Random.Range(multiplicationDivisionBottomLimiter, multiplicationDivisionLimiter);
        int secondEquationNumber = Random.Range(multiplicationDivisionBottomLimiter, multiplicationDivisionLimiter);
        int resultEquationNumber = firstEquationNumber * secondEquationNumber;

        return new[] { firstEquationNumber, secondEquationNumber, resultEquationNumber };
    }

    public static int[] DivisionEquation() {
        multiplicationDivisionBottomLimiter = GetBottomLimiterForMultDiv();
        multiplicationDivisionLimiter = GetLimiterForMultDiv();

        int firstEquationNumber = Random.Range(multiplicationDivisionBottomLimiter, multiplicationDivisionLimiter);
        int secondEquationNumber = Random.Range(multiplicationDivisionBottomLimiter, multiplicationDivisionLimiter);
        int resultEquationNumber = firstEquationNumber * secondEquationNumber;

        return new[] { resultEquationNumber, firstEquationNumber, secondEquationNumber };
    }
}
