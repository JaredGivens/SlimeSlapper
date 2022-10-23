using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum SlimeState
{
    Idle,
    Chase,
    ChargeTumble,
    Tumble,
    Wait,
}
public class EnemyAI : MonoBehaviour
{
    private Animator animator;
    private GameObject player;
    private Vector3 wanderTarget;

    private SlimeState state;
    private float tumbleCD, tumbleCharge, tumbleChargeDuration;
    private float dist;
    private bool isAttacking;
    public float speed, sightRange, attackRange;
    private PlayerHealth health;

    private void Awake()
    {
        tumbleCD = 0;
        tumbleCharge = 0;
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        health = player.GetComponent<PlayerHealth>();

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
            health.ProcessDamage(0.01f);
        }
        if(dist < sightRange)
        {
            
            Chase();
        }
        
    }

    private void FacePlayer()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5);
    }
    
    private void TryChargeTumble()
    {
        FacePlayer();
        if(tumbleCD == 0)
        {
            state = SlimeState.ChargeTumble;
            tumbleCharge = 0;
            ChargeTumble();

        } 
    }

    private void Tumble()
    {
        

    }
    private void TryTumble()
    {
        if(tumbleCharge > tumbleChargeDuration)
        {
            state = SlimeState.Tumble;
        } else
        {
            ChargeTumble();

        }
    }

    private void ChargeTumble()
    {
        tumbleCharge += Time.deltaTime;
        float scaleMod = tumbleCharge / tumbleChargeDuration / 2;
        transform.localScale.Set(1 + scaleMod, 1 - scaleMod, 1 + scaleMod);
    }

    private void Chase()
    {
        FacePlayer();
        Vector3 move = (player.transform.position - transform.position).normalized * Time.deltaTime  * speed;
        move.y = 0;
        transform.position += move;
    }

}
