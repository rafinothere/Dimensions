using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectilelifetime : MonoBehaviour
{
    private float lifespan = 5f;

    void Update()
    {
        lifetime();
    }

    private void lifetime()
    {
        if(lifespan > 0)
        {
            lifespan -= Time.deltaTime;
        }
        else if((gameObject.name != "Portal") && (gameObject.name != "Circle"))
        {
            Destroy(gameObject);
        }
    }

}   