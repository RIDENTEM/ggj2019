using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMovement : MonoBehaviour
{


    Transform[] childPatrolPointTransforms;
    List<Vector3> patrolPoints = new List<Vector3>();
    int destPoint = 0;
    NavMeshAgent enemyNavAgent;
    bool firstPatrolPoint = true;

    void Start()
    {
        //There are four points, it starts at the top and includes the gameobject this starts from, as in the parent
        childPatrolPointTransforms = GetComponentsInChildren<Transform>();
        patrolPoints.Add(childPatrolPointTransforms[2].position);
        patrolPoints.Add(childPatrolPointTransforms[3].position);
        enemyNavAgent = GetComponentInChildren<NavMeshAgent>();
        // enemyNavAgent.SetDestination(patrolPos1);

    }

    void moveTowardPlayer()
    {
        Vector2.MoveTowards(transform.position, mainHomeManager.singletonHomeManager.transform.position, 1.0f);
    }

    void goToNextPoint()
    {
        enemyNavAgent.destination = patrolPoints[destPoint];
        destPoint = (destPoint + 1) % patrolPoints.Count;
    }

    void Update()
    {
        if (enemyNavAgent)
            if (!enemyNavAgent.pathPending && enemyNavAgent.remainingDistance < 0.95f)
            {

                goToNextPoint();

            }
    }
}
