using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.Controls;

public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject player;
    private Vector3 wanderTarget;

    private float chargeCD, dist;
    public float sightRange, attackRange;
    private bool playerFound;

    private void Awake()
    {
        player = GameObject.Find("Player");
        agent = GetComponent<NavMeshAgent>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        --chargeCD;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(transform.position, player.transform.position);

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

        Charge();
    }


    private void Charge()
    {
        if (chargeCD != 0)
        {
            
            chargeCD = 100;

        }
    }
    private void Chase()
    {
        Vector3 offset = Vector3.Normalize(transform.position - player.transform.position) * 3;
        agent.SetDestination(offset + player.transform.position);
    }

}
