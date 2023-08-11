using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private int score;
    public static GameManager instance;

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Movement playerMovement;

    public void ScoreUp()
    {
        score++;
        scoreText.text = "Pontos: " + score.ToString();
        playerMovement.speed += playerMovement.speedMultiplier;
    }

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
