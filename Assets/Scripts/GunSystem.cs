using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows.Speech;
using UnityEngine.UI;

public class GunSystem : MonoBehaviour
{
    [Header("References")]
    PlayerMovement playerMovement;
    public WeaponSO weaponSO;
    Animator anim;
    //public GameObject gun;
    public Transform shootPos;
    public GameObject normalProjectile;
    public GameObject explodingProjectile;
    //public GameObject sniperBullet;
    public bool canShoot = true;

    [Header("Primary Stats")]
    public bool canShootPrimary;
    //public ParticleSystem muzzle;
    //public float currentAmmo;


    [Header("Beam Stats")]
    public GameObject lazerBeam;
    public float beamLifespan;
    //public float secondarySpeed;
    public bool canShootBeam;
    public float beamCooldown;
    //private bool beamActive;

    [Header("Orb Stats")]
    public GameObject orb;
    public Transform orbSpawnPoint;
    public float orbSpeed;
    public float orbCooldown;
    public bool canShootOrb;

    [Header("Beam Cooldown")]
    private Image beamImage;
    public bool beamActive = false;

    [Header("Orb Cooldown")]
    private Image orbImage;
    public bool orbActive = false;

    //public List<Transform> gunBarrels = new List<Transform>();

    private void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();

        canShootPrimary = true;
        canShootBeam = true;
        canShootOrb = true;
        orbImage = GameObject.Find("orbCD").GetComponent<Image>();
        beamImage = GameObject.Find("beamCD").GetComponent<Image>();
        orbImage.fillAmount = 0;
        beamImage.fillAmount = 0;


        //currentAmmo = weaponSO.AmmoCapacity;
    }
    private void Update()
    {
        Shoot();

        if (!canShootOrb)
        {
            orbImage.fillAmount -= 1 / orbCooldown * Time.deltaTime;

            if (orbImage.fillAmount <= 0)
            {
                orbImage.fillAmount = 0;
                canShootOrb = true;
            }
        }
        if (!canShootBeam)
        {
            beamImage.fillAmount -= 1 / beamCooldown * Time.deltaTime;

            if (beamImage.fillAmount <= 0)
            {
                beamImage.fillAmount = 0;
                canShootBeam = true;
            }
        }
    }

    private void Shoot()
    {
        if (canShoot)
        {
            if (Input.GetKey(KeyCode.Mouse0) && canShootPrimary)
            {
                canShootPrimary = false;


                Invoke("ResetPrimary", weaponSO.ProjectileFireRate);

                if (weaponSO.ExplodingBullets)
                {
                    var explodingBullets = Instantiate(explodingProjectile, shootPos.position, shootPos.rotation);
                    explodingBullets.GetComponent<Rigidbody>().velocity = shootPos.forward * weaponSO.ProjectileSpeed;
                }
                else
                {
                    var currentBullet = Instantiate(normalProjectile, shootPos.position, shootPos.rotation);
                    currentBullet.GetComponent<Rigidbody>().velocity = shootPos.forward * weaponSO.ProjectileSpeed;
                    //muzzle.Play();
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && canShootBeam)
        {
            LazerBeamAbility();
        }

        if (Input.GetKeyDown(KeyCode.R) && canShootOrb)
        {
            OrbAbility();
        }
    }

    private void LazerBeamAbility()
    {
        canShootBeam = false;
        playerMovement.canMove = false;

        beamImage.fillAmount = 1;
        lazerBeam.SetActive(true);
        StartCoroutine(LazerBeam());
        Invoke("BeamCooldown", beamCooldown);

        beamActive = true;
        CameraShake.Instance.ShakeCamera(1.5f, 0.35f);
    }

    private void OrbAbility()
    {
        var currentOrb = Instantiate(orb, orbSpawnPoint.position, Quaternion.identity);
        currentOrb.GetComponent<Rigidbody>().velocity = transform.forward * weaponSO.OrbSpeed;

        orbActive = true;
        orbImage.fillAmount = 1;

        canShootOrb = false;
        Invoke("OrbCooldown", weaponSO.OrbCooldown);
    }

    IEnumerator LazerBeam()
    {
        yield return new WaitForSeconds(beamLifespan);
        lazerBeam.SetActive(false);
        playerMovement.canMove = true;
    }


    private void ResetPrimary()
    {
        canShootPrimary = true;
    }

}
