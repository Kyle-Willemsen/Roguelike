using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicMelee : MonoBehaviour
{
    public float damage;
    public BoxCollider attackCollider;
    public float attackLifeSpan;

    public void Attack()
    {
        attackCollider.enabled = true;
        Invoke("ResetAttack", attackLifeSpan);
    }

    private void ResetAttack()
    {
        attackCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerStats>().TakeDamage(damage);
        }
    }
}
