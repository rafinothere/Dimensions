using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyDimensionchange : MonoBehaviour
{
    private int dimensionNum = -1;
    private bool change = false;
    public GameObject enemyToMove;
    private Vector3 offScreen = new Vector3(100000, 0, 0);

    [SerializeField] private enemyfollow enemyAI;

    void Update()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        if (dimensionNum == activeScene.buildIndex)
        {
            placeEnemy();
        }
    }

    //randomly selects dimension using build index
    private void selectDimension()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        do
        {
            dimensionNum = Random.Range(0, 3);
          //makes sure dimension its currently in not selected
        } while(dimensionNum == activeScene.buildIndex);
        Debug.Log(dimensionNum);
    }

    //moves enemy out of scene after being hit with portal
    private void OnTriggerEnter2D(Collider2D collide)
    {
        if(collide.CompareTag("Portal projectile"))
        {
            selectDimension();
            DontDestroyOnLoad(enemyToMove);
            enemyAI.enabled = false;
            transform.position = offScreen;
            change = true;
        }
    }

    //places enemy into active scene level
    private void placeEnemy()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.MoveGameObjectToScene(enemyToMove, activeScene);
        change = false;
        dimensionNum = -1;
        enemyAI.enabled = true;

    }


}
