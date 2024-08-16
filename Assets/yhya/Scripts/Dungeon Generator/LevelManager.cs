using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int RoomCount; //amount rooms to spawn each level
    [SerializeField] private int MaxRooms;
    [SerializeField] private int MinRooms;

    void Start()
    {
        SetRoomCount();
    }

    private void SetRoomCount()
    {
        RoomCount = Random.Range(MinRooms, MaxRooms);
        Debug.Log("spawning " + RoomCount + " rooms");
    }
}
