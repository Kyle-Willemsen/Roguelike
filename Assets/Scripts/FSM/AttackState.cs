using UnityEngine;

public class AttackState : BaseState
{
    bool playerInAttackRange;
    [SerializeField] float attackRange = 20;
    

    public override void EnterState(StateManager stateManager)
    {
        AttackPlayer(stateManager);
    }      

    public override void UpdateState(StateManager stateManager)
    {
        AttackPlayer(stateManager);

        playerInAttackRange = Physics.CheckSphere(stateManager.transform.position, attackRange, stateManager.whatIsPlayer);

        if (!playerInAttackRange)
        {
            stateManager.SwitchState(stateManager.ChaseState);
        }
    }

    public void AttackPlayer(StateManager stateManager)
    {
        stateManager.canMove = false;
        stateManager.transform.LookAt(stateManager.player);
        stateManager.navAgent.SetDestination(stateManager.transform.position);


        if (stateManager.isRanged)
        {
            stateManager.GetComponent<EnemyRanged>().NormalAttack();
        }
        if (stateManager.isGolem)
        {
            stateManager.GetComponent<GolemAttack>().Attack();
        }
        if (stateManager.isWizard)
        {
            //stateManager.SwitchState(WizardAttack)
            stateManager.GetComponent<EnemyRanged>().Wizard();
        }
        if (stateManager.isBasicMelee)
        {
            stateManager.GetComponent<EnemyBasicMelee>().Attack();
        }

    }

    public override void OnCollisionEnter(StateManager stateManager)
    {

    }
}
