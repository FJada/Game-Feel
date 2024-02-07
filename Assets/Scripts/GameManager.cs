using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static float Score = 0;
    public static bool GameOver = false;

    //public PlayerController Player;
    public ParticleSystem BackgroundParticleSystem;
    public TextMeshProUGUI ScoreText;
    //public List<Minigames> games;
    private float spawnTimer = 0;
    private float gameOverDelay = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        int rand = Random.Range(0, 2);
        //games.Play();
        //pick a minigame
        //play the minigame
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
