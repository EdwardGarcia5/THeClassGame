using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState{GotoBase,AttackBase,ChasePlayer,AttackPlayer};
    public EnemyState currentState;
    public Sight sightSensor;
    public float baseAttackDistance;
    public float playerAttackDistance;
    public Transform baseTransform;
    private NavMeshAgent agent;
    
    private void Awake()
    {
        baseTransform = GameObject.Find("BaseHP").transform;
        agent = GetComponentInParent<NavMeshAgent>();
    }

    void Update()
    {
        switch (currentState)
        {
        case EnemyState.AttackBase:
            AttackBase();
            break;
        case EnemyState.ChasePlayer:
            ChasePlayer();
            break;
        case EnemyState.AttackPlayer:
            AttackPlayer();
            break;
        default:
            GotoBase();
            break;
        }
    }

    void GotoBase()
    {
        agent.isStopped = false;
        agent.SetDestination(baseTransform.position);
        if(sightSensor.detectedObject != null)
        {
            currentState = EnemyState.ChasePlayer;
        }
        float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);
        // checks if base is nearer than the player
        if(distanceToBase < baseAttackDistance)
        {
            currentState = EnemyState.AttackBase;
        }
    }

    void AttackBase()
    {
        agent.isStopped = true;
    }

    void ChasePlayer()
    {
        agent.isStopped = false;
        if(sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GotoBase;
            return;
        }
        agent.SetDestination(sightSensor.detectedObject.transform.position);
        //verifies if the player is in range to attack
        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        if(distanceToPlayer <= playerAttackDistance)
        {
            currentState = EnemyState.AttackPlayer;
        }
    }

    void AttackPlayer()
    {
        agent.isStopped = true;
        if(sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GotoBase;
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        if(distanceToPlayer > playerAttackDistance* 1.1)
        {
            currentState = EnemyState.ChasePlayer;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, baseAttackDistance);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);
        
    }
}