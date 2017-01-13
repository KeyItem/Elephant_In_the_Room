﻿using System.Collections;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [Header("Health Attributes")]
    public float currentHealth;
    private float maxHealth;

    public float healthRegenRate;

    public bool canRegenerateHealth;
    public bool isDead;
	
	void Update ()
    {
        ManageHealth();
	}

    void ManageHealth()
    {
        if (currentHealth <= 0)
        {
            isDead = true;
            Debug.Log("Player has died");
        }

        if (canRegenerateHealth)
        {
            if (currentHealth < maxHealth)
            {
                currentHealth += healthRegenRate * Time.deltaTime;
            }
        }
    }
}
