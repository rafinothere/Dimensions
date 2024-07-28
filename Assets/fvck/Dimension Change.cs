using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dimensionchange : MonoBehaviour
{

    public GameObject objectToMove;

    //change dimension when touching portal
    void OnCollisionEnter2D(Collision2D collide)
    {
        if(collide.gameObject.name =="portal")
        {
            int dimensionNum;
            do
            {
                dimensionNum = UnityEngine.Random.Range(2,5);
            } while (dimensionNum == SceneManager.GetActiveScene().buildIndex);
            DontDestroyOnLoad(objectToMove);
             SceneManager.LoadScene(dimensionNum);
        }
    }




}
