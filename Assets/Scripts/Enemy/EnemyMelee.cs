using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    private Animator anim;
    private EnemyNavigation enemyNav;
    public GameObject attackPoint;
    public float attackRadius;
    public LayerMask layerMask;
    public float damage;


    private void Start()
    {
        anim = GetComponent<Animator>();
        enemyNav = GetComponent<EnemyNavigation>();
    }

    public void Attack()
    {
        anim.SetBool("isAttacking", true);
        anim.SetBool("isMoving", false);
    }

    public void Slam()
    {
        Collider[] colliders = Physics.OverlapSphere(attackPoint.transform.position, attackRadius, layerMask);
        foreach (Collider c in colliders)
            if (c.GetComponent<PlayerStats>())
            {
                c.GetComponent<PlayerStats>().TakeDamage(damage);
            }
        anim.SetBool("isAttacking", false);
        anim.SetBool("isMoving", true);
    }
}
