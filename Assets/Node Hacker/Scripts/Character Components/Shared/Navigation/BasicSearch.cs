using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class BasicSearch : MonoBehaviour {
    //Search time variables
    public float searchTimeLimit = 10;
    private float searchTimeElapsed = 0f;

    //Target information
    private Transform targetTransform;
    private Vector3 lastKnownPosition;
    private Quaternion lastKnownRotation;

    //State flag
    public bool searchEnabled;

    //In Component Classes
    private LookRotation lookRotation;
    private NavMeshAgent navMeshAgent;

    private void Start() {
        lookRotation = transform.GetComponentInChildren<LookRotation>();
        navMeshAgent = transform.GetComponentInChildren<NavMeshAgent>();
    }


    public void StartSearch(Transform targetTransform) {
        this.targetTransform = targetTransform;
        lastKnownPosition = targetTransform.position;
        lastKnownRotation = targetTransform.localRotation;
        searchTimeElapsed = 0f;
        searchEnabled = true;
    }

    // Update is called once per frame
    void Update() {
        if(searchEnabled) {
            searchTimeElapsed += Time.deltaTime;
            if (searchTimeElapsed >= searchTimeLimit && searchEnabled) {
                searchEnabled = false;
                if (navMeshAgent.isActiveAndEnabled) navMeshAgent.SetDestination(transform.position);
            }
            if (searchEnabled) {
                if (transform.position.x == lastKnownPosition.x && transform.position.z == lastKnownPosition.z && lookRotation != null
                    && transform.rotation != lastKnownRotation) {
                    if (navMeshAgent.isActiveAndEnabled) navMeshAgent.enabled = false;
                    transform.rotation = lookRotation.GetRotationTowardsTarget(lastKnownPosition + targetTransform.forward);
                } else if (navMeshAgent.destination != lastKnownPosition) {
                    navMeshAgent.SetDestination(lastKnownPosition);
                }
            }
        }
    }
}
