using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class WeaponSO : ScriptableObject
{
	[SerializeField] private float ammoCappacity;
	public float AmmoCapacity
	{
		get { return ammoCappacity; }
		set { ammoCappacity = value; }
	}

    [SerializeField] private float reloadTime;
    public float ReloadTime
    {
        get { return reloadTime; }
        set { reloadTime = value; }
    }

    [SerializeField] private float fireRate;
    public float FireRate
    {
        get { return fireRate; }
        set { fireRate = value; }
    }


    [SerializeField] private float bulletSpeed;
    public float BulletSpeed
    {
        get { return bulletSpeed; }
        set { bulletSpeed = value; }
    }


    [SerializeField] private float projectileDamage;
    public float ProjectileDamage
    {
        get { return projectileDamage; }
        set { projectileDamage = value; }
    }

    //[SerializeField] private float piercingBullets;
    //public float PiercingBullets
    //{
    //    get { return piercingBullets; }
    //    set { piercingBullets = value; }
    //}

    [SerializeField] private bool explodingBullets;
    public bool ExplodingBullets
    {
        get { return explodingBullets; }
        set { explodingBullets = value; }
    }

    //[SerializeField] private bool immobilisingBullets;
    //public bool ImmobolisingBullets
    //{
    //    get { return immobilisingBullets; }
    //    set { immobilisingBullets = value; }
    //}

    [SerializeField] private float beamDamage;
    public float BeamDamage
    {
        get { return beamDamage; }
        set { beamDamage = value; }
    }

    [SerializeField] private float beamCooldown;
    public float BeamCooldown
    {
        get { return beamCooldown; }
        set { beamCooldown = value; }
    }

    [SerializeField] float explodingDamage;
    public float ExplodingDamage
    {
        get { return explodingDamage; }
        set { explodingDamage = value; }
    }

    [SerializeField] float projectileLifetime;
    public float ProjectileLifetime
    {
        get { return projectileLifetime; }
        set { projectileLifetime = value; }
    }

    [SerializeField] float orbDamage;
    public float OrbDamage
    {
        get { return orbDamage; }
        set { orbDamage = value; }
    }

    [SerializeField] float orbRadius;
    public float OrbRadius
    {
        get { return orbRadius; }
        set { orbRadius = value; }
    }

    [SerializeField] float orbLifeTime;
    public float OrbLifeTime
    {
        get { return orbLifeTime; }
        set { orbLifeTime = value; }
    }

    [SerializeField] float orbSlowStrength;
    public float OrbSlowStrength
    {
        get { return orbSlowStrength; }
        set { orbSlowStrength = value; }
    }

    [SerializeField] float orbcooldown;
    public float OrbCooldown
    {
        get { return orbcooldown; }
        set { orbcooldown = value; }
    }

    [SerializeField] float orbSpeed;
    public float OrbSpeed
    {
        get { return orbSpeed; }
        set { orbSpeed = value; }
    }
}
