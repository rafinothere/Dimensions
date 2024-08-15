using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRoom : MonoBehaviour
{
    [SerializeField] private GameObject[] TopRooms;
    [SerializeField] private GameObject[] BottomRooms;
    [SerializeField] private GameObject[] LeftRooms;
    [SerializeField] private GameObject[] RightRooms;
    [SerializeField] private int ConnectorType; // number representing where the spawn node is
    private bool RoomSpawned = false;

    void Start()
    {

    }

    //checks if theres already a room there
    void OnTriggerEnter2D(Collider2D RoomCheck)
    {
        if(RoomCheck.CompareTag("Room"))
        {
            Destroy(gameObject);
        }
    }

    private void SpawnRoom()
    {
        if(RoomSpawned == false)
        {
            Debug.Log("attempting room spawn");
            switch(ConnectorType)
            {
            case 1:
                //spawn room with a bottom connector
                break;
            case 2:
                //spawn a room with a top connector
                break;
            case 3:
                //spawn a room with right connector
                break;
            case 4: 
                //spawn a room with left coonector
                break;
            default:
                Debug.LogError("connector type not assigned");
                break;
            }
        }
    }
}
