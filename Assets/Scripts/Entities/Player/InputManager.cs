using System.Collections;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerController playerController;

    [Header("Player Controls")]
    public KeyCode Jump;
    public KeyCode Sprint;
    public KeyCode RELOAD_DEV;

    private float xAxis;
    private float zAxis;

    [Header("Input Attributes")]
    public bool canReceiveInput = false;

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

            if (Input.GetKeyDown(Jump))
            {
                playerController.Jump();
            }

            if (Input.GetKey(Sprint))
            {
                playerController.Sprint();
            }

            if (Input.GetKeyUp(Sprint))
            {
                playerController.StopSprint();
            }

            if (Input.GetKeyDown(RELOAD_DEV))
            {
                LevelManager.ReloadLevel();
            }
        }       
    }
}
