using System.Collections;
using UnityEngine;

[System.Serializable]
public class RoomDynamics : MonoBehaviour 
{ 
    [Header("PickUp Attributes")]
    public float pickupSpawnChance;

    [Header("Enemy Attributes")]
    public float enemySpawnChance;

    public bool elephantEnemy;
    public bool mouseTrapEnemy;
}
