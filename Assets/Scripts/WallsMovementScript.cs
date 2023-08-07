using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WallsMovementScript : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _lifespan;
    public PlayerMovementScript playerMovementScript { get; private set; }
    private IEnumerator _aliveCoroutine;

    //private IEnumerator _aliveCoroutine;
    void Start()
    {
        playerMovementScript = FindObjectOfType<PlayerMovementScript>();
        _aliveCoroutine = AliveTime(_lifespan);
        StartCoroutine(_aliveCoroutine);
    }

    void Update()
    {
        if (playerMovementScript.isPlayerAlive)
        {
            Movement();
        }
        else
        {
            StopCoroutine(_aliveCoroutine);
            this.enabled = false;
        }        
    }
    public IEnumerator AliveTime(float lifespan)
    {
        yield return new WaitForSeconds(lifespan);
        Destroy(this.gameObject);
    }
    private void Movement()
    {
        float delta = _movementSpeed * Time.deltaTime;
        transform.position -= new Vector3(delta, 0f, 0f);
    }
}
