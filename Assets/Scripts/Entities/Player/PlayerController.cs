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
    private float baseSpeed;
    public float turnSpeed;
    public float maxSpeed;
    public float sprintSpeed;

    public bool isSprinting;

    [Header("Player Stamina Attributes")]
    public float currentStamina;
    public float maxStamina;
    public float staminaRegenerationRate;
    public float sprintCost;

    [Header("Player Jump Attributes")]
    public float jumpHeight;
    private int jumpCount;
    public int jumpTimes;
    public float jumpRayLength;
    public bool isGrounded;
    public LayerMask GroundMask;

    [Header("Player Debug")]
    public float currentSpeed;

	void Start ()
    {
        playerRB = GetComponent<Rigidbody>();

        baseSpeed = moveSpeed;

        maxStamina = currentStamina;   
	}
	
	void Update ()
    {
        GetSpeed();

        ManageStamina();

        GroundCheck();
	}

    void GroundCheck()
    {
        if (Physics.Raycast(transform.position, Vector3.down, jumpRayLength, GroundMask))
        {
            isGrounded = true;
            jumpCount = 0;
        }
        else
        {
            isGrounded = false;
        }
    }

    void ManageStamina()
    {
        if (currentStamina < maxStamina)
        {
            currentStamina += staminaRegenerationRate * Time.deltaTime;
        }

        if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }
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
        transform.Rotate(Vector3.up * xAxis * turnSpeed * Time.deltaTime);
    }

    public void Sprint()
    {
        if (currentStamina > sprintCost)
        {
            currentStamina -= sprintCost * Time.deltaTime;
            moveSpeed = sprintSpeed;
            isSprinting = true;
        }
    }

    public void StopSprint()
    {
        moveSpeed = baseSpeed;
        isSprinting = false;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerRB.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
            jumpCount++;
            
            if (jumpCount >= jumpTimes)
            {
                isGrounded = false;
            }
        }
    }
}
