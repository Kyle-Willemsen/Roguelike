using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBullet : MonoBehaviour
{
    [SerializeField] WeaponSO weaponSO;
    public float radius;
    public LayerMask layermask;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyStats>().TakeDamage(weaponSO.BeamDamage);
            Destroy(gameObject);
        }
        
        Destroy(gameObject);
    }
}
