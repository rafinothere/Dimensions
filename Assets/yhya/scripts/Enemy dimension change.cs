using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemydimensionchange : MonoBehaviour
{
    public GameObject enemyToChange; // Assign this in the Unity Editor

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Portal projectile"))
        {
            // Get the current active scene's build index
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Generate a random dimension number (scene index) that is different from the current one
            int dimensionNum;
            do
            {
                dimensionNum = UnityEngine.Random.Range(0, SceneManager.sceneCountInBuildSettings);
            } while (dimensionNum == currentSceneIndex);

            Debug.Log($"Moving enemy to scene index: {dimensionNum}");

            // Load the target scene additively
            SceneManager.LoadScene(dimensionNum, LoadSceneMode.Additive);

            // Wait until the scene is fully loaded
            StartCoroutine(MoveEnemyToScene(dimensionNum));
        }
    }

    private IEnumerator MoveEnemyToScene(int targetSceneIndex)
    {
        // Wait until the new scene is fully loaded
        yield return new WaitUntil(() => SceneManager.GetSceneByBuildIndex(targetSceneIndex).isLoaded);

        // Get the target scene
        Scene targetScene = SceneManager.GetSceneByBuildIndex(targetSceneIndex);

        // Move the enemy to the target scene
        if (enemyToChange != null)
        {
            SceneManager.MoveGameObjectToScene(enemyToChange, targetScene);
        }

        // Optionally unload the current scene
        // Ensure this happens after the enemy has been moved
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}