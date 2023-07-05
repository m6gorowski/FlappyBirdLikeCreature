using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [Header("Wall Spawning")]
    [SerializeField] private GameObject _wallPrefab;
    [SerializeField] private float _spawnTime;
    [Header("Wall Spawning - the coordinates")]
    [SerializeField] private float _Xspawn;
    [SerializeField] private float _YspawnTop;
    [SerializeField] private float _YspawnBottom;
    void Start()
    {
        StartCoroutine(SpawnWalls(_spawnTime));
    }
    void Update()
    {
        
    }
    private IEnumerator SpawnWalls(float spawnTime)
    {
        while(true) { 
            yield return new WaitForSeconds(spawnTime);
            Instantiate(_wallPrefab, new Vector3(_Xspawn, Random.Range(_YspawnBottom, _YspawnTop)), Quaternion.identity);
        }
    }
}
