using System.Collections;
using UnityEngine;

public class CheesePickup : MonoBehaviour
{
    private TimerClass cheeseTimer;

    private AudioSource sfxAudio;

    private PlayerController playerController;
    private MapController mapController;

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

        mapController = GameObject.FindGameObjectWithTag("MapController").GetComponent<MapController>();

        cheeseTimer = new TimerClass();

        cheeseRenderer = GetComponent<Renderer>();

        sfxAudio = GetComponent<AudioSource>();

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
                mapController.cheeseCount++;
                sfxAudio.Play();
                Destroy(gameObject);
            }
            else
            {
                RemovePlayerStamina();
                mapController.cheeseCount++;
                sfxAudio.Play();
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
