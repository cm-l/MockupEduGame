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
        InvokeRepeating("DestroyLastGround", 14f, 14f);
    }
    
    // Tworzy klony podłogi
    public void SpawnTile() {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
       
        instantiatedTiles.Add(temp);
        instantiatedTilesArray = instantiatedTiles.ToArray(); 
    }

    public void DestroyLastGround() {
        Destroy(instantiatedTilesArray[lastDestroyedIndex], 0f);
        lastDestroyedIndex++;
    }
}
