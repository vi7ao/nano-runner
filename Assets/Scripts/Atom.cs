using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] 
    private float rotateSpeed = 90f;
    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.name != "Player")
        {
            return;
        }
        else
        {
            GameManager.instance.ScoreUp();
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
