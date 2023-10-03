using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    private PlayerHealth playerHealth;

    void Start()
    {
        slider = GetComponent<Slider>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        setMaxHealth(playerHealth.maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        setHealth(playerHealth.currentHealth);
    }

    public void setHealth(float health)
    {
        slider.value = health;
    }

    public void setMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
}
