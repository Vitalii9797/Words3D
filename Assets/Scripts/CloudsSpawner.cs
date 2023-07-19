using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] clouds;
    [SerializeField] private float spawnRate;
    [SerializeField] private float xSpawnPosition;
    [SerializeField] private float minYSpawnPosition, maxYSpawnPosition;
    [SerializeField] private float zSpawnPosition;
    void Start()
    {
        StartCoroutine(SpawnClouds());
    }

   private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(xSpawnPosition, Random.Range(minYSpawnPosition, maxYSpawnPosition), zSpawnPosition);
    }

    private GameObject GetRandomCloud()
    {
        return clouds[Random.Range(0, clouds.Length)];
    }

    private IEnumerator SpawnClouds()
    {
        while(true)
        {
            Instantiate(GetRandomCloud(), GetRandomSpawnPosition(), transform.rotation);

            yield return new WaitForSeconds(spawnRate);
        }
    }
}
