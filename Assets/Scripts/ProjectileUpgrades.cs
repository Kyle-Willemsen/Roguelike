using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileUpgrades : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] SingleValuesSO fragments;
    GunSystem gunSystem;

    public GameObject projecteileUpgradeHUD;
    public Transform main;
    public GameObject shopIndicator;

    [SerializeField] float rifleDamageCost;
    [SerializeField] float explodingBulletCost;
    [SerializeField] float ammoCapCost;
    [SerializeField] float reloadSpeedCost;
    [SerializeField] float fireRateCost;
    [SerializeField] float bulletSpeedCost;

    [SerializeField] List<GameObject> randomUpgrades = new List<GameObject>();
    public float maxUpgrades = 3;

    // [SerializeField] GameObject explodingBulletMenu;
    // [SerializeField] GameObject fireRateMenu;
    // [SerializeField] GameObject bulletSpeedMenu;
    // [SerializeField] GameObject projectileBaseDamageMenu;
    // [SerializeField] GameObject projectileLifespanMenu;

    [SerializeField] List<GameObject> removed = new List<GameObject>();

    private void Start()
    {
        gunSystem = GameObject.Find("Player").GetComponent<GunSystem>();

        for (int i = 0; i < maxUpgrades; i++)
        {
            var clone = Instantiate(randomUpgrades[Random.Range(0, randomUpgrades.Count)], transform.position, Quaternion.identity, main.transform);
            //randomUpgrades.Remove();
            //removed.Add(clone);
            
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.K))
        {

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
        projecteileUpgradeHUD.SetActive(false);
        gunSystem.canShoot = true;
    }

    private void UpgradeTime()
    {
        projecteileUpgradeHUD.SetActive(true);
    }

    public void UpgradeRifleDamage()
    {
        if (fragments.Value >= rifleDamageCost)
        {
            fragments.Value -= rifleDamageCost;
            weaponSO.ProjectileDamage += weaponSO.ProjectileDamage * 0.15f;
        }
    }
    public void UpgradeExplodingBulelts()
    {
        if (fragments.Value >= explodingBulletCost)
        {
            fragments.Value -= explodingBulletCost;
            weaponSO.ExplodingBullets = true;
        }
    }

    public void UpgradeAmmoCapacity()
    {
        if (fragments.Value >= ammoCapCost)
        {
            fragments.Value -= ammoCapCost;
            weaponSO.AmmoCapacity += weaponSO.AmmoCapacity * 0.2f;
        }
    }

    public void UpgradeReloadSpeed()
    {
        if (fragments.Value >= reloadSpeedCost)
        {
            fragments.Value -= reloadSpeedCost;
            weaponSO.ReloadTime += weaponSO.ReloadTime * -0.1f;
        }
    }

    public void UpgradeFireRate()
    {
        if (fragments.Value >= fireRateCost)
        {
            fragments.Value -= fireRateCost;
            weaponSO.FireRate += weaponSO.FireRate * -0.25f;
        }
    }

    public void UpgradeBulletSpeed()
    {
        if (fragments.Value >= bulletSpeedCost)
        {
            fragments.Value -= bulletSpeedCost;
            weaponSO.BulletSpeed += weaponSO.BulletSpeed * 0.1f;
        }
    }

   // public void ActicateExplodingBullets()
   // {
   //
   //     explodingBulletMenu.SetActive(true);
   //     fireRateMenu.SetActive(false);
   //     bulletSpeedMenu.SetActive(false);
   //     projectileBaseDamageMenu.SetActive(false);
   //     projectileLifespanMenu.SetActive(false);
   // }
   //
   // public void ActivateFireRate()
   // {
   //     explodingBulletMenu.SetActive(false);
   //     fireRateMenu.SetActive(true);
   //     bulletSpeedMenu.SetActive(false);
   //     projectileBaseDamageMenu.SetActive(false);
   //     projectileLifespanMenu.SetActive(false);
   // }
   //
   // public void ActivateBulletSpeed()
   // {
   //     explodingBulletMenu.SetActive(false);
   //     fireRateMenu.SetActive(false);
   //     bulletSpeedMenu.SetActive(true);
   //     projectileBaseDamageMenu.SetActive(false);
   //     projectileLifespanMenu.SetActive(false);
   // }
   //
   // public void ActivateProjectileDamage()
   // {
   //     explodingBulletMenu.SetActive(false);
   //     fireRateMenu.SetActive(false);
   //     bulletSpeedMenu.SetActive(false);
   //     projectileBaseDamageMenu.SetActive(true);
   //     projectileLifespanMenu.SetActive(false);
   // }
   //
   // public void ActivateProjectileLifespan()
   // {
   //     explodingBulletMenu.SetActive(false);
   //     fireRateMenu.SetActive(false);
   //     bulletSpeedMenu.SetActive(false);
   //     projectileBaseDamageMenu.SetActive(false);
   //     projectileLifespanMenu.SetActive(true);
   // }
}
