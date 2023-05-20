using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    private float currentVelocity = 0f;
    public TextMeshProUGUI healthText;
    [SerializeField] PlayerStatsSO pStatsSO;

    public void SetMaxHealth(float health)
    {
        healthBar.maxValue = health;
        healthBar.value = health;
        healthText.text = health + "/" + pStatsSO.PlayerMaxHealth;
    }

    public void SetHealth(float health)
    {
        //float currentHealth =  Mathf.SmoothDamp(healthBar.value, health, ref currentVelocity, 100 * Time.deltaTime);
        healthBar.value = health;
        healthText.text = pStatsSO.PlayerHealth + "/" + pStatsSO.PlayerMaxHealth;
    }
}
