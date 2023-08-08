using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerDeathScript : MonoBehaviour
{
    public PlayerMovementScript playerMovementScript { get; private set; }
    public Rigidbody2D playerRigidbody { get; private set; }
    public AudioManagerScript audioManagerScript { get; private set; }
    public WallSpawnScript wallSpawnScript { get; private set; }

    [SerializeField] private GameObject _gameOverScreen;
    void Start()
    {
        playerMovementScript = GetComponent<PlayerMovementScript>();
        playerRigidbody = GetComponent<Rigidbody2D>();
        wallSpawnScript = FindObjectOfType<WallSpawnScript>();
        audioManagerScript = FindObjectOfType<AudioManagerScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            if (playerMovementScript.isPlayerAlive)
            {
                audioManagerScript.PlaySFX(audioManagerScript.death);
            }
            playerMovementScript.isPlayerAlive = false;
            wallSpawnScript.enabled = false;
            _gameOverScreen.SetActive(true);
        }
        if(collision.tag == "Ground")
        {
            if (playerMovementScript.isPlayerAlive)
            {
                audioManagerScript.PlaySFX(audioManagerScript.death);
            }
            playerMovementScript.isPlayerAlive = false;
            playerMovementScript.playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.gravityScale = 0;            
            wallSpawnScript.enabled = false;
            _gameOverScreen.SetActive(true);

        }
    }
}
