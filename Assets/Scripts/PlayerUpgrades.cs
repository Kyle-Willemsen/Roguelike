using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    PlayerStats pStats;
    GunSystem gunSystem;
    [SerializeField] SingleValuesSO runeMaxHealth;
    [SerializeField] SingleValuesSO currency;
    [SerializeField] PlayerStatsSO pStatsSO;


    public GameObject playerUpgradeHUD;
    public GameObject shopIndicator;

    [SerializeField] float costOfMaxHealth;
    [SerializeField] float costOfSmallPotion;
    [SerializeField] float dashCooldownCost;
    [SerializeField] float teleportDashCost;
    [SerializeField] float bombDashCost;
    [SerializeField] float invisibiltyDashCost;



    private void Start()
    {
        pStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        gunSystem = GameObject.Find("Player").GetComponent<GunSystem>();
    }

    private void UpgradeTime()
    {
        playerUpgradeHUD.SetActive(true);
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

    public void DashCooldownPurchase()
    {
        if (currency.Value >= dashCooldownCost)
        {
            currency.Value -= dashCooldownCost;
            pStatsSO.DashCooldwon += pStatsSO.DashCooldwon * -0.2f;
        }
    }

    public void PurchaseTeleportDash()
    {
        if (currency.Value >= teleportDashCost)
        {
            currency.Value -= teleportDashCost;
            pStatsSO.TeleportDash = true;
        }
    }

    public void PurchaseBombDash()
    {
        if (currency.Value >= bombDashCost)
        {
            currency.Value -= bombDashCost;
            pStatsSO.DashBomb = true;
        }
    }

    public void PurchaseInvisibiltyDash()
    {
        if (currency.Value >= invisibiltyDashCost)
        {
            currency.Value -= invisibiltyDashCost;
            pStatsSO.InvisibleAbility = true;
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
        playerUpgradeHUD.SetActive(false);
        gunSystem.canShoot = true;
    }
}
