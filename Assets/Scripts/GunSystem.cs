using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class GunSystem : MonoBehaviour
{
    [Header("References")]
    PlayerMovement playerMovement;
    Animator anim;
    public GameObject gun;
    public Transform gunBarrel;
    public GameObject automaticBullet;
    public GameObject sniperBullet;
    public bool canShoot = true;

    [Header("Primary Stats")]
    public float primaryFireRate;
    public float primarySpeed;
    public bool canShootPrimary;


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
    }
    private void Update()
    {
        gun.transform.LookAt(playerMovement.facingDir);
        Shoot();

        if (sniperShot)
        {
            var currentBullet = Instantiate(sniperBullet, gunBarrel.position, gunBarrel.rotation);
            currentBullet.GetComponent<Rigidbody>().velocity = gunBarrel.forward * secondarySpeed;
            sniperShot = false;
        }

    }
    private void Shoot()
    {
        if (canShoot)
        {
            if (Input.GetKey(KeyCode.Mouse0) && canShootPrimary)
            {
                canShootPrimary = false;
                canShootSecondary = false;

                Invoke("ResetPrimary", primaryFireRate);

                var currentBullet = Instantiate(automaticBullet, gunBarrel.position, gunBarrel.rotation);
                currentBullet.GetComponent<Rigidbody>().velocity = gunBarrel.forward * primarySpeed;
            }

            if (Input.GetKeyDown(KeyCode.Mouse1) && canShootSecondary)
            {
                canShootSecondary = false;
                playerMovement.canMove = false;
                anim.SetBool("SniperShot", true);

                Invoke("ResetSecondary", secondaryFireRate);
            }
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
