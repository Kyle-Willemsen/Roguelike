using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryBullet : MonoBehaviour
{
    public float damage;


    private void Update()
    {
        Destroy(gameObject, 4f);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
            Destroy(gameObject);
        }
        Destroy(gameObject);
    }
}
