using System.Collections;
using UnityEngine;

public class SpawnNextRoom : MonoBehaviour 
{
    private GameObject player;

    public float nextRoomDistance;

    private MapController mapController;

	void Start () 
    {
        mapController = GameObject.FindGameObjectWithTag("MapController").GetComponent<MapController>();

        player = GameObject.FindGameObjectWithTag("Player");
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 exitVec = transform.position + new Vector3(0, 0, nextRoomDistance);

            mapController.GenerateEntrance(exitVec);
        }
    }
}
