using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScriptList
{
    public string situationName;
    public List<MonoBehaviour> scripts;
}

public class BehaviourManager : MonoBehaviour
{
    [SerializeField]
    private List<ScriptList> scriptLists;

    // Method to play all scripts for a given situation
    public void PlayScripts(string situation)
    {
        ScriptList list = scriptLists.Find(x => x.situationName == situation);
        if (list != null)
        {
            foreach (MonoBehaviour script in list.scripts)
            {
                script.enabled = true;  // Assuming 'playing' means enabling the script
            }
        }
    }

    // Method to stop all scripts for a given situation
    public void StopScripts(string situation)
    {
        ScriptList list = scriptLists.Find(x => x.situationName == situation);
        if (list != null)
        {
            foreach (MonoBehaviour script in list.scripts)
            {
                script.enabled = false;  // Assuming 'stopping' means disabling the script
            }
        }
    }
}
