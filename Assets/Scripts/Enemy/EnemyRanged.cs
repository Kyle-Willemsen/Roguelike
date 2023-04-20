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

    public bool canAttack;
    bool alreadyAttacked;

    private void Start()
    {
        enemyNav = GetComponent<EnemyNavigation>();

        canAttack = true;
    }

    private void Update()
    {

    }

    public void Attack()
    {
        if (canAttack)
        {
            canAttack = false;
            Invoke("ResetAttack", attackResetTime);

            var currentBullet = Instantiate(projectile, attackPoint.position, attackPoint.rotation);
            currentBullet.GetComponent<Rigidbody>().velocity = attackPoint.forward * attackForce;
        }

    }

    private void ResetAttack()
    {
        canAttack = true;
    }
}
