using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public GameObject enemy;

    public float lookRadius = 10f;

   


    Transform target;
    NavMeshAgent agent;

    void Start()
    {
        
        target = PlayerDetection.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        
    }


    void Update()
    {

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)

        {
            enemy.GetComponent<NavMeshAgent>().enabled = true;
            enemy.GetComponent<WanderAI>().enabled = false;
            agent.SetDestination(target.position);
            

        }
        else
        {
            enemy.GetComponent<NavMeshAgent>().enabled = false;
            enemy.GetComponent<WanderAI>().enabled = true;


        }
    }

   

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}

//youtube.com/watch?v=xppompv1DBg