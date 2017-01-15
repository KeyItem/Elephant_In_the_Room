using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BaseUIManager : MonoBehaviour
{
    private InputManager inputManager;
    private PlayerController playerController;
    private HealthManager playerHealth;

    [Header("Starting UI Attributes")]
    public GameObject startingUI;

    public bool startingUIisActive = true;

    [Header("Health Bar Attributes")]
    public Image healthBarImage;

    [Header("Stamina Bar Attributes")]
    public Image staminaBarImage;

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        inputManager = GameObject.FindGameObjectWithTag("Player").GetComponent<InputManager>();

        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthManager>();
    }

    void Update()
    {
        ManageHealthBar();

        ManageStaminaBar();

        ManageStartingUI();
    }

    void ManageStartingUI()
    {
        if (startingUIisActive)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                startingUI.SetActive(false);
                startingUIisActive = false;
                inputManager.canReceiveInput = true;
                healthBarImage.enabled = true; //show bars when started
                staminaBarImage.enabled = true;
                StateManager.StartGame();
            }
        }
    }

    void ManageHealthBar()
    {
        healthBarImage.fillAmount = playerHealth.currentHealth / playerHealth.maxHealth;
    }

    void ManageStaminaBar()
    {
        staminaBarImage.fillAmount = playerController.currentStamina / playerController.maxStamina;
    }
}
