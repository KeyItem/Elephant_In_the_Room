using System.Collections;
using UnityEngine;

public class SpawnNextRoom : MonoBehaviour 
{
    public GameObject anchorPoint;

    private MapController mapController;

	void Start () 
    {
        mapController = GameObject.FindGameObjectWithTag("MapController").GetComponent<MapController>();	
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
        }
    }
}
