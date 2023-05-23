using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileUpgrades : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] SingleValuesSO fragments;
    GunSystem gunSystem;

    public GameObject projecteileUpgradeHUD;
    //public Transform main;
    public GameObject shopIndicator;

    [SerializeField] float projectileDamageCost;
    [SerializeField] float explodingBulletCost;
    //[SerializeField] float ammoCapCost;
    //[SerializeField] float reloadSpeedCost;
    [SerializeField] float fireRateCost;
    [SerializeField] float bulletSpeedCost;
    [SerializeField] float lifeSpanCost;

    [SerializeField] List<GameObject> randomUpgrades = new List<GameObject>();
    //private float maxUpgrades = 3;

    // [SerializeField] GameObject explodingBulletMenu;
    // [SerializeField] GameObject fireRateMenu;
    // [SerializeField] GameObject bulletSpeedMenu;
    // [SerializeField] GameObject projectileBaseDamageMenu;
    // [SerializeField] GameObject projectileLifespanMenu;

    //[SerializeField] List<GameObject> removed = new List<GameObject>();
    public int random;
    public float indicatorRadius;
    [SerializeField] LayerMask layerMask;

    private void Start()
    {
        gunSystem = GameObject.Find("Player").GetComponent<GunSystem>();
       // projecteileUpgradeHUD = GameObject.Find("Projectile Upgrades");
       // shopIndicator = GameObject.Find("OpenShop");

        for (int i = 0; i < 3; i++)
        {
            random = Random.Range(0, randomUpgrades.Count);
            //Debug.Log("i = " +i);
            //Debug.Log("random = " + random);
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
                    projecteileUpgradeHUD.SetActive(false);
                }
            }

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
        projecteileUpgradeHUD.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        shopIndicator.SetActive(false);
        projecteileUpgradeHUD.SetActive(false);
        gunSystem.canShoot = true;
    }


    public void UpgradeProjectileDamage()
    {
        if (fragments.Value >= projectileDamageCost)
        {
            fragments.Value -= projectileDamageCost;
            weaponSO.ProjectileDamage += weaponSO.ProjectileDamage * 0.15f;
            GameObject.Find("Projectile Damage").SetActive(false);
        }
    }
    public void UpgradeExplodingBulelts()
    {
        if (fragments.Value >= explodingBulletCost)
        {
            fragments.Value -= explodingBulletCost;
            weaponSO.ExplodingBullets = true;
            GameObject.Find("Exploding Projectiles Menu").SetActive(false);
        }
    }


    public void UpgradeFireRate()
    {
        if (fragments.Value >= fireRateCost)
        {
            fragments.Value -= fireRateCost;
            weaponSO.ProjectileFireRate += weaponSO.ProjectileFireRate * -0.25f;
            GameObject.Find("Fire Rate").SetActive(false);

        }
    }

    public void UpgradeBulletSpeed()
    {
        if (fragments.Value >= bulletSpeedCost)
        {
            fragments.Value -= bulletSpeedCost;
            weaponSO.ProjectileSpeed += weaponSO.ProjectileSpeed * 0.1f;
            GameObject.Find("Bullet Speed").SetActive(false);
        }
    }

    public void UpgradeProjectileLifeSpan()
    {
        if (fragments.Value >= lifeSpanCost)
        {
            fragments.Value -= lifeSpanCost;
            weaponSO.ProjectileLifetime += weaponSO.ProjectileLifetime * 0.1f;
            GameObject.Find("Projectile LifeSpan").SetActive(false);
        }
    }
    //  public void UpgradeAmmoCapacity()
    //  {
    //      if (fragments.Value >= ammoCapCost)
    //      {
    //          fragments.Value -= ammoCapCost;
    //          weaponSO.AmmoCapacity += weaponSO.AmmoCapacity * 0.2f;
    //      }
    //  }
    //
    //  public void UpgradeReloadSpeed()
    //  {
    //      if (fragments.Value >= reloadSpeedCost)
    //      {
    //          fragments.Value -= reloadSpeedCost;
    //          weaponSO.ReloadTime += weaponSO.ReloadTime * -0.1f;
    //      }
    //  }
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
