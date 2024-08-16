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
    [SerializeField] private float spawnDelay = 3.0f; // Delay before spawning the room in seconds

    private bool RoomSpawned = false;
    private LevelManager RoomCounter;
    private Coroutine spawnCoroutine; // Reference to the running coroutine
    private bool isTouchingRoom = false; // Flag to check if touching a room

    void Start()
    {
        GetRoomCount();
        if (!RoomCounter.MaxRoomsReached() && !RoomCounter.IsPositionOccupied((Vector2)transform.position))
        {
            spawnCoroutine = StartCoroutine(SpawnRoomAfterDelay());
        }
        else
        {
            Debug.Log("Max rooms reached or room already exists at this position. Node destroyed.");
            Destroy(gameObject);
        }
    }

    private IEnumerator SpawnRoomAfterDelay()
    {
        Debug.Log("Waiting for spawn delay...");
        
        float elapsed = 0f;
        while (elapsed < spawnDelay)
        {
            if (isTouchingRoom)
            {
                Debug.Log("Touch detected, aborting room spawn.");
                yield break; // Exit the coroutine if a room is detected
            }
            elapsed += Time.deltaTime; // Increment elapsed time
            yield return null; // Wait until the next frame
        }

        // Call the SpawnRoom method
        SpawnRoom();
    }

    private void SpawnRoom()
    {
        if (!RoomSpawned && !RoomCounter.MaxRoomsReached())
        {
            Debug.Log("Attempting room spawn");
            int randomIndex;
            GameObject spawnedRoom = null;

            switch (ConnectorType)
            {
                case 1:
                    randomIndex = Random.Range(0, BottomRooms.Length);
                    spawnedRoom = Instantiate(BottomRooms[randomIndex], transform.position, BottomRooms[randomIndex].transform.rotation);
                    break;
                case 2:
                    randomIndex = Random.Range(0, TopRooms.Length);
                    spawnedRoom = Instantiate(TopRooms[randomIndex], transform.position, TopRooms[randomIndex].transform.rotation);
                    break;
                case 3:
                    randomIndex = Random.Range(0, RightRooms.Length);
                    spawnedRoom = Instantiate(RightRooms[randomIndex], transform.position, RightRooms[randomIndex].transform.rotation);
                    break;
                case 4:
                    randomIndex = Random.Range(0, LeftRooms.Length);
                    spawnedRoom = Instantiate(LeftRooms[randomIndex], transform.position, LeftRooms[randomIndex].transform.rotation);
                    break;
                default:
                    Debug.LogError("Connector type not assigned");
                    break;
            }

            if (spawnedRoom != null)
            {
                Debug.Log("Room Spawned");
                RoomSpawned = true;
                RoomCounter.RegisterRoomPosition((Vector2)transform.position);
            }

            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Room not spawned: Already spawned or max rooms reached.");
            Destroy(gameObject);
        }
    }

    private void GetRoomCount()
    {
        GameObject LevelManagerObject = GameObject.Find("LevelManager");
        RoomCounter = LevelManagerObject.GetComponent<LevelManager>();
        if (RoomCounter == null)
        {
            Debug.LogError("LevelManager not found");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Room"))
        {
            isTouchingRoom = true;
            Debug.Log("Room Detected");
            
            if (spawnCoroutine != null)
            {
                StopCoroutine(spawnCoroutine);
                spawnCoroutine = null;
            }
            
            Destroy(gameObject);
            Debug.Log("Node Destroyed");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Room"))
        {
            isTouchingRoom = false;
        }
    }
}