using UnityEngine;

public class ChaseState : BaseState
{
    bool playerInAttackRange;
    bool playerInSightRange;
    [SerializeField] float attackRange;
    [SerializeField] float sightRange;

    public override void EnterState(StateManager stateManager)
    {
        stateManager.navAgent.SetDestination(stateManager.player.position);

        if (stateManager.isRanged)
        {
            attackRange = stateManager.GetComponent<EnemyRanged>().attackRange;
        }
        if (stateManager.isGolem)
        {
            attackRange = stateManager.GetComponent<GolemAttack>().attackRange;
        }
        if (stateManager.isWizard)
        {
            attackRange = stateManager.GetComponent<EnemyRanged>().attackRange;
        }
        if (stateManager.isBasicMelee)
        {
            attackRange = stateManager.GetComponent<EnemyBasicMelee>().attackRange;
        }
        
    }

    public override void UpdateState(StateManager stateManager)
    {
        playerInAttackRange = Physics.CheckSphere(stateManager.transform.position, attackRange, stateManager.whatIsPlayer);
        playerInSightRange = Physics.CheckSphere(stateManager.transform.position, sightRange, stateManager.whatIsPlayer) && stateManager.playerInvisible == false;

        if (playerInAttackRange)
        {
            stateManager.SwitchState(stateManager.AttackState);
        }
        if (!playerInSightRange)
        {
            stateManager.SwitchState(stateManager.WanderState);
        }

    }


    public override void OnCollisionEnter(StateManager stateManager)
    {

    }
}
