using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsMovementScript : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _lifespan;
    public PlayerMovementScript playerMovementScript { get; private set; }
    public Rigidbody2D wallRigidbody { get; private set; }
    void Start()
    {
        playerMovementScript = FindObjectOfType<PlayerMovementScript>();
        wallRigidbody = GetComponent<Rigidbody2D>();
        wallRigidbody.velocity = Vector3.left * _movementSpeed;
        StartCoroutine(AliveTime(_lifespan));
    }

    void Update()
    {
        if (!playerMovementScript.isPlayerAlive)
        {
            StopAllCoroutines();
            wallRigidbody.velocity = Vector2.zero;
        }
    }
    public IEnumerator AliveTime(float lifespan)
    {
        yield return new WaitForSeconds(lifespan);
        Destroy(this.gameObject);
    }
}
