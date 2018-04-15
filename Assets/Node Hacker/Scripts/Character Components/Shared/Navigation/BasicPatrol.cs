using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicPatrol : MonoBehaviour {
    public PatrolWayPoint[] patrolWayPoints;
    public bool patrolModeEnabled;

    private NavMeshAgent navMeshAgent;
    private int currentWaypointIndex;

    private float waitTime;
    private bool isWaiting;

    private void Awake() {
        patrolModeEnabled = true;
        isWaiting = false;
    }

    void Start() {
        navMeshAgent = GetComponentInChildren<NavMeshAgent>();

        if (CanPatrol() && patrolModeEnabled) {
            currentWaypointIndex = 0;
            NavigateToNextWayPoint();
        }
    }

    void Update() {
        if (CanPatrol() && patrolModeEnabled && ArrivedAtWaypoint()) {
            if (isWaiting) {
                waitTime -= Time.deltaTime;
                if (waitTime <= 0) {
                    currentWaypointIndex = GetNextWaypoint();
                    waitTime = 0;
                    isWaiting = false;
                    NavigateToNextWayPoint();
                }
            }
            if (!isWaiting) {
                SetWaitTime();
                isWaiting = true;
            }
        }
    }

    private void NavigateToNextWayPoint() {
        navMeshAgent.SetDestination(patrolWayPoints[currentWaypointIndex].transform.position);
    }

    private bool ArrivedAtWaypoint() {
        return transform.position.x == patrolWayPoints[currentWaypointIndex].transform.position.x && transform.position.z == patrolWayPoints[currentWaypointIndex].transform.position.z;
    }

    private void SetWaitTime() {
        waitTime = patrolWayPoints[currentWaypointIndex].waitTime;
    }

    private int GetNextWaypoint() {
        return currentWaypointIndex == patrolWayPoints.Length - 1 ? 0 : currentWaypointIndex + 1;
    }

    private bool CanPatrol() {
        return navMeshAgent != null && patrolWayPoints != null && patrolWayPoints.Length > 1;
    }
}
