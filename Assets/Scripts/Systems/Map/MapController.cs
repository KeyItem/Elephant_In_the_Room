using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [Header("Generation Attributes")]
    public List<GameObject> housePrefabList;

    private GameObject roomHolder;

    private GameObject Player;

    public Transform teleportPoint;

    public GameObject entrancePrefab;
    public GameObject exitPrefab;

    public int numberOfRoomsToSpawn;

    private Transform startPointAnchor;
    private Transform exitPointAnchor;

    public int cheeseCount = 0;
    private int maxCheese;
    public bool canGoForward = false;

    [Header("Pickup Attributes")]
    public GameObject cheesePickup;

    private void Start()
    {
        roomHolder = GameObject.FindGameObjectWithTag("RoomHolder");

        Player = GameObject.FindGameObjectWithTag("Player");

        GenerateFirstRoom();
    }

    void Update()
    {
        ManageCheese();
    }

    void ManageCheese()
    {
        if (cheeseCount >= maxCheese)
        {
            canGoForward = true;
        }
    }

    void GenerateFirstRoom()
    {
        GameObject startPoint = GameObject.FindGameObjectWithTag("MouseholeStart");

        GameObject newRoom = Instantiate(housePrefabList[0], startPoint.transform.position, startPoint.transform.rotation, roomHolder.transform);

        GenerateExit(newRoom);
    }

    public void GenerateRoom(GameObject newRoom)
    {
        Transform startPoint = newRoom.transform.Find("StartPoint");

        GameObject newRoom1 = Instantiate(housePrefabList[0], startPoint.transform.position, startPoint.transform.rotation, roomHolder.transform);

        GenerateExit(newRoom1);
    }

    public void GenerateEntrance(Vector3 spawnVec)
    {
        GameObject newEntrance = Instantiate(entrancePrefab, spawnVec, Quaternion.identity);

        Transform spawnPoint = newEntrance.transform.Find("TeleportPoint");

        Player.transform.position = spawnPoint.position;
        Player.transform.rotation = spawnPoint.rotation;

        GenerateRoom(newEntrance);
    }

    void GenerateExit(GameObject newRoom)
    {
        Transform exitAnchor = newRoom.transform.GetChild(0).transform.Find("ExitAnchorHolder");

        Transform[] exitAnchorArray = exitAnchor.GetComponentsInChildren<Transform>();

        int randValue = Random.Range(1, exitAnchorArray.Length);

        GameObject newExit = Instantiate(exitPrefab, exitAnchorArray[randValue].position, exitAnchorArray[randValue].rotation, exitAnchorArray[randValue].transform);

        Vector3 entranceVec = newExit.transform.position;
    }

    public void GenerateCheese(GameObject newRoom)
    {
        float cheeseSpawnChance = newRoom.GetComponent<RoomDynamics>().pickupSpawnChance;

        Transform cheeseAnchor = newRoom.transform.GetChild(0).transform.Find("PickupAnchorHolder");

        Transform[] cheeseAnchorArray = cheeseAnchor.GetComponentsInChildren<Transform>();

        for (int i = 1; i < cheeseAnchorArray.Length; i++)
        {
            float ranValue = Random.value;

            if (ranValue < cheeseSpawnChance)
            {
                GameObject newCheese = Instantiate(cheesePickup, cheeseAnchorArray[i].position, cheeseAnchorArray[i].transform.rotation, cheeseAnchorArray[i]);
                newCheese.transform.localPosition = Vector3.zero;
            }

            maxCheese = cheeseAnchorArray.Length;
        }
    }
}
