using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathScript : MonoBehaviour
{
    public PlayerMovementScript playerMovementScript { get; private set; }
    public Rigidbody2D playerRigidbody { get; private set; }
    void Start()
    {
        playerMovementScript = GetComponent<PlayerMovementScript>();
        playerRigidbody = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            playerMovementScript.isPlayerAlive = false;
        }
        if(collision.tag == "Ground")
        {
            playerMovementScript.isPlayerAlive = false;
            playerMovementScript.playerRigidbody.velocity = Vector2.zero;
            playerRigidbody.gravityScale = 0;
        }
    }
}
