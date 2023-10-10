using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAttack : BaseState
{

    public bool canAttack;

    public override void EnterState(StateManager stateManager)
    {
        canAttack = true;

        Attack(stateManager);
    }

    public override void UpdateState(StateManager stateManager)
    {

    }

    void Attack(StateManager stateManager)
    {
        //if (canAttack)
        //{
        //    stateManager.attackPoint.LookAt(stateManager.player);
        //    canAttack = false;
        //    Invoke("ResetAttack", attackResetTime);
        //
        //    var currentBullet = Instantiate(projectile, attackPoint.position, attackPoint.rotation);
        //    currentBullet.GetComponent<Rigidbody>().velocity = attackPoint.forward * attackForce;
        //}
    }

    private void ResetAttack(StateManager stateManager)
    {
        canAttack = true;
        stateManager.canMove = true;
    }

    public override void OnCollisionEnter(StateManager stateManager)
    {

    }
}