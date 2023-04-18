using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    //References
    private EnemyNavigation enemyNav;

    [SerializeField] GameObject projectile;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackResetTime;
    [SerializeField] float attackForce;

    public bool canAttack = true;
    bool alreadyAttacked;

    private void Start()
    {
        enemyNav = GetComponent<EnemyNavigation>();
    }

    private void Update()
    {
        if (canAttack)
        {
            var currentBullet = Instantiate(projectile, attackPoint.position, attackPoint.rotation);
            currentBullet.GetComponent<Rigidbody>().velocity = attackPoint.forward * attackForce;

            canAttack = false;
            Invoke("ResetAttack", attackResetTime);
        }
    }

    public void Attack()
    {


    }

    private void ResetAttack()
    {
        canAttack = true;
    }
}
