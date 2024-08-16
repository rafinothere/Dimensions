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
    private LevelManager RoomCounter;


    void Start()
    {
        GetRoomCount();
        if(RoomCounter.RoomCount > 0)
        {
            SpawnRoom();
            RoomCounter.RoomCount--;
        }
    }

    //checks if theres already a room there
    void OnTriggerEnter2D(Collider2D RoomCheck)
    {
        if(RoomCheck.CompareTag("Room"))
        {
            Debug.Log("room Detected");
            Destroy(gameObject);
            Debug.Log("NodeDestroyed");
        }
    }

    private void SpawnRoom()
    {
        if(RoomSpawned == false)
        {
            Debug.Log("attempting room spawn");
            int randomIndex;
            switch(ConnectorType)
            {
            case 1:
                //spawn room with a bottom connector
                randomIndex = Random.Range(0, BottomRooms.Length);
                Instantiate(BottomRooms[randomIndex], transform.position, BottomRooms[randomIndex].transform.rotation);
                Debug.Log("Room Spawned");
                break;
            case 2:
                //spawn a room with a top connector
                randomIndex = Random.Range(0, TopRooms.Length);
                Instantiate(TopRooms[randomIndex], transform.position, BottomRooms[randomIndex].transform.rotation);
                Debug.Log("Room Spawned");
                break;
            case 3:
                //spawn a room with right connector
                randomIndex = Random.Range(0, RightRooms.Length);
                Instantiate(RightRooms[randomIndex], transform.position, BottomRooms[randomIndex].transform.rotation);
                Debug.Log("Room Spawned");
                break;
            case 4: 
                //spawn a room with left coonector
                randomIndex = Random.Range(0, LeftRooms.Length);
                Instantiate(LeftRooms[randomIndex], transform.position, BottomRooms[randomIndex].transform.rotation);
                Debug.Log("Room Spawned");
                break;
            default:
                Debug.LogError("connector type not assigned");
                break;
            }
            RoomSpawned = true;
            Destroy(gameObject);
        }
    }

    private void GetRoomCount()
    {
        GameObject LevelManagerObject = GameObject.Find("LevelManager");
        RoomCounter = LevelManagerObject.GetComponent<LevelManager>();
        if(RoomCounter == null)
        {
            Debug.LogError("manager not found");
        }
    }
}
