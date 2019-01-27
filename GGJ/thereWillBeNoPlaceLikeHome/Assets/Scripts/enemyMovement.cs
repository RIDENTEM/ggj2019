using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{

    Vector3 patrolPos1;
    Vector3 patrolPos2;
    Transform[] childPatrolPointTransforms;

    void Start()
    {
        childPatrolPointTransforms = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
