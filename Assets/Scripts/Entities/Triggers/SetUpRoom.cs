using System.Collections;
using UnityEngine;

public class SetUpRoom : MonoBehaviour 
{
    private MapController mapController;

    public GameObject currentRoom;

    private int count;

    private void Start()
    {
        mapController = GameObject.FindGameObjectWithTag("MapController").GetComponent<MapController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (count == 0)
            {
                mapController.GenerateCheese(currentRoom);
                Debug.Log("Spawning Cheese Motherfucker");
                count++;
            }    
        }
    }
}
