using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemy : MonoBehaviour
{
    private List<MonoBehaviour> scripts;
    private bool isPlayerNearby = false;
    
    void Start()
    {
        // Initialize the list of scripts
        scripts = new List<MonoBehaviour>();

        // Get all MonoBehaviour components attached to the GameObject
        foreach (MonoBehaviour script in GetComponents<MonoBehaviour>())
        {
            // Add the scripts to the list, excluding this script itself
            if (script != this)
            {
                scripts.Add(script);
                script.enabled = false; // Disable all scripts initially
            }
        }

        // Start the coroutine to handle script switching
        StartCoroutine(SwitchScripts());
    }

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        isPlayerNearby = Vector2.Distance(transform.position, player.transform.position) < 10f;
    }

    IEnumerator SwitchScripts()
    {
        while (true)
        {
            if (isPlayerNearby && scripts.Count > 0)
            {
                // Disable all scripts
                foreach (MonoBehaviour script in scripts)
                {
                    script.enabled = false;
                }

                // Randomly select one script to enable
                int randomIndex = Random.Range(0, scripts.Count);
                scripts[randomIndex].enabled = true;
            }

            // Wait for 1 second before the next switch
            yield return new WaitForSeconds(1f);
        }
    }
}