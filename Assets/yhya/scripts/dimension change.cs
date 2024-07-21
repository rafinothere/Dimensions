using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dimensionchange : MonoBehaviour
{

    public GameObject objectToMove;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //change dimension when touching portal
    void OnCollisionEnter2D(Collision2D collide)
    {
        if(collide.gameObject.name =="portal")
        {
            int dimensionNum;
            do
            {
                dimensionNum = UnityEngine.Random.Range(0,3);
            } while (dimensionNum == SceneManager.GetActiveScene().buildIndex);
            DontDestroyOnLoad(objectToMove);
             SceneManager.LoadScene(dimensionNum);
        }
    }




}
