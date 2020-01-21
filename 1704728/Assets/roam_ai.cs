using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class roam_ai : MonoBehaviour
{
    public Transform[] wayPoints;
    [SerializeField]
    private NavMeshAgent navAgent;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        AINextDest();
    }

    // Update is called once per frame
    void Update()
    {
        if(navAgent.remainingDistance < 0.5f){
            AINextDest();
        }
    }

    void AINextDest(){

        if(wayPoints.Length == 0){
            return;
        }

        navAgent.destination = wayPoints[Random.Range(0,7)].position;
    }
}
