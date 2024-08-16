using System.Collections.Generic;
using UnityEngine;

public class BehaviourManager : MonoBehaviour
{
    // A public list to specify which scripts need to be constantly active
    public List<MonoBehaviour> activeScripts;

    // A public list where one script will be randomly activated
    public List<MonoBehaviour> randomizeScripts;

    // Timer to control how often the random script activation occurs
    private float timer = 0f;
    public float switchInterval = 1f; // Interval in seconds

    void Start()
    {
        // Ensure all scripts in the activeScripts list are enabled
        foreach (var script in activeScripts)
        {
            if (script != null && !script.enabled)
            {
                script.enabled = true;
            }
        }

        // Disable all scripts in the randomizeScripts list initially
        foreach (var script in randomizeScripts)
        {
            if (script != null && script.enabled)
            {
                script.enabled = false;
            }
        }

        // Initial random activation
        ActivateRandomScript();
    }

    void Update()
    {
        // Ensure all scripts in the activeScripts list remain active
        foreach (var script in activeScripts)
        {
            if (script != null && !script.enabled)
            {
                script.enabled = true;
            }
        }

        // Update the timer and switch active script if interval has passed
        timer += Time.deltaTime;
        if (timer >= switchInterval)
        {
            ActivateRandomScript();
            timer = 0f; // Reset the timer
        }
    }

    void ActivateRandomScript()
    {
        // Disable all scripts in the randomizeScripts list
        foreach (var script in randomizeScripts)
        {
            if (script != null)
            {
                script.enabled = false;
            }
        }

        // Randomly activate one script from the randomizeScripts list
        if (randomizeScripts.Count > 0)
        {
            int randomIndex = Random.Range(0, randomizeScripts.Count);
            if (randomizeScripts[randomIndex] != null)
            {
                randomizeScripts[randomIndex].enabled = true;
            }
        }
    }
}
