using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryBullet : MonoBehaviour
{
    public float damage;
    [SerializeField] WeaponSO weaponSO;


    private void Start()
    {
        transform.Rotate(-90f, 0, 0);
        Destroy(gameObject, weaponSO.ProjectileLifetime);
    }
    private void Update()
     {

     }
    
    
     private void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.tag == "Enemy")
         {
            collision.gameObject.GetComponent<EnemyStats>().TakeDamage(weaponSO.ProjectileDamage);
            CameraShake.Instance.ShakeCamera(.5F, 0.2f);
            Destroy(gameObject, 1);
         }
         Destroy(gameObject);
     }
}
