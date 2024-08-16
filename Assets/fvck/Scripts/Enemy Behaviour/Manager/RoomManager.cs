using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> rooms = new List<GameObject>();

    [SerializeField]
    private bool swapRooms = false;

    [SerializeField]
    private float swapSpeed = 1f;

    private bool isSwapping = false;

    void Start()
    {
        GameObject[] roomObjects = GameObject.FindGameObjectsWithTag("Room");
        foreach (GameObject room in roomObjects)
        {
            rooms.Add(room);
        }
    }

    void Update()
    {
        if (swapRooms && !isSwapping)
        {
            StartCoroutine(SwapAdjacentRooms());
        }
    }

    public void AddRoom(GameObject room)
    {
        if (room.CompareTag("Room") && !rooms.Contains(room))
        {
            rooms.Add(room);
        }
    }

    public void RemoveRoom(GameObject room)
    {
        if (rooms.Contains(room))
        {
            rooms.Remove(room);
        }
    }

    public List<GameObject> GetRooms()
    {
        return rooms;
    }

    private IEnumerator SwapAdjacentRooms()
    {
        isSwapping = true;

        for (int i = 1; i < rooms.Count - 1; i += 2)
        {
            Vector3 oddPosition = rooms[i].transform.position;
            Vector3 evenPosition = rooms[i + 1].transform.position;
            float elapsedTime = 0f;

            while (elapsedTime < 1f)
            {
                rooms[i].transform.position = Vector3.Lerp(oddPosition, evenPosition, elapsedTime);
                rooms[i + 1].transform.position = Vector3.Lerp(evenPosition, oddPosition, elapsedTime);
                elapsedTime += Time.deltaTime * swapSpeed;
                yield return null;
            }

            rooms[i].transform.position = evenPosition;
            rooms[i + 1].transform.position = oddPosition;
        }

        isSwapping = false;
        swapRooms = false;
    }
}