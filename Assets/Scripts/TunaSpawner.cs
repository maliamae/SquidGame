using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunaSpawner : MonoBehaviour
{
    public GameObject tunaPrefab;
    public float maxSpawnTime = 3f;
    public float minSpawnTime = 1.0f;
    public int maxFish = 2;
    //private int count = 0;

    private void Start()
    {
        StartCoroutine(spawnTuna(tunaPrefab, minSpawnTime, maxSpawnTime));
    }
    private void Update()
    {
        
    }

    IEnumerator spawnTuna(GameObject prefab, float maxTime, float minTime)
    {
        float spawnTime = Random.Range(minSpawnTime, maxSpawnTime);

        Instantiate(prefab, transform.position, Quaternion.identity);
        
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(spawnTuna(prefab, maxTime, minTime));

    }

}
