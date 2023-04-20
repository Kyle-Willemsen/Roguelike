using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class GunSystem : MonoBehaviour
{
    [Header("References")]
    private PlayerMovement playerMovement;
    //private Rigidbody rb;
    public GameObject gun;
    public Transform gunBarrel;
    public GameObject automaticBullet;
    public GameObject sniperBullet;

    [Header("Gun Stats")]
    public float primaryFireRate;
    public float secondaryFireRate;
    public float primarySpeed;
    public float secondarySpeed;

    public bool canShootPrimary;
    public bool canShootSecondary;


    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        //rb = GetComponent<Rigidbody>();

        canShootPrimary = true;
        canShootSecondary = true;
    }
    private void Update()
    {
        Shoot();

        //gun.transform.LookAt(playerMovement.facingDir);
    }
    private void Shoot()
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

            Invoke("ResetSecondary", secondaryFireRate);

            var currentBullet = Instantiate(sniperBullet, gunBarrel.position, gunBarrel.rotation);
            currentBullet.GetComponent<Rigidbody>().velocity = gunBarrel.forward * secondarySpeed;
        }
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
