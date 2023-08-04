using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public bool isFirstTile = true;
    public GameObject[] obstaclePrefabs;
    public GameObject firstTilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        if (isFirstTile)
        {
            SpawnFirstTile();
        }
        else
        {
            SpawnObstacle();
        }
        isFirstTile = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other) {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 3);
    }

    void SpawnFirstTile(){
        Instantiate(firstTilePrefab, transform.position, Quaternion.identity, transform);
    }

    void SpawnObstacle(){
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject selectedObject = obstaclePrefabs[randomIndex];
        int obstacleSpawnIndex = 0;
        if (randomIndex <= 1){ // caso seja os obstaculos de 1/3 do caminho (index 0 e 1), pode spawnar left, right ou middle
            obstacleSpawnIndex = Random.Range(2, 5);
        }
        else if (randomIndex == 2 || randomIndex == 3){ // esses só podem spawnar nos cantos (index 2 e 3 do ground tile)
            obstacleSpawnIndex = Random.Range(5, 7);
        }
        else if (randomIndex == 4){ // esse só pode spawnar no meio (index 4 do ground tile)
            obstacleSpawnIndex = 4;
        }
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        Instantiate(selectedObject, spawnPoint.position, Quaternion.identity, transform);
    }
}
