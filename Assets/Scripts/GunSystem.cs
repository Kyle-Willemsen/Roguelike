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
    public GameObject gun;
    public Transform gunBarrel;
    public GameObject automaticBullet;
    public GameObject sniperBullet;
    public bool canShoot = true;

    [Header("Primary Stats")]
    public bool canShootPrimary;
    public float currentAmmo;


    [Header("Sniper Stats")]
    public float secondaryFireRate;
    public float secondarySpeed;
    public bool canShootSecondary;
    private bool sniperShot;




    private void Start()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();

        canShootPrimary = true;
        canShootSecondary = true;

        currentAmmo = weaponSO.AmmoCapacity;
    }
    private void Update()
    {
        gun.transform.LookAt(playerMovement.facingDir);
        Shoot();

        if (currentAmmo <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            canShoot = false;
            Invoke("Reload", weaponSO.ReloadTime);
        }

        if (sniperShot)
        {
            var currentBullet = Instantiate(sniperBullet, gunBarrel.position, gunBarrel.rotation);
            currentBullet.GetComponent<Rigidbody>().velocity = gunBarrel.forward * secondarySpeed;
            sniperShot = false;
        }

    }

    private void Reload()
    {
        currentAmmo = weaponSO.AmmoCapacity;
        canShoot = true;
    }
    private void Shoot()
    {
        if (canShoot)
        {
            if (Input.GetKey(KeyCode.Mouse0) && canShootPrimary && currentAmmo > 0)
            {
                canShootPrimary = false;
                canShootSecondary = false;
                currentAmmo--;

                Invoke("ResetPrimary", weaponSO.FireRate);

                var currentBullet = Instantiate(automaticBullet, gunBarrel.position, gunBarrel.rotation);
                currentBullet.GetComponent<Rigidbody>().velocity = gunBarrel.forward * weaponSO.BulletSpeed;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && canShootSecondary)
        {
            canShootSecondary = false;
            playerMovement.canMove = false;
            anim.SetBool("SniperShot", true);

            Invoke("ResetSecondary", secondaryFireRate);
        }
    }

    public void ShootSniper()
    {
        sniperShot = true;
    }

    public void ResetMovement()
    {
        anim.SetBool("SniperShot", false);
        playerMovement.canMove = true;
    }

    private void ResetPrimary()
    {
        canShootPrimary = true;
        canShootSecondary = true;
    }

    private void ResetSecondary()
    {
        canShootSecondary = true;
    }

}
