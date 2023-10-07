using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public Slider manaBar;
    GunSystem gunSystem;
    //private float currentVelocity = 0f;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI manaText;
    [SerializeField] PlayerStatsSO pStatsSO;
    [SerializeField] WeaponSO weaponStatsSO;

    private void Start()
    {
        gunSystem = FindObjectOfType<GunSystem>();
    }
    public void SetMaxHealth(float health)
    {
        healthBar.maxValue = health;
        healthBar.value = pStatsSO.PlayerHealth;
        healthText.text = pStatsSO.PlayerHealth + "/" + pStatsSO.PlayerMaxHealth;
    }

    public void SetHealth(float health)
    {
        //float currentHealth =  Mathf.SmoothDamp(healthBar.value, health, ref currentVelocity, 100 * Time.deltaTime);
        healthBar.value = health;
        healthText.text = pStatsSO.PlayerHealth + "/" + pStatsSO.PlayerMaxHealth;
    }

    public void SetMaxMana(float mana)
    {
        manaBar.maxValue = mana;
        manaBar.value = gunSystem.barMana;
        manaText.text = gunSystem.barMana + "/" + weaponStatsSO.MaxMana;
    }

    public void SetMana(float mana)
    {
        //float currentHealth =  Mathf.SmoothDamp(healthBar.value, health, ref currentVelocity, 100 * Time.deltaTime);
        manaBar.value = mana;
        manaText.text = gunSystem.barMana + "/" + weaponStatsSO.MaxMana;
    }
}
