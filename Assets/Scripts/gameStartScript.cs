using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStartScript : MonoBehaviour
{
    public GameObject player { get; private set; }
    public WallSpawnScript wallSpawnScript { get; private set;}

    private bool isGameActive = false;
    IEnumerator wallSpawning;
    [SerializeField] private GameObject _tutorialText;
    [SerializeField] private GameObject _pointsText;
    private void Start()
    {
        wallSpawnScript = GetComponent<WallSpawnScript>();
        player = GameObject.Find("Player");
        wallSpawning = wallSpawnScript.SpawnWalls(wallSpawnScript._spawnTime);
    }
    void Update()
    {
        if (!isGameActive && (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space")))
        {   
            StartCoroutine(wallSpawning);
            _tutorialText.SetActive(false);
            _pointsText.SetActive(true);
            player.GetComponent<PlayerMovementScript>().playerRigidbody.gravityScale = 2;
            player.GetComponent<Animator>().enabled = false;
            isGameActive = true;
        }
        if(isGameActive && player.GetComponent<PlayerMovementScript>().isPlayerAlive == false)
        {
            StopCoroutine(wallSpawning);
        }
    }
}
