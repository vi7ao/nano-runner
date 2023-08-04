using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
 
    Movement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<Movement>();

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision with " + other.gameObject.name);
        if (other.gameObject.name == "Player")
        {
            playerMovement.Die();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
