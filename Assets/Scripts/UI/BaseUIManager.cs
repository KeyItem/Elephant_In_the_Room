using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BaseUIManager : MonoBehaviour
{
    private HealthManager healthManager;
    private PlayerController playerController;

    [Header("Health Bar Attributes")]
    public Image healthBarImage;

    [Header("Stamina Bar Attributes")]
    public Image staminaBarImage;

    void Start()
    {
        healthManager = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthManager>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        ManageHealthBar();
        ManageStaminaBar();
    }

    void ManageHealthBar()
    {
        healthBarImage.fillAmount = healthManager.currentHealth / healthManager.maxHealth;
    }

    void ManageStaminaBar()
    {
        staminaBarImage.fillAmount = playerController.currentStamina / playerController.maxStamina;
    }
}
