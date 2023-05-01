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
        if (weaponSO.ExplodingBullets)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius, layermask);
            foreach (Collider collider in colliders)
            {
                collider.GetComponent<EnemyStats>().TakeDamage(weaponSO.ExplodingDamage);
                Destroy(gameObject);
            }
        }

        else if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyStats>().TakeDamage(weaponSO.SniperDamage);
            Destroy(gameObject);
        }
        
        Destroy(gameObject);
    }
}
