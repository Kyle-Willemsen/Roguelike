using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    private float currentVelocity = 0f;


    public void SetMaxHealth(float health)
    {
        healthBar.value = health;
        healthBar.maxValue = health;
    }

    public void SetHealth(float health)
    {
        //float currentHealth =  Mathf.SmoothDamp(healthBar.value, health, ref currentVelocity, 100 * Time.deltaTime);
        healthBar.value = health;
    }
}
