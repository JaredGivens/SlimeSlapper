using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    public LayerMask whatIsGround, whatIsPlayer;
    public Vector3 wanderTarget;
    public float walkPointRange;

    public float attackCD, sightRange, attackRange;
    public bool playerFound, withinSight, withinAttack;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        withinSight = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        withinAttack = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if(withinSight && !withinAttack)
        {
            Chase();

        } 
        else
        {
            Attack();
        }
        
    }
    private void Attack()
    {
        Debug.Log("attack");
    }
    private void Chase()
    {
        agent.SetDestination(player.position);
    }

}
