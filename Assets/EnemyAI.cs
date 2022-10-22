using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    public Vector3 wanderTarget;
    public float walkPointRange;

    public float attackCD, sightRange, attackRange, dist;
    public bool playerFound;

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
        dist = Vector3.Distance(transform.position, player.position);

        if(dist < attackRange)
        {
            Attack();

        } 
        else if(dist < sightRange)
        {
            Chase();
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
