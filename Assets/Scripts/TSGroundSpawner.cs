using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class TSGroundSpawner : MonoBehaviour {
    
    public GameObject groundTile;
    Vector3 nextSpawnPoint = new Vector3(0, 0, 0);
    private List<GameObject> instantiatedTiles = new List<GameObject>();
    private int instantiatedTilesAmount;

    void Awake() {
        SpawnTile();
    }
    void Start() {
        TMPController.firstRun = true;

        InvokeRepeating("SpawnTile", 0f, 12f);
        InvokeRepeating("DestroyLastGround", 14f, 14f);
    }

    // Tworzy klony podłogi
    public void SpawnTile() {
        if (instantiatedTilesAmount <= 4) {
            GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
            nextSpawnPoint = temp.transform.GetChild(1).transform.position;
            instantiatedTiles.Add(temp);
            instantiatedTilesAmount = instantiatedTiles.Count;
        }

    }

    public void DestroyLastGround() {
        if (instantiatedTilesAmount > 3) {
            Destroy(instantiatedTiles[0], 0f);
            instantiatedTiles.RemoveAt(0);
            instantiatedTilesAmount = instantiatedTiles.Count;

        }
    }
}
