using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSGroundSpawner : MonoBehaviour {
    public GameObject groundTile;
    Vector3 nextSpawnPoint = new Vector3(0, 0, 0);

    void Start() {
        TMPController.firstRun = true;
        
        //SpawnTile();
        InvokeRepeating("SpawnTile", 0.0f, 2.0f);
    }
    
    // Tworzy klony podłogi
    public void SpawnTile() {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        //Destroy(temp, 2f);
    }
}
