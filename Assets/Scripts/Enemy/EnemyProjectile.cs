using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float damage;

    private void Start()
    {
        transform.Rotate(-90, 0, 0);
    }
    private void Update()
    {
        Destroy(gameObject, 4);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
            Destroy(gameObject);
        }


        if (collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "Enemy")
        {
            Physics.IgnoreCollision(collision.collider, collision.collider);
        }

        Destroy(gameObject);
    }
}
