using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavigation : MonoBehaviour
{
    //References
    [HideInInspector] public NavMeshAgent navAgent;
    [HideInInspector] public Transform player;
    PlayerMovement pMovement;
    [SerializeField] LayerMask whatIsGround, whatIsPlayer;

    //Patrolling
    private Vector3 walkPoint;
    bool walkPointSet;
    [SerializeField] float walkPointRange;
    [SerializeField] float attackRange;

    //States
    [SerializeField] float sightRange;
    bool playerInSightRange, playerInAttackRange;
    public bool isRanged;
    public bool isGolem;
    public bool isWizard;
    public bool canMove = true;

    public bool playerInvisible;
    public bool isBasicMelee;
    public bool isLunge;


    public LayerMask environmentLayer;


    private void Awake()
    {
        navAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        pMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        //anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (pMovement.isInvisible)
        {
            playerInvisible = true;
        }
        else
        {
            playerInvisible = false;
        }
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer) && !playerInvisible;
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange && canMove)
        {
            Patrolling();

        }
        if (playerInSightRange && !playerInAttackRange && canMove)
        {
            ChasePlayer();
            //if (isGolem)
            //{
            //    GetComponent<GolemAttack>().SecondAttack();
            //}
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
            //anim.SetBool("isMoving", false);
        }
        if (walkPointSet)
        {
            navAgent.SetDestination(walkPoint);
            // anim.SetBool("isMoving", true);
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
       // if (isGolem)
       // {
       //     GetComponent<GolemAttack>().SecondAttack();
       // }
    }

    public void AttackPlayer()
    {
        canMove = false;
        navAgent.SetDestination(transform.position);
        transform.LookAt(player);



        if (isRanged)
        {
            GetComponent<EnemyRanged>().NormalAttack();
        }
        if (isGolem)
        {
            GetComponent<GolemAttack>().Attack();
        }
        if (isWizard)
        {
            GetComponent<EnemyRanged>().Wizard();
        }
        if (isBasicMelee)
        {
            GetComponent<EnemyBasicMelee>().Attack();
        }
        if (isLunge)
        {
            GetComponent<EnemyLunge>().Attack();
        }

    }
}
