using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAttack : MonoBehaviour
{
    private Animator anim;
    private EnemyNavigation enemyNav;
    public GameObject attackPoint;
    public float attackRadius;
    public LayerMask layerMask;
    public float damage;

    public GameObject rock;
    public bool canThrowRock;


    private void Start()
    {
        anim = GetComponent<Animator>();
        enemyNav = GetComponent<EnemyNavigation>();

        canThrowRock = true;
    }

    private void Update()
    {
        
    }

    public void Attack()
    {
        anim.SetBool("isAttacking", true);
        anim.SetBool("isMoving", false);
        //Invoke("SecondAttack", 0.1f);
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



    public void SecondAttack()
    {
        if (canThrowRock)
        {
            Instantiate(rock, new Vector3(enemyNav.player.position.x, enemyNav.player.position.y -1, enemyNav.player.position.z), Quaternion.identity);
            canThrowRock = false;
        }
        Invoke("ResetThrow", 4);
    }

    private void ResetThrow()
    {
        canThrowRock = true;
    }
}
