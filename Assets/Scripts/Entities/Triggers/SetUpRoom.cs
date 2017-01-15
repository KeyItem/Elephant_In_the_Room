using System.Collections;
using UnityEngine;

public class SetUpRoom : MonoBehaviour 
{
    private MapController mapController;

    public GameObject currentRoom;

    private void Start()
    {
        mapController = GameObject.FindGameObjectWithTag("MapController").GetComponent<MapController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mapController.GenerateCheese(currentRoom);
        }
    }
}
