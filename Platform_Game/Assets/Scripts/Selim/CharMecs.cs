using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMecs : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public int damage;

    public HealthBar healthBar;
    

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            TakeDamage(damage);
        }
    }

    void TakeDamage (int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
