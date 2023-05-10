using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows.Speech;

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

    //public List<Transform> gunBarrels = new List<Transform>();

    private void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();

        canShootPrimary = true;
        canShootBeam = true;
        canShootOrb = true;

        //currentAmmo = weaponSO.AmmoCapacity;
    }
    private void Update()
    {
        //gun.transform.LookAt(playerMovement.facingDir);
        Shoot();

        //if (currentAmmo <= 0 || Input.GetKeyDown(KeyCode.R))
        //{
        //    canShoot = false;
        //    Invoke("Reload", weaponSO.ReloadTime);
        //}

       // if (beamActive)
       // {
       //     var currentBullet = Instantiate(sniperBullet, shootPos.position, shootPos.rotation);
       //     currentBullet.GetComponent<Rigidbody>().velocity = shootPos.forward * secondarySpeed;
       //     beamActive = false;
       // }

    }

   // private void Reload()
   // {
   //     currentAmmo = weaponSO.AmmoCapacity;
   //     canShoot = true;
   // }
    private void Shoot()
    {
        if (canShoot)
        {
            if (Input.GetKey(KeyCode.Mouse0) && canShootPrimary)// && currentAmmo > 0)
            {
                canShootPrimary = false;
                //canShootSecondary = false;
                //currentAmmo--;

                Invoke("ResetPrimary", weaponSO.FireRate);

                if (weaponSO.ExplodingBullets)
                {
                    var explodingBullets = Instantiate(explodingProjectile, shootPos.position, shootPos.rotation);
                    explodingBullets.GetComponent<Rigidbody>().velocity = shootPos.forward * weaponSO.BulletSpeed;
                }
                else
                {
                    var currentBullet = Instantiate(normalProjectile, shootPos.position, shootPos.rotation);
                    currentBullet.GetComponent<Rigidbody>().velocity = shootPos.forward * weaponSO.BulletSpeed;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && canShootBeam)
        {
            canShootBeam = false;
            playerMovement.canMove = false;
            //anim.SetBool("SniperShot", true);

            lazerBeam.SetActive(true);
            StartCoroutine(LazerBeam());
            Invoke("BeamCooldown", beamCooldown);


            //Invoke("ResetSecondary", secondaryFireRate);
        }

        if (Input.GetKeyDown(KeyCode.R) && canShootOrb)
        {
            var currentOrb = Instantiate(orb, orbSpawnPoint.position, Quaternion.identity);
            currentOrb.GetComponent<Rigidbody>().velocity = transform.forward * orbSpeed;
            canShootOrb = false;
            Invoke("OrbCooldown", orbCooldown);
        }
    }

    private void OrbCooldown()
    {
        canShootOrb = true;
    }

    private void BeamCooldown()
    {
        canShootBeam = true;
    }
    IEnumerator LazerBeam()
    {
        yield return new WaitForSeconds(beamLifespan);
        lazerBeam.SetActive(false);
        //canShootSecondary = true;
        playerMovement.canMove = true;
    }
   // public void ShootSniper()
   // {
   //     beamActive = true;
   // }

    //public void ResetMovement()
    //{
    //    anim.SetBool("SniperShot", false);
    //    playerMovement.canMove = true;
    //}

    private void ResetPrimary()
    {
        canShootPrimary = true;
        //canShootSecondary = true;
    }

    //private void ResetSecondary()
    //{
    //    canShootSecondary = true;
    //}

}
