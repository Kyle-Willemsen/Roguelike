using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrades : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] SingleValuesSO fragments;
    GunSystem gunSystem;

    public GameObject weaponUpgradeHUD;
    public GameObject shopIndicator;

    [SerializeField] float rifleDamageCost;
    [SerializeField] float explodingBulletCost;
    [SerializeField] float ammoCapCost;
    [SerializeField] float reloadSpeedCost;
    [SerializeField] float fireRateCost;
    [SerializeField] float bulletSpeedCost;

    private void Start()
    {
        gunSystem = GameObject.Find("Player").GetComponent<GunSystem>();
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
        weaponUpgradeHUD.SetActive(false);
        gunSystem.canShoot = true;
    }

    private void UpgradeTime()
    {
        weaponUpgradeHUD.SetActive(true);
    }

    public void UpgradeRifleDamage()
    {
        if (fragments.Value >= rifleDamageCost)
        {
            fragments.Value -= rifleDamageCost;
            weaponSO.RifleDamage += weaponSO.RifleDamage * 0.15f;
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
}
