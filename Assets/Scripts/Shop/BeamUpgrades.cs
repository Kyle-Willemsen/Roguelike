using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamUpgrades : MonoBehaviour
{
    [SerializeField] List<GameObject> beamUpgrades = new List<GameObject>();
    [SerializeField] WeaponSO weaponSO;
    GunSystem gunSystem;
    PlayerStats pStats;
    [SerializeField] SingleValuesSO fragments;
    public GameObject beamUpgradeHUD;
    public GameObject shopIndicator;

    public float beamDamageCost;
    public float beamCooldownCost;
    private int random;

    public float indicatorRadius = 8;
    [SerializeField] LayerMask layerMask;


    private void Start()
    {
        pStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        gunSystem = GameObject.Find("Player").GetComponent<GunSystem>();

        for (int i = 0; i < 2; i++)
        {
            random = Random.Range(0, beamUpgrades.Count);

            beamUpgrades[random].SetActive(true);
            beamUpgrades.RemoveAt(random);

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
                    beamUpgradeHUD.SetActive(false);
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
            GameObject.Find("Beam Damage").SetActive(false);
        }
    }

    public void BeamCooldown()
    {
        if (fragments.Value >= beamCooldownCost)
        {
            fragments.Value -= beamCooldownCost;
            weaponSO.BeamCooldown -= weaponSO.BeamCooldown * 0.1f;
            GameObject.Find("Beam Cooldown").SetActive(false);
        }
    }
}
