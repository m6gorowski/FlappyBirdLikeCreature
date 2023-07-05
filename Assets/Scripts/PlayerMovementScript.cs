using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public Rigidbody2D playerRigidbody { get; private set; }
    [SerializeField] private float _acceleration;
    [SerializeField] private float _jumpRotationPower;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
        {
            Jump();
        }
        transform.eulerAngles = new Vector3(0, 0, playerRigidbody.velocity.y * _jumpRotationPower);
    }

    private void Jump()
    {
        playerRigidbody.velocity = Vector2.up * _acceleration;
    }
}
