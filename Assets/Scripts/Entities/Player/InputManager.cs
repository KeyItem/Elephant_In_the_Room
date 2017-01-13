using System.Collections;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerController playerController;

    [Header("Player Controls")]
    public KeyCode Jump;
    public KeyCode Sprint;
    public KeyCode Interact;

    private float xAxis;
    private float zAxis;

    [Header("Input Attributes")]
    public bool canReceiveInput;

	void Start ()
    {
        playerController = GetComponent<PlayerController>();        
	}
	
	void Update ()
    {
        CheckForInput();
	}

    void CheckForInput()
    {
        if (canReceiveInput)
        {
            xAxis = Input.GetAxis("Horizontal");
            zAxis = Input.GetAxis("Vertical");

            if (xAxis != 0)
            {
                playerController.Turn(xAxis);
            }

            if (zAxis != 0)
            {
                playerController.Move(zAxis);
            }
        }       
    }
}
