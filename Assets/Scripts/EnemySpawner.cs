using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour {
    private string activeSceneName;
    GroundSpawner groundSpawner;

    void Start() {
        activeSceneName = SceneManager.GetActiveScene().name;
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        
        if(TMPController.rowCounter <= 8)
            SpawnNumbersAndEnemies();
    }

    private void OnTriggerExit(Collider other) {
        if(TMPController.rowCounter != 0){
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
        }
    }

    public static int firstEquationNumberOnMonster;
    public static int resultEquationNumberOnMonster;

    public static int firstEquationNumber;
    public static int secondEquationNumber;
    public static int resultEquationNumber;
       
    private static GameObject[] spawnPoints = new GameObject[3];
    public void SpawnNumbersAndEnemies() {
        
        int[] equationNumbers = new int[3];
        
        switch (activeSceneName) {
            case "AdditionScene": equationNumbers = RandomNumber.AdditionEquation(); break;
            case "SubtractionScene": equationNumbers = RandomNumber.SubtractionEquation(); break;
            case "MultiplicationScene": equationNumbers = RandomNumber.MultiplicationEquation(); break;
            case "DivisionScene": equationNumbers = RandomNumber.DivisionEquation(); break;
            default: Debug.Log("Something broke"); break;
        }

        firstEquationNumber = equationNumbers[0];
        secondEquationNumber = equationNumbers[1];
        resultEquationNumber = equationNumbers[2];

        int correctNumber = secondEquationNumber;
        int randomCorrectNumberIndex = Random.Range(0, spawnPoints.Length);
        int secondDisplayedNumber = correctNumber;
        int firstDisplayedNumber;
        
        do {
            firstDisplayedNumber = Random.Range(secondDisplayedNumber - 4, secondDisplayedNumber + 6);
        }
        while (firstDisplayedNumber == secondDisplayedNumber || firstDisplayedNumber < 0);

        int thirdDisplayedNumber;
        do {
            thirdDisplayedNumber = Random.Range(secondDisplayedNumber - 4, secondDisplayedNumber + 6);
        } 
        while ((thirdDisplayedNumber == firstDisplayedNumber) || (thirdDisplayedNumber == secondDisplayedNumber) || (thirdDisplayedNumber < 0));

        int[] displayedNumbers = new int[spawnPoints.Length];
        for (int j = 0; j < displayedNumbers.Length; j++) {
            if (j == randomCorrectNumberIndex)
                displayedNumbers[j] = secondDisplayedNumber;
            else {
                bool containsNumber = displayedNumbers.Contains(firstDisplayedNumber);
                if (containsNumber)
                    displayedNumbers[j] = thirdDisplayedNumber;
                else
                    displayedNumbers[j] = firstDisplayedNumber;
            }
        }

        List<List<int>> equations = new List<List<int>>();
        
        equations.Add(new List<int>() { firstEquationNumber, resultEquationNumber });
        firstEquationNumberOnMonster = equations[0][0];
        resultEquationNumberOnMonster = equations[0][1];
        
        equations.RemoveAt(0);

        if (TMPController.firstRun) {
            TMPController.rowCounter--;
            TMPController.changeEquation(EnemySpawner.firstEquationNumberOnMonster, EnemySpawner.resultEquationNumberOnMonster);
            TMPController.firstRun = false;
        }

        SpawnEnemies(spawnPoints, randomCorrectNumberIndex, displayedNumbers);
    }

    private TMP_Text textOnMonster;

    public GameObject obstaclePrefab;
    public GameObject numberPrefab;

    private void SpawnEnemies(GameObject[] spawnPoints, int rndCorrectNumIndex, int[] displayedNumbers) {
        
        for (int i = 0; i < spawnPoints.Length; i++){
            Transform spawnPoint = transform.GetChild(i + 2).transform;
            Vector3 newPosition = new Vector3(spawnPoint.position.x, spawnPoint.position.y + (float)1.15, spawnPoint.position.z - 0.1f);
            spawnPoints[i] = Instantiate(numberPrefab, newPosition, Quaternion.identity, transform);

            textOnMonster = spawnPoints[i].GetComponent<TextMeshPro>();
            if (i == rndCorrectNumIndex) {
                textOnMonster.gameObject.tag = "Good";
                textOnMonster.SetText(displayedNumbers[i].ToString() ); // usunięte na test: + "!"
            } else {
                textOnMonster.SetText(displayedNumbers[i].ToString());
            }

            Transform spawnPointEnemy = transform.GetChild(i + 2).transform; // get the child transform at the current index
            Vector3 newPositionEnemy = new Vector3(spawnPointEnemy.position.x, spawnPointEnemy.position.y + (float)1.15, spawnPointEnemy.position.z);
            spawnPoints[i] = Instantiate(obstaclePrefab, newPositionEnemy, Quaternion.Euler(0, 0, 180), transform);
            if (i == rndCorrectNumIndex) {
                spawnPoints[i].gameObject.tag = "Good";
            }
        }
    }
}
