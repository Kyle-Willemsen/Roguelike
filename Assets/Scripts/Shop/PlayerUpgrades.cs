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

    public float maxUpgrades;
    private int random;
    [SerializeField]
    List<GameObject> randomUpgrades = new List<GameObject>();
    public float indicatorRadius = 8;
    [SerializeField] LayerMask layerMask;
        
    private void Start()
    {
        pStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        gunSystem = GameObject.Find("Player").GetComponent<GunSystem>();
       //playerUpgradeHUD = GameObject.Find("PlayerUpgrades");
       //shopIndicator = GameObject.Find("OpenShop");

        for (int i = 0; i < 3; i++)
        {
            random = Random.Range(0, randomUpgrades.Count);

            randomUpgrades[random].SetActive(true);
            randomUpgrades.RemoveAt(random);

        }
    }


    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, indicatorRadius, layerMask);
        foreach (Collider collider in colliders)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                shopIndicator.SetActive(false);
                gunSystem.canShoot = false;
                OpenShop();

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    playerUpgradeHUD.SetActive(false);
                }
            }

        }
    }

   // private void UpgradeTime()
   // {
   //     playerUpgradeHUD.SetActive(true);
   // }
    public void UpgradeMaxHealth()
    {
        if (currency.Value >= costOfMaxHealth)
        {
            currency.Value -= costOfMaxHealth;
            pStats.UpgradeMaxHealth(runeMaxHealth.Value);
            GameObject.Find("UpgradeMaxHealth").SetActive(false);
        }
    }

    public void PurchaseSmallPotion()
    {
        if (currency.Value >= costOfSmallPotion)
        {
            currency.Value -= costOfSmallPotion;
            pStatsSO.PotionCounter++;
            GameObject.Find("Small Potions").SetActive(false);
        }
    }

    public void DashCooldownPurchase()
    {
        if (currency.Value >= dashCooldownCost)
        {
            currency.Value -= dashCooldownCost;
            pStatsSO.DashCooldwon += pStatsSO.DashCooldwon * -0.2f;
            GameObject.Find("DashCooldown").SetActive(false);
        }
    }

    public void PurchaseTeleportDash()
    {
        if (currency.Value >= teleportDashCost)
        {
            currency.Value -= teleportDashCost;
            pStatsSO.TeleportDash = true;
            GameObject.Find("Teleport Dash").SetActive(false);
        }
    }

    public void PurchaseBombDash()
    {
        if (currency.Value >= bombDashCost)
        {
            currency.Value -= bombDashCost;
            pStatsSO.DashBomb = true;
            GameObject.Find("BombDash").SetActive(false);
        }
    }

    public void PurchaseInvisibiltyDash()
    {
        if (currency.Value >= invisibiltyDashCost)
        {
            currency.Value -= invisibiltyDashCost;
            pStatsSO.InvisibleAbility = true;
            GameObject.Find("Invisibility Dash").SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            shopIndicator.SetActive(true);
        }
    }

    private void OpenShop()
    {
        playerUpgradeHUD.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        shopIndicator.SetActive(false);
        playerUpgradeHUD.SetActive(false);
        gunSystem.canShoot = true;
    }
}
