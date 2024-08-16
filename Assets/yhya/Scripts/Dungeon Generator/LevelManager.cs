using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public int RoomCount; // amount of rooms to spawn each level
    [SerializeField] private int MaxRooms;
    [SerializeField] private int MinRooms;
    private int roomsSpawned = 0;
    
    private HashSet<Vector2Int> occupiedPositions = new HashSet<Vector2Int>();
    public float gridSize = 10f; // Adjust this based on your room size

    private Queue<GenerateRoom> spawnQueue = new Queue<GenerateRoom>();
    private bool isProcessingQueue = false;

    void Start()
    {
        SetRoomCount();
    }

    private void SetRoomCount()
    {
        RoomCount = Random.Range(MinRooms, MaxRooms);
        Debug.Log("Planning to spawn " + RoomCount + " rooms");
    }

    public void QueueRoomSpawn(GenerateRoom node)
    {
        spawnQueue.Enqueue(node);
        if (!isProcessingQueue)
        {
            StartCoroutine(ProcessSpawnQueue());
        }
    }

    private IEnumerator ProcessSpawnQueue()
    {
        isProcessingQueue = true;
        while (spawnQueue.Count > 0 && RoomCount > 0)
        {
            GenerateRoom node = spawnQueue.Dequeue();
            if (CanSpawnRoom(node.transform.position))
            {
                yield return StartCoroutine(node.SpawnRoomCoroutine());
            }
            else
            {
                Destroy(node.gameObject);
            }
            yield return new WaitForSeconds(0.5f); // Delay between room spawns
        }
        isProcessingQueue = false;
    }

    public bool CanSpawnRoom(Vector2 position)
    {
        if (roomsSpawned >= RoomCount) return false;

        Vector2Int gridPosition = WorldToGrid(position);
        return !occupiedPositions.Contains(gridPosition);
    }

    public void RoomSpawned(Vector2 position)
    {
        Vector2Int gridPosition = WorldToGrid(position);
        occupiedPositions.Add(gridPosition);
        roomsSpawned++;
        RoomCount--;
        Debug.Log($"Room spawned at {gridPosition}. {RoomCount} rooms left to spawn.");
    }

    private Vector2Int WorldToGrid(Vector2 worldPosition)
    {
        return new Vector2Int(
            Mathf.RoundToInt(worldPosition.x / gridSize),
            Mathf.RoundToInt(worldPosition.y / gridSize)
        );
    }
}