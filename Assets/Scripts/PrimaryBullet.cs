using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryBullet : MonoBehaviour
{
    public float damage;
    [SerializeField] WeaponSO weaponSO;
    
    
     private void Update()
     {
         Destroy(gameObject, 0.7f);
     }
    
    
     private void OnCollisionEnter(Collision collision)
     {
         if (collision.gameObject.tag == "Enemy")
         {
             collision.gameObject.GetComponent<EnemyStats>().TakeDamage(weaponSO.RifleDamage);
             Destroy(gameObject);
         }
         Destroy(gameObject);
     }
}
