using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
[RequireComponent(typeof(HealthManager))]
[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    
    [Header("Player Movement Attributes")]
    public float moveSpeed;
    public float turnSpeed;
    public float maxSpeed;
    public float sprintSpeed;

    [Header("Player Stamina Attributes")]
    public float currentStamina;
    private float maxStamina;
    public float sprintCost;

    [Header("Player Debug")]
    public float currentSpeed;

	void Start ()
    {
        playerRB = GetComponent<Rigidbody>  ();       
	}
	
	void Update ()
    {
        GetSpeed();
	}

    void GetSpeed()
    {
        currentSpeed = playerRB.velocity.magnitude;
    }

    public void Move(float zAxis)
    {
        if (currentSpeed < maxSpeed)
        {
            playerRB.AddForce(transform.forward * zAxis * moveSpeed);
        }
    }

    public void Turn(float xAxis)
    {
        transform.Rotate(Vector3.up * xAxis * moveSpeed * Time.deltaTime);
    }
}
