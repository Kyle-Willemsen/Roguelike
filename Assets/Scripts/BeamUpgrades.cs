using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamUpgrades : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    GunSystem gunSystem;
    PlayerStats pStats;
    [SerializeField] SingleValuesSO fragments;
    public GameObject beamUpgradeHUD;
    public GameObject shopIndicator;

    public float beamDamageCost;
    public float beamCooldownCost;


    private void Start()
    {
        pStats = GameObject.Find("Player").GetComponent<PlayerStats>();
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
    private void UpgradeTime()
    {
        beamUpgradeHUD.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        shopIndicator.SetActive(false);
        beamUpgradeHUD.SetActive(false);
        gunSystem.canShoot = true;
    }

    public void BeamDamage()
    {
        if (fragments.Value >= beamDamageCost)
        {
            fragments.Value -= beamDamageCost;
            weaponSO.BeamDamage += weaponSO.BeamDamage * 0.15f;
        }
    }

    public void BeamCooldown()
    {
        if (fragments.Value >= beamCooldownCost)
        {
            fragments.Value -= beamCooldownCost;
            weaponSO.BeamCooldown -= weaponSO.BeamCooldown * 0.1f;
        }
    }
}
