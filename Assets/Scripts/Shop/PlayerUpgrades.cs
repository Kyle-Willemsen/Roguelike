using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    [SerializeField] PlayerStats pStats;
    GunSystem gunSystem;
    [SerializeField] SingleValuesSO runeMaxHealth;
    [SerializeField] SingleValuesSO fragments;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            shopIndicator.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        shopIndicator.SetActive(false);
        playerUpgradeHUD.SetActive(false);
        gunSystem.canShoot = true;
    }

    private void OpenShop()
    {
        playerUpgradeHUD.SetActive(true);
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
        if (fragments.Value >= costOfMaxHealth)
        {
            fragments.Value -= costOfMaxHealth;
            pStats.UpgradeMaxHealth(runeMaxHealth.Value);
            GameObject.Find("UpgradeMaxHealth").SetActive(false);
            Debug.Log("Gimme my money");
        }
    }

    public void PurchaseSmallPotion()
    {
        if (fragments.Value >= costOfSmallPotion)
        {
            fragments.Value -= costOfSmallPotion;
            pStatsSO.PotionCounter++;
            pStatsSO.PotionCounter++;
            GameObject.Find("Small Potions").SetActive(false);
        }
    }

    public void DashCooldownPurchase()
    {
        if (fragments.Value >= dashCooldownCost)
        {
            fragments.Value -= dashCooldownCost;
            pStatsSO.DashCooldwon += pStatsSO.DashCooldwon * -0.2f;
            GameObject.Find("DashCooldown").SetActive(false);
        }
    }

    public void PurchaseTeleportDash()
    {
        if (fragments.Value >= teleportDashCost)
        {
            fragments.Value -= teleportDashCost;
            pStatsSO.TeleportDash = true;
            GameObject.Find("Teleport Dash").SetActive(false);
        }
    }

    public void PurchaseBombDash()
    {
        if (fragments.Value >= bombDashCost)
        {
            fragments.Value -= bombDashCost;
            pStatsSO.DashBomb = true;
            GameObject.Find("BombDash").SetActive(false);
        }
    }

    public void PurchaseInvisibiltyDash()
    {
        if (fragments.Value >= invisibiltyDashCost)
        {
            fragments.Value -= invisibiltyDashCost;
            pStatsSO.InvisibleAbility = true;
            GameObject.Find("Invisibility Dash").SetActive(false);
        }
    }



}
