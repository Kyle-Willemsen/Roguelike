using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    //References
    private NavMeshAgent navAgent;
    private Transform player;
    [SerializeField] LayerMask whatIsGround, whatIsPlayer;

    //Patrolling
    private Vector3 walkPoint;
    bool walkPointSet;
    [SerializeField] float walkPointRange;

   // //Attacking
   // [SerializeField] GameObject projectile;
   // [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange;
   // [SerializeField] float attackResetTime;
   // [SerializeField] float attackForce;
   // bool alreadyAttacked;

    //States
    [SerializeField] float sightRange;
    bool playerInSightRange, playerInAttackRange;
    bool isRanged;



    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange)
        {
            Patrolling();
        }
        if (playerInSightRange && !playerInAttackRange)
        {
            ChasePlayer();
        }
        if (playerInSightRange && playerInAttackRange)
        {
            AttackPlayer();
        }
    }

    private void Patrolling()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();
        }
        if (walkPointSet)
        {
            navAgent.SetDestination(walkPoint);
        }

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
        {
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void ChasePlayer()
    {
        navAgent.SetDestination(player.position);
    }

    public void AttackPlayer()
    {
        navAgent.SetDestination(transform.position);
        transform.LookAt(player);

        if (isRanged)
        {
            GetComponent<EnemyRanged>().canAttack = true;
        }
    }

    private void OnDrawGizomsSelected()
    {
        Debug.Log("DrawGizmo");
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
