 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRoom : MonoBehaviour
{
    [SerializeField] private GameObject[] TopRooms;
    [SerializeField] private GameObject[] BottomRooms;
    [SerializeField] private GameObject[] LeftRooms;
    [SerializeField] private GameObject[] RightRooms;
    [SerializeField] private int ConnectorType; // Number representing where the spawn node is
    private bool RoomSpawned = false;
    private LevelManager RoomCounter;

    // Delay time before spawning a room
    [SerializeField] private float spawnDelay = 2.0f;

    void Start()
    {
        GetRoomCount();
        if (RoomCounter.RoomCount > 0)
        {
            Debug.Log("Attempting room spawn after delay");
            StartCoroutine(SpawnRoomWithDelay()); // Start the coroutine
            RoomCounter.RoomCount--;
        }
    }

    // Coroutine to spawn a room with a delay
    private IEnumerator SpawnRoomWithDelay()
    {
        yield return new WaitForSeconds(spawnDelay); // Wait for the specified delay

        if (!RoomSpawned)
        {
            int randomIndex;
            switch (ConnectorType)
            {
                case 1:
                    // Spawn room with a bottom connector
                    randomIndex = Random.Range(0, BottomRooms.Length);
                    Instantiate(BottomRooms[randomIndex], transform.position, BottomRooms[randomIndex].transform.rotation);
                    Debug.Log("Bottom Room Spawned");
                    break;
                case 2:
                    // Spawn a room with a top connector
                    randomIndex = Random.Range(0, TopRooms.Length);
                    Instantiate(TopRooms[randomIndex], transform.position, TopRooms[randomIndex].transform.rotation);
                    Debug.Log("Top Room Spawned");
                    break;
                case 3:
                    // Spawn a room with right connector
                    randomIndex = Random.Range(0, RightRooms.Length);
                    Instantiate(RightRooms[randomIndex], transform.position, RightRooms[randomIndex].transform.rotation);
                    Debug.Log("Right Room Spawned");
                    break;
                case 4:
                    // Spawn a room with left connector
                    randomIndex = Random.Range(0, LeftRooms.Length);
                    Instantiate(LeftRooms[randomIndex], transform.position, LeftRooms[randomIndex].transform.rotation);
                    Debug.Log("Left Room Spawned");
                    break;
                default:
                    Debug.LogError("Connector type not assigned");
                    break;
            }

            RoomSpawned = true;
            Destroy(gameObject); // Destroy the node after spawning the room
        }
    }

    private void GetRoomCount()
    {
        GameObject LevelManagerObject = GameObject.Find("LevelManager");
        RoomCounter = LevelManagerObject.GetComponent<LevelManager>();
        if (RoomCounter == null)
        {
            Debug.LogError("Level Manager not found");
        }
    }
}


