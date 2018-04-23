using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ICEFollowController : MonoBehaviour {
    private LookRotation lookRotation;

    public GameObject target;
    private VisionRange visionRange;
    private Facing facing;
    private BasicFollow basicFollow;
    private BasicSearch basicSearch;

    private NavMeshAgent navMeshAgent;

    private bool searchAttempted = false;
    private bool targetSighted = false;

    // Use this for initialization
    void Start () {
        facing = gameObject.AddComponent<Facing>();
        basicFollow = transform.GetComponentInChildren<BasicFollow>();
        basicSearch = transform.GetComponentInChildren<BasicSearch>();
        lookRotation = transform.GetComponentInChildren<LookRotation>();
        visionRange = transform.GetComponentInChildren<VisionRange>();
        navMeshAgent = transform.GetComponentInChildren<NavMeshAgent>();

        if (target != null) {
            visionRange.validTargets = new List<GameObject> { target };
        }
    }
	
	// Update is called once per frame
	void Update () {
		if(target != null) {
            if (visionRange.CanViewTarget(target)) {
                if (!navMeshAgent.isActiveAndEnabled) navMeshAgent.enabled = true;
                basicFollow.FollowTarget(target, navMeshAgent);
                if (searchAttempted) searchAttempted = false;
                targetSighted = true;
            } else if (!searchAttempted && targetSighted && !basicSearch.searchEnabled) {
                basicSearch.StartSearch(target.transform);
                searchAttempted = true;
                targetSighted = false;
            }
        }
	}
}
