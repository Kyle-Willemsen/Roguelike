using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateManager : MonoBehaviour
{
    public BaseState currentState;
    public WanderState WanderState = new WanderState();
    public ChaseState ChaseState = new ChaseState();
    public AttackState AttackState = new AttackState();

    [HideInInspector] public NavMeshAgent navAgent;
    [HideInInspector] public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public bool playerInvisible;
    public bool canMove = true;


    public bool isRanged;
    public bool isGolem;
    public bool isWizard;
    public bool isBasicMelee;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Spawn", 1.4f);


        navAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        //pMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
        Debug.Log(currentState);
    }

    public void SwitchState(BaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }

    void Spawn()
    {
        //The first state the AI enters when created
        currentState = WanderState;

        //Reference to the AI's context
        currentState.EnterState(this);
    }
}
