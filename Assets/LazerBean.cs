using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerBean : MonoBehaviour
{
    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyStats>().TakeDamage(damage);
        }
    }

}
