using UnityEngine;


public class GroundSpawner : MonoBehaviour {
    
    public GameObject groundTile;
    Vector3 nextSpawnPoint = new Vector3(0, 0, 12);

    void Start() {
        TMPController.firstRun = true;
        
        for (int i = 0; i < 2; i++)
            SpawnTile();
    }
    
    // Tworzy klony podłogi
    public void SpawnTile() {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }
}
