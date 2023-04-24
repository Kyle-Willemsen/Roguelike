using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject upgradeHUD;
    public GameObject shopIndicator;
    [SerializeField] SingleValuesSO runeMaxHealth;
    PlayerStats pStats;
    GunSystem gunSystem;
    [SerializeField] SingleValuesSO currency;
    [SerializeField] PlayerStatsSO pStatsSO;
    public float costOfMaxHealth;
    public float costOfSmallPotion;

    private void Start()
    {
        pStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        gunSystem = GameObject.Find("Player").GetComponent<GunSystem>();
    }

    private void UpgradeTime()
    {
        upgradeHUD.SetActive(true);
    }
    public void UpgradeMaxHealth()
    {
        if (currency.Value >= costOfMaxHealth)
        {
            currency.Value -= costOfMaxHealth;
            pStats.UpgradeMaxHealth(runeMaxHealth.Value);
        }
    }

    public void PurchaseSmallPotion()
    {
        if (currency.Value >= costOfSmallPotion)
        {
            currency.Value -= costOfSmallPotion;
            pStatsSO.PotionCounter++;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            shopIndicator.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                gunSystem.canShoot = false;
                UpgradeTime();
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        shopIndicator.SetActive(false);
        upgradeHUD.SetActive(false);
        gunSystem.canShoot = true;
    }
}
