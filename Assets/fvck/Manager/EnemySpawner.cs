using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> spawnPrefabs; // Assign your prefabs in the Inspector
    private float spawnInterval = 10f; // Initial spawn interval of 10 seconds

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnObject();
            yield return new WaitForSeconds(spawnInterval);
            spawnInterval *= 0.95f; // Decrease the interval by 5%
        }
    }

    private void SpawnObject()
    {
        if (spawnPrefabs.Count > 0)
        {
            int randomIndex = Random.Range(0, spawnPrefabs.Count);
            GameObject prefabToSpawn = spawnPrefabs[randomIndex];
            Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("No prefabs assigned to spawnPrefabs list.");
        }
    }

    void Update()
    {
        // Update logic if needed
    }


}
