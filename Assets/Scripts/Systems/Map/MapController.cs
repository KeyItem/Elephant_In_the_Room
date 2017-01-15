using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [Header("Generation Attributes")]
    private GameObject roomHolder;

    public GameObject[] roomPrefabs;
    public GameObject exitPrefab;

    public GameObject currentRoom;
    public GameObject entranceAnchor;

    private Transform startingAnchor;

    void Start()
    {
        roomHolder = GameObject.FindGameObjectWithTag("RoomHolder");

        startingAnchor = GameObject.Find("StartingAnchor").transform;

        GenerateFirstRoom();
    }

    public void GenerateFirstRoom()
    {
        entranceAnchor = GameObject.Find("EntranceAnchor");
        GameObject newRoom = Instantiate(roomPrefabs[0], startingAnchor.transform.position, startingAnchor.transform.rotation, roomHolder.transform);
        currentRoom = newRoom;
        GenerateRoomExit(newRoom);
    }

    public void GenerateNextRoom(GameObject newRoom)
    {
       
    }

    public void GenerateRoomExit(GameObject newRoom)
    {
        Transform exitHolder = newRoom.transform.GetChild(0).FindChild("ExitAnchors");
        Transform[] exitArray = exitHolder.GetComponentsInChildren<Transform>();
        int randValue = Random.Range(0, exitArray.Length);
        GameObject newExit = Instantiate(exitPrefab, exitArray[randValue].transform.position, Quaternion.identity, exitArray[randValue]);
        newExit.transform.position = Vector3.zero;
    }

    public void GenerateObstacles(GameObject newRoom)
    {

    }

    public void GenerateCheese(GameObject newRoom)
    {

    }
}
