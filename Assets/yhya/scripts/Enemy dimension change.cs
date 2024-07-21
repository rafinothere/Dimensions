using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemydimensionchange : MonoBehaviour
{

    public GameObject enemyToChange;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collide)
    {
        if (collide.gameObject.tag == "Portal projectile")
        {
            int dimensionNum = UnityEngine.Random.Range(0,3);
            if((dimensionNum == SceneManager.GetActiveScene().buildIndex) && (dimensionNum == 3))
            {
                dimensionNum = 0;
            }
            else if(dimensionNum == SceneManager.GetActiveScene().buildIndex)
            {
                dimensionNum += 1;
            }
            SceneManager.LoadScene(dimensionNum, LoadSceneMode.Additive);
            Scene targetScene = SceneManager.GetSceneByBuildIndex(dimensionNum);
            SceneManager.MoveGameObjectToScene(enemyToChange, targetScene);
            SceneManager.UnloadSceneAsync(dimensionNum);
        }
        
    }
}
