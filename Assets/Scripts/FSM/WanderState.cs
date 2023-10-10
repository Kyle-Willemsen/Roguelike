using UnityEngine;

public class WanderState : BaseState
{
    //StateManager stateeManager;
    Vector3 walkPoint;
    bool walkPointSet;
    [SerializeField] float walkPointRange = 7;
    [SerializeField] float sightRange = 38;
    bool playerInSightRange;

    public override void EnterState(StateManager stateManager)
    {

    }

    public override void UpdateState(StateManager stateManager)
    {
        playerInSightRange = Physics.CheckSphere(stateManager.transform.position, sightRange, stateManager.whatIsPlayer) && stateManager.playerInvisible == false;

        if (!playerInSightRange && stateManager.canMove)
        {
            Patrolling(stateManager);
        }

        if (playerInSightRange && stateManager.canMove)
        {
            stateManager.SwitchState(stateManager.ChaseState);
        }
    }

    private void Patrolling(StateManager stateManager)
    {
        if (!walkPointSet)
        {
            SearchWalkPoint(stateManager);
            //anim.SetBool("isMoving", false);
        }
        if (walkPointSet)
        {
            stateManager.navAgent.SetDestination(walkPoint);
            // anim.SetBool("isMoving", true);
        }

        Vector3 distanceToWalkPoint = stateManager.transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 0.5f)
        {
            walkPointSet = false;
        }
    }

   

    private void SearchWalkPoint(StateManager stateManager)
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(stateManager.transform.position.x + randomX, stateManager.transform.position.y, stateManager.transform.position.z + randomZ);
        
        //was originally -transfrom, if theres an issue its because of that
        if (Physics.Raycast(walkPoint, -stateManager.transform.up, 2f, stateManager.whatIsGround))
        {
            walkPointSet = true;
        }
    }

    public override void OnCollisionEnter(StateManager stateManager)
    {

    }

    
}
