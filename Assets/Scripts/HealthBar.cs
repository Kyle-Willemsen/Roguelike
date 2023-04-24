using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;

    public void SetMaxHealth(float health)
    {
        healthBar.value = health;
        healthBar.maxValue = health;
    }

    public void SetHealth(float health)
    {
        healthBar.value = health;
    }
}
