using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float spawnOffset = 0.5f;
    private int spawnedEnemyCount = 0; // Counter for spawned enemies

    public List<GameObject> enemyPrefabs;  // List of enemy prefabs

    private float elapsedTime = 0f;  // Time elapsed since projectile creation

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 0.5f && spawnedEnemyCount < 2)
        {
            StartCoroutine(SpawnEnemies());
        }
    }

    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(0.5f);

        if (spawnedEnemyCount < 2 && enemyPrefabs.Count >= 2)
        {
            // Randomly select two enemy prefabs from the list
            int index1 = Random.Range(0, enemyPrefabs.Count);
            int index2;
            do
            {
                index2 = Random.Range(0, enemyPrefabs.Count);
            } while (index2 == index1);

            Vector3 spawnPosition1 = transform.position + new Vector3(-spawnOffset, 0, 0);
            Vector3 spawnPosition2 = transform.position + new Vector3(spawnOffset, 0, 0);

            // Instantiate the selected enemy prefabs at the calculated positions
            Instantiate(enemyPrefabs[index1], spawnPosition1, transform.rotation);
            Instantiate(enemyPrefabs[index2], spawnPosition2, transform.rotation);

            spawnedEnemyCount += 2; // Increment the spawned enemy count by 2
        }
    }
}
