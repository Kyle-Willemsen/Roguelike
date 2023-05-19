using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class OrbUpgrades : MonoBehaviour
{
    [SerializeField] List<GameObject> orbList = new List<GameObject>();
    [SerializeField] WeaponSO weaponSO;
    [SerializeField] SingleValuesSO fragments;
    GunSystem gunSystem;

    public GameObject orbUpgradeHUD;
    public GameObject shopIndicator;
    private float maxUpgrades = 3;
    private int random;
    public float indicatorRadius;
    [SerializeField] LayerMask layerMask;

    [SerializeField] float orbDamagCost;
    [SerializeField] float orbRadiusCost;
    [SerializeField] float orbLifeTimeCost;
    [SerializeField] float orbCooldownCost;


    // Start is called before the first frame update
    void Start()
    {
        gunSystem = GameObject.Find("Player").GetComponent<GunSystem>();
        random = Random.Range(0, orbList.Count - 1);

        for (int i = 0; i < 3; i++)
        {
            //Debug.Log(random);

            orbList[random].SetActive(true);
            orbList.RemoveAt(random);

        }
    }

    // Update is called once per frame
    void Update()
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
                    orbUpgradeHUD.SetActive(false);
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

    private void OnTriggerExit(Collider other)
    {
        shopIndicator.SetActive(false);
        orbUpgradeHUD.SetActive(false);
        gunSystem.canShoot = true;
    }

    private void OpenShop()
    {
        orbUpgradeHUD.SetActive(true);
    }


    public void UpgradeOrbDamage()
    {
        if (fragments.Value >= orbDamagCost)
        {
            fragments.Value -= orbDamagCost;
            weaponSO.OrbDamage += weaponSO.OrbDamage * 0.15f;
            GameObject.Find("Orb Damage").SetActive(false);
        }
    }

    public void UpgradeOrbLifetime()
    {
        if (fragments.Value >= orbLifeTimeCost)
        {
            fragments.Value -= orbLifeTimeCost;
            weaponSO.OrbLifeTime += weaponSO.OrbLifeTime * 0.15f;
            GameObject.Find("Orb Life Time").SetActive(false);
        }
    }

    public void OrbCooldown()
    {
        if (fragments.Value >= orbCooldownCost)
        {
            fragments.Value -= orbCooldownCost;
            weaponSO.OrbCooldown += weaponSO.OrbCooldown * -0.15f;
            GameObject.Find("Orb Cooldown").SetActive(false);
        }
    }
}
