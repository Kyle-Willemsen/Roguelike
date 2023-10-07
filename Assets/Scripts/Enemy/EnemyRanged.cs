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
    public bool isTrippleAttack;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        enemyNav = GetComponent<EnemyNavigation>();
        

        canAttack = true;
    }

    private void Update()
    {

    }

    public void NormalAttack()
    {
        if (canAttack)
        {
            attackPoint.LookAt(enemyNav.player);
            canAttack = false;
            Invoke("ResetAttack", attackResetTime);

            var currentBullet = Instantiate(projectile, attackPoint.position, attackPoint.rotation);
            currentBullet.GetComponent<Rigidbody>().velocity = attackPoint.forward * attackForce;
        }
    }

    public void Wizard()
    {
        if (canAttack)
        {
            attackPoint.LookAt(enemyNav.player);
            anim.SetBool("Attack", true);
            canAttack = false;

        }

    }
    public void ShootProjectile()
    {
        var currentBullet = Instantiate(projectile, attackPoint.position, attackPoint.rotation);
        currentBullet.GetComponent<Rigidbody>().velocity = attackPoint.forward * attackForce;
    }

    private void ResetAttack()
    {
        canAttack = true;
        enemyNav.canMove = true;
    }
    private void ResetTrippleAttack()
    {
        anim.SetBool("Attack", false);
        Invoke("ResetAttack", attackResetTime);
    }
}
