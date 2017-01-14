using System.Collections;
using UnityEngine;

public class CheesePickup : MonoBehaviour
{
    private TimerClass cheeseTimer;
    private PlayerController playerController;
    private Renderer cheeseRenderer;

    [Header("Cheese Pickup Attributes")]
    public float staminaGain;

    public float minTimeToSpoil;
    public float maxTimeToSpoil;

    public Color spoiledColor;

    public bool hasSpoiled;

    void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        cheeseTimer = new TimerClass();

        cheeseRenderer = GetComponent<Renderer>();

        FindSpoilTime();
    }

    void Update()
    {
        CheckSpoilTimer();
    }

    void FindSpoilTime()
    {
        float randSpoilTime = Random.Range(minTimeToSpoil, maxTimeToSpoil);

        cheeseTimer.ResetTimer(randSpoilTime);
    }

    void CheckSpoilTimer()
    {
        if (cheeseTimer.TimerIsDone() && !hasSpoiled)
        {
            hasSpoiled = true;
            cheeseRenderer.material.color = spoiledColor;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!hasSpoiled)
            {
                GivePlayerStamina();
                Destroy(gameObject);
            }
            else
            {
                RemovePlayerStamina();
                Destroy(gameObject);
            }
        }
    }

    void GivePlayerStamina()
    {
        playerController.currentStamina += staminaGain;
    }

    void RemovePlayerStamina()
    {
        playerController.currentStamina -= staminaGain;
    }
}
