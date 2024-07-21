using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemydimensionchange : MonoBehaviour
{
    public GameObject enemyToMove; // Assign this in the Unity Editor
    public int dimensionNum;

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if((collide.gameObject.tag == "Portal projectile"))
        {
            Debug.Log("collision detected");
            do
            {
                dimensionNum = UnityEngine.Random.Range(0,3);
            } while (dimensionNum == SceneManager.GetActiveScene().buildIndex);
            LoadAndUnloadScene(dimensionNum);
        }
    }

    public void LoadAndUnloadScene(int dimensionNum)
    {
        StartCoroutine(LoadAndUnload(dimensionNum));
    }

    private IEnumerator LoadAndUnload(int dimensionNum)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(dimensionNum, LoadSceneMode.Additive);
        SceneManager.MoveGameObjectToScene(enemyToMove, SceneManager.GetSceneByBuildIndex(dimensionNum));

        yield return loadOperation;

        SceneManager.UnloadSceneAsync(dimensionNum);

    }



            
            
}
