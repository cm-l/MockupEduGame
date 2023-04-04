using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSGroundSpawner : MonoBehaviour {
    public GameObject groundTile;
    Vector3 nextSpawnPoint = new Vector3(0, 0, 0);
    private List<GameObject> instantiatedTiles = new List<GameObject>();
    private GameObject[] instantiatedTilesArray;
    private int lastDestroyedIndex = 0;

    void Start() {
        TMPController.firstRun = true;
        
        //SpawnTile();
        InvokeRepeating("SpawnTile", 0.0f, 6.0f);
        InvokeRepeating("DestroyLastGround", 18f, 18f);
    }
    
    // Tworzy klony podłogi
    public void SpawnTile() {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        //Destroy(temp, 2f);
        instantiatedTiles.Add(temp);

        // Convert the list of instantiated tiles to an array
        instantiatedTilesArray = instantiatedTiles.ToArray();
        for(int i = 0; i < instantiatedTilesArray.Length; i++) {
            Debug.Log(instantiatedTilesArray[i]);
        }
    }

    public void DestroyLastGround() {
        Destroy(instantiatedTilesArray[lastDestroyedIndex], 0f);
        lastDestroyedIndex++;
    }
}
