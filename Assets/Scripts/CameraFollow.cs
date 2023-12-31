using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    Vector3 offset;
    private void Start()
    {
        offset = transform.position - player.position;
    }

    private void Update()
    {
        Vector3 targetPosition = player.position + offset;
        targetPosition.x = 0; // Pra camera nao mexer no eixo X
        transform.position = targetPosition;
    }
}
