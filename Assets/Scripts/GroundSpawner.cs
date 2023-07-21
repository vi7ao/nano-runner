using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
   public GameObject groundTile;
   Vector3 nextSpawnPoint;
    private void Start()
    {
        for (int i = 0; i < 10; i++){
            SpawnTile();
        }
    }
    public void SpawnTile(){
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position; // o 1 é o segundo filho (posicao de spawn), o primeiro é o chao
    }
}
