using UnityEngine;
using System.Collections;

public class GenerateRoom : MonoBehaviour
{
    [SerializeField] private GameObject[] TopRooms;
    [SerializeField] private GameObject[] BottomRooms;
    [SerializeField] private GameObject[] LeftRooms;
    [SerializeField] private GameObject[] RightRooms;
    [SerializeField] private int ConnectorType; // number representing where the spawn node is

    private LevelManager RoomCounter;

    void Start()
    {
        GetRoomCount();
        StartCoroutine(CheckAndRegister());
    }

    private IEnumerator CheckAndRegister()
    {
        yield return new WaitForSeconds(0.1f); // Short delay to ensure all colliders are set up

        if (!Physics2D.OverlapCircle(transform.position, 0.1f, LayerMask.GetMask("Room")))
        {
            RoomCounter.RegisterNode(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator SpawnRoomCoroutine()
    {
        yield return new WaitForSeconds(0.1f); // Short delay
        SpawnRoom();
    }

    private void SpawnRoom()
    {
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
                Debug.LogError("Invalid ConnectorType");
                break;
        }

        if (spawnedRoom != null)
        {
            Debug.Log("Room spawned successfully");
            RoomCounter.RoomSpawned(transform.position);
        }
        else
        {
            Debug.LogError("Failed to spawn room");
        }

        Destroy(gameObject);
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
}