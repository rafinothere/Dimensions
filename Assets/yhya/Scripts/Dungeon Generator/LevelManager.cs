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

    private List<GenerateRoom> availableNodes = new List<GenerateRoom>();
    private bool isProcessingNodes = false;

    void Start()
    {
        SetRoomCount();
    }

    private void SetRoomCount()
    {
        RoomCount = Random.Range(MinRooms, MaxRooms);
        Debug.Log("Planning to spawn " + RoomCount + " rooms");
    }

    public void RegisterNode(GenerateRoom node)
    {
        if (!availableNodes.Contains(node))
        {
            availableNodes.Add(node);
            if (!isProcessingNodes)
            {
                StartCoroutine(ProcessNodes());
            }
        }
    }

    private IEnumerator ProcessNodes()
    {
        isProcessingNodes = true;
        while (roomsSpawned < RoomCount && availableNodes.Count > 0)
        {
            int randomIndex = Random.Range(0, availableNodes.Count);
            GenerateRoom node = availableNodes[randomIndex];

            if (CanSpawnRoom(node.transform.position))
            {
                yield return StartCoroutine(node.SpawnRoomCoroutine());
                availableNodes.RemoveAt(randomIndex);
            }
            else
            {
                availableNodes.RemoveAt(randomIndex);
            }
            yield return new WaitForSeconds(0.5f); // Delay between room spawns
        }
        isProcessingNodes = false;

        if (roomsSpawned < RoomCount)
        {
            Debug.LogWarning($"Not enough valid positions to spawn all rooms. Spawned {roomsSpawned} out of {RoomCount}");
        }
    }

    public bool CanSpawnRoom(Vector2 position)
    {
        Vector2Int gridPosition = WorldToGrid(position);
        return !occupiedPositions.Contains(gridPosition);
    }

    public void RoomSpawned(Vector2 position)
    {
        Vector2Int gridPosition = WorldToGrid(position);
        occupiedPositions.Add(gridPosition);
        roomsSpawned++;
        Debug.Log($"Room spawned at {gridPosition}. {roomsSpawned} rooms spawned out of {RoomCount}");
    }

    private Vector2Int WorldToGrid(Vector2 worldPosition)
    {
        return new Vector2Int(
            Mathf.RoundToInt(worldPosition.x / gridSize),
            Mathf.RoundToInt(worldPosition.y / gridSize)
        );
    }
}