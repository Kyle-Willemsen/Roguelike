using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    GameManager manager;
    HealthBar healthbar;
    [SerializeField] SingleValuesSO runeMaxHealth;
    [SerializeField] PlayerStatsSO pStatsSo;
    [SerializeField] WeaponSO weaponStatsSO;
    PlayerMovement playerMovement;
    GunSystem gunSystem;
    Animator anim;

    // public bool maxHealthSOActive;
    public float soulsValue;
    public float fragmentsValue;

    public bool invincible = false;
    public float invincibilityTime;

    public float healTime;


    private void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        gunSystem = GetComponent<GunSystem>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        healthbar = GameObject.Find("HealthBar").GetComponent<HealthBar>();

        //potionValue = pStatsSo.PotionValue;

        healthbar.SetMaxHealth(pStatsSo.PlayerMaxHealth);
        pStatsSo.PlayerHealth = pStatsSo.PlayerHealth;
        healthbar.SetMaxMana(weaponStatsSO.MaxMana);
        weaponStatsSO.CurrentMana = weaponStatsSO.CurrentMana;
    }

    private void Update()
    {
        if (pStatsSo.PlayerHealth <= 0)
        {
            pStatsSo.PlayerHealth = 0f;
            manager.DeathScreen();
            //Destroy(gameObject);
        }
        
        if (pStatsSo.PlayerHealth > pStatsSo.PlayerMaxHealth)
        {
            pStatsSo.PlayerHealth = pStatsSo.PlayerMaxHealth;
            healthbar.healthText.text = pStatsSo.PlayerHealth + "/" + pStatsSo.PlayerMaxHealth;
        }

       // if (maxHealthSOActive)
       // {
       //     UpgradeMaxHealth();
       // }

        if (pStatsSo.PotionCounter > 0 && Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine("Healing");
            pStatsSo.PotionCounter--;
        }


    }
    public void TakeDamage(float damage)
    {
        if (!invincible)
        {
            pStatsSo.PlayerHealth -= damage;
            healthbar.SetHealth(pStatsSo.PlayerHealth);
            Invincible();
        }

    }

    public void Invincible()
    {
        invincible = true;
        Invoke("InvincibilityTimer", invincibilityTime);
    }

    public void InvincibilityTimer()
    {
        invincible = false;
    }
    public void UpgradeMaxHealth(float value)
    {
        pStatsSo.PlayerMaxHealth += value;
        healthbar.SetMaxHealth(pStatsSo.PlayerMaxHealth);
        healthbar.SetHealth(pStatsSo.PlayerHealth);
        //maxHealthSOActive = false;
    }

    public IEnumerator Healing()
    {
        float startTime = Time.time;

        while (Time.time < startTime + healTime)
        {
            anim.SetBool("isHealing", true);
            playerMovement.canMove = false;
            playerMovement.canDash = false;
            gunSystem.canMelee = false;
            yield return null;
        }
        yield return new WaitForSeconds(healTime);
        HealFinish(pStatsSo.PotionValue);
    }


    public void HealFinish(float additionalHealth)
    {
        anim.SetBool("isHealing", false);
        playerMovement.canMove = true;
        playerMovement.canDash = true;
        gunSystem.canMelee = true;

        pStatsSo.PlayerHealth += additionalHealth;
        healthbar.SetHealth(pStatsSo.PlayerHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HPSmall")
        {
            pStatsSo.PotionCounter++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Souls")
        {
            manager.soulsCount.Value += soulsValue;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Fragments")
        {
            manager.fragmentsCount.Value += fragmentsValue;
            Destroy(other.gameObject);
        }
    }
}
