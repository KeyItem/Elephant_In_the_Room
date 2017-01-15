using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [Header("Generation Attributes")]
    public List<GameObject> housePrefabList;

    private GameObject roomHolder;

    public GameObject exitPrefab;

    public int numberOfRoomsToSpawn;

    private Transform startPointAnchor;
    private Transform exitPointAnchor;

    [Header("Pickup Attributes")]
    public GameObject cheesePickup;

    private void Start()
    {
        roomHolder = GameObject.FindGameObjectWithTag("RoomHolder");

        SpawnFirstRoom();
    }

    void SpawnFirstRoom()
    {
        GameObject startPoint = GameObject.FindGameObjectWithTag("MouseholeStart");

        GameObject newRoom = Instantiate(housePrefabList[0], startPoint.transform.position, startPoint.transform.rotation, roomHolder.transform);

        SpawnExit(newRoom);
    }

    void SpawnRoom(GameObject newRoom)
    {

    }

    void SpawnExit(GameObject newRoom)
    {
        Transform exitAnchor = newRoom.transform.GetChild(0).transform.Find("ExitAnchorHolder");

        Transform[] exitAnchorArray = exitAnchor.GetComponentsInChildren<Transform>();

        int randValue = Random.Range(0, exitAnchorArray.Length);

        GameObject newExit = Instantiate(exitPrefab, exitAnchorArray[randValue].position, exitAnchorArray[randValue].rotation, exitAnchorArray[randValue].transform);
    }

    public void GenerateCheese(GameObject newRoom)
    {
        float cheeseSpawnChance = newRoom.GetComponent<RoomDynamics>().pickupSpawnChance;

        Transform cheeseAnchor = newRoom.transform.GetChild(0).transform.Find("PickupAnchorHolder");

        Transform[] cheeseAnchorArray = cheeseAnchor.GetComponentsInChildren<Transform>();

        for (int i = 0; i < cheeseAnchorArray.Length; i++)
        {
            float ranValue = Random.value;

            if (ranValue < cheeseSpawnChance)
            {
                GameObject newCheese = Instantiate(cheesePickup, cheeseAnchorArray[i].position, cheeseAnchorArray[i].rotation, cheeseAnchorArray[i]);
            }
        }
    }
}
