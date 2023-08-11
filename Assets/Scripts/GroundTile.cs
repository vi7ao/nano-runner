using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public bool isFirstTile = true;
    [SerializeField]
    private GameObject[] obstaclePrefabs;
    [SerializeField]
    private GameObject coin;

    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        if (!isFirstTile)
        {
            SpawnObstacle();
            SpawnCoins();
        }
    }

    private void OnTriggerExit(Collider other) {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 3);
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

    void SpawnCoins(){
        int coinSpawnIndex = Random.Range(7, 10); // spawnar as moedas no meio (pelo eixo Z) do tile (index 7, 8 e 9 do ground tile)
        Transform spawnPoint = transform.GetChild(coinSpawnIndex).transform;
        Instantiate(coin, spawnPoint.position, Quaternion.identity, transform);
    }
}
