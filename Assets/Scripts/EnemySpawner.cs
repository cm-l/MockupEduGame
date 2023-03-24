using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public TMP_Text text;
    public int resultNum;
    string activeSceneName;

    void Start()
    {
        activeSceneName = SceneManager.GetActiveScene().name;
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        if(TMPController.lineController <= 8){
            SpawnNumbersAndEnemies();
        }
        
    }


    private void OnTriggerExit(Collider other) {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    public GameObject obstaclePrefab;
    public static GameObject[] spawnPoints = new GameObject[3];
    public GameObject numberPrefab;

    List<List<int>> equations = new List<List<int>>();
    public static int tmpfirstEquationNumber;
    public static int tmpresultEquationNumber;


    public static int firstEquationNumber;
    public static int secondEquationNumber;
    public static int resultEquationNumber;



    void SpawnNumbersAndEnemies(){

        // Debug.Log(activeSceneName);
        int[] equationNumbers = new int[3];
        switch (activeSceneName)
        {
            case "AdditionScene": equationNumbers = RandomNumber.AdditionEquation(); break;
            case "SubtractionScene": equationNumbers = RandomNumber.SubtractionEquation(); break;
            case "MultiplicationScene": equationNumbers = RandomNumber.MultiplicationEquation(); break;
            case "DivisionScene": equationNumbers = RandomNumber.DivisionEquation(); break;
            default: Debug.Log("Uh"); break;
        }
        // Numbers
        firstEquationNumber = equationNumbers[0];
        secondEquationNumber = equationNumbers[1];
        resultEquationNumber = equationNumbers[2];

        int correctNumber = secondEquationNumber;
        int randomCorrectNumberIndex = Random.Range(0, spawnPoints.Length);
        int secondDisplayedNumber = correctNumber;
        int firstDisplayedNumber;
        
        do
        {
            firstDisplayedNumber = Random.Range(secondDisplayedNumber - 4, secondDisplayedNumber + 6);
        }
        while (firstDisplayedNumber == secondDisplayedNumber);

        int thirdDisplayedNumber;
        do
        {
            thirdDisplayedNumber = Random.Range(secondDisplayedNumber - 4, secondDisplayedNumber + 6);
        } 
        while ((thirdDisplayedNumber == firstDisplayedNumber) || (thirdDisplayedNumber == secondDisplayedNumber));

        int[] displayedNumbers = new int[spawnPoints.Length];
        for (int j = 0; j < displayedNumbers.Length; j++)
        {
            if (j == randomCorrectNumberIndex)
                displayedNumbers[j] = secondDisplayedNumber;
            else
            {
                bool containsNumber = displayedNumbers.Contains(firstDisplayedNumber);
                if (containsNumber)
                    displayedNumbers[j] = thirdDisplayedNumber;
                else
                    displayedNumbers[j] = firstDisplayedNumber;
            }
        }
         

        equations.Add(new List<int>() { firstEquationNumber, resultEquationNumber });
        tmpfirstEquationNumber = equations[0][0];
        tmpresultEquationNumber = equations[0][1];
        equations.RemoveAt(0);


        // Enemies
        for (int i = 0; i < spawnPoints.Length; i++){
            Transform spawnPoint = transform.GetChild(i + 2).transform;
            Vector3 newPosition = new Vector3(spawnPoint.position.x, spawnPoint.position.y + (float)1.15, spawnPoint.position.z - 0.1f);
            spawnPoints[i] = Instantiate(numberPrefab, newPosition, Quaternion.identity, transform);

            TextMeshPro text = spawnPoints[i].GetComponent<TextMeshPro>();
            if (i == randomCorrectNumberIndex) {
                // text.SetText("GoodAns");
                text.gameObject.tag = "Good";
                text.SetText(displayedNumbers[i].ToString() + " !");
                //Debug.Log(goodNumPos);
            } else {
                text.SetText(displayedNumbers[i].ToString());
            }

            Transform spawnPointEnemy = transform.GetChild(i + 2).transform; // get the child transform at the current index
            Vector3 newPositionEnemy = new Vector3(spawnPointEnemy.position.x, spawnPointEnemy.position.y + (float)1.15, spawnPointEnemy.position.z);
            spawnPoints[i] = Instantiate(obstaclePrefab, newPositionEnemy, Quaternion.Euler(0, 0, 180), transform);
            if (i == randomCorrectNumberIndex) {
                spawnPoints[i].gameObject.tag = "Good";
            }
        }
    }
}
