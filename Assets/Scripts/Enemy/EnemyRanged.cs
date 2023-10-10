using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    //References
    private StateManager stateManager;

    [SerializeField] GameObject projectile;
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackResetTime;
    [SerializeField] float attackForce;
    public float attackRange;
    public float sightRange;


    public bool canAttack;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        stateManager = GetComponent<StateManager>();
        

        canAttack = true;
    }

    private void Update()
    {

    }

    public void NormalAttack()
    {
        if (canAttack)
        {
            Debug.Log("FFS");
            attackPoint.LookAt(stateManager.player);
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
            attackPoint.LookAt(stateManager.player);
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
        stateManager.canMove = true;
    }
    private void ResetTrippleAttack()
    {
        anim.SetBool("Attack", false);
        Invoke("ResetAttack", attackResetTime);
    }
}
