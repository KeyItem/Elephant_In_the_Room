using System.Collections;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [Header("Health Attributes")]
    public float currentHealth;
    public float maxHealth;

    public float healthReductionRate;

    public bool canReduceHealth;

    public bool isDead;
	
    void Start()
    {
        maxHealth = currentHealth;
    }

	void Update ()
    {
        ManageHealth();
	}

    void ManageHealth()
    {
        if (StateManager.state == "Playing")
        {
            if (currentHealth <= 0)
            {
                isDead = true;
                Debug.Log("Player has died");
            }

            if (canReduceHealth)
            {
                if (currentHealth > 0)
                {
                    currentHealth -= healthReductionRate * Time.deltaTime;
                }
            }

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }       
    }
}
