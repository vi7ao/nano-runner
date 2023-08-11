using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject groundTile;
    Vector3 nextSpawnPoint;
    private void Start()
    {
        for (int i = 0; i < 10; i++){
            if (i == 0 || i == 1)
            {
                SpawnFirstTile();
            }
            else
            {
                SpawnTile();
            }
        }
    }
    public void SpawnTile(){
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position; // o 1 é o segundo filho (posicao de spawn), o primeiro é o chao
        temp.GetComponent<GroundTile>().isFirstTile = false;
    }
    void SpawnFirstTile()
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }
}
