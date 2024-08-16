using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int RoomCount; // amount of rooms to spawn each level
    [SerializeField] private int MaxRooms;
    [SerializeField] private int MinRooms;
    public List<Vector2> roomPositions = new List<Vector2>(); // Track all room positions

    void Start()
    {
        SetRoomCount();
    }

    private void SetRoomCount()
    {
        RoomCount = Random.Range(MinRooms, MaxRooms);
        Debug.Log("Spawning " + RoomCount + " rooms");
    }

    public bool IsPositionOccupied(Vector2 position)
    {
        return roomPositions.Contains(position);
    }

    public void RegisterRoomPosition(Vector2 position)
    {
        roomPositions.Add(position);
    }

    public bool MaxRoomsReached()
    {
        return roomPositions.Count >= RoomCount;
    }
}