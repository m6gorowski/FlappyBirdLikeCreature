using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public bool isPlayerAlive = true;
    public Rigidbody2D playerRigidbody { get; private set; }
    [SerializeField] private float _acceleration;
    [SerializeField] private float _jumpRotationPower;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isPlayerAlive)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
            {
                Jump();
            }
            transform.eulerAngles = new Vector3(0, 0, playerRigidbody.velocity.y * _jumpRotationPower);
            return;
        }
    }

    private void Jump()
    {
        playerRigidbody.velocity = Vector2.up * _acceleration;
    }
}
