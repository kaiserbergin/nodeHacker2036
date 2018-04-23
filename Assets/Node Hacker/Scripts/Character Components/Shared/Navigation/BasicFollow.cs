using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicFollow : MonoBehaviour {
    public void FollowTarget(GameObject target, NavMeshAgent navMeshAgent) {
        navMeshAgent.SetDestination(target.transform.position);
    }
}
