using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumber : MonoBehaviour
{
    public static int[] AdditionEquation() {
        int firstEquationNumber;
        int resultEquationNumber;
        do {
            firstEquationNumber = Random.Range(1, 21);
            resultEquationNumber = Random.Range(1, 21);
        } while(firstEquationNumber >= resultEquationNumber);

        int secondEquationNumber = resultEquationNumber - firstEquationNumber;
        
        return new []{ firstEquationNumber, secondEquationNumber, resultEquationNumber };
    }

    public static int[] SubtractionEquation() {
        int firstEquationNumber;
        int resultEquationNumber;
        do
        {
            firstEquationNumber = Random.Range(1, 21);
            resultEquationNumber = Random.Range(1, 21);
        } while (firstEquationNumber < resultEquationNumber);

        int secondEquationNumber = firstEquationNumber - resultEquationNumber;

        return new[] { firstEquationNumber, secondEquationNumber, resultEquationNumber };
    }

    public static int[] MultiplicationEquation() {
        int firstEquationNumber = Random.Range(1, 8);
        int secondEquationNumber = Random.Range(1, 8); ;
        int resultEquationNumber = firstEquationNumber * secondEquationNumber;

        return new[] { firstEquationNumber, secondEquationNumber, resultEquationNumber };
    }

    public static int[] DivisionEquation() {
        int firstEquationNumber = Random.Range(1, 8);
        int secondEquationNumber = Random.Range(1, 8); ;
        int resultEquationNumber = firstEquationNumber * secondEquationNumber;

        return new[] { resultEquationNumber, firstEquationNumber, secondEquationNumber };
    }
}
