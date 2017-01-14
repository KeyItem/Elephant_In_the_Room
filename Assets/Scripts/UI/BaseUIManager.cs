using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BaseUIManager : MonoBehaviour
{
    private PlayerController playerController;

    [Header("Stamina Bar Attributes")]
    public Image staminaBarImage;

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    void Update()
    {
        ManageStaminaBar();
    }

    void ManageStaminaBar()
    {
        staminaBarImage.fillAmount = playerController.currentStamina / playerController.maxStamina;
    }
}
