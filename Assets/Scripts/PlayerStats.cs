using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    GameManager manager;
    HealthBar healthbar;
    [SerializeField] SingleValuesSO runeMaxHealth;
    [SerializeField] PlayerStatsSO pStatsSo;

   // public bool maxHealthSOActive;
    public float currencyLoot;


    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        healthbar = GameObject.Find("HealthBar").GetComponent<HealthBar>();

        //potionValue = pStatsSo.PotionValue;

        healthbar.SetMaxHealth(pStatsSo.PlayerMaxHealth);
        pStatsSo.PlayerHealth = pStatsSo.PlayerMaxHealth;
    }

    private void Update()
    {
        if (pStatsSo.PlayerHealth <= 0)
        {
            Destroy(gameObject);
        }
        
        if (pStatsSo.PlayerHealth > pStatsSo.PlayerMaxHealth)
        {
            pStatsSo.PlayerHealth = 100f;
        }

       // if (maxHealthSOActive)
       // {
       //     UpgradeMaxHealth();
       // }

        if (pStatsSo.PotionCounter > 0 && Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Use");
            IncreaseHealth(pStatsSo.PotionValue);
            pStatsSo.PotionCounter--;
        }


    }
    public void TakeDamage(float damage)
    {
        pStatsSo.PlayerHealth -= damage;
        healthbar.SetHealth(pStatsSo.PlayerHealth);
    }

    public void UpgradeMaxHealth(float value)
    {


        pStatsSo.PlayerMaxHealth += value;
        healthbar.SetMaxHealth(pStatsSo.PlayerMaxHealth);
        healthbar.SetHealth(pStatsSo.PlayerHealth);
        //maxHealthSOActive = false;
    }

    public void IncreaseHealth(float additionalHealth)
    {
        pStatsSo.PlayerHealth += additionalHealth;
        healthbar.SetHealth(pStatsSo.PlayerHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HPSmall")
        {
            Debug.Log("HP");
            pStatsSo.PotionCounter++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Currency")
        {
            manager.totalCurrency.Value += currencyLoot;
            Destroy(other.gameObject);
        }
    }
}
