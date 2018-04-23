using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StandardICEController : MonoBehaviour {
    private FireProjectile fireProjectile;

    public Transform projectileOriginTransform;
    private VisionRange visionRange;

    private ActionCoolDown fireProjectileCooldown;
    public float fireProjectileCooldownTime;

    private LookRotation lookRotation;

    public GameObject target;
    private Facing facing;

    private BasicPatrol basicPatrol;

    private NavMeshAgent navMeshAgent;

    private BasicSearch basicSearch;

    private bool searchAttempted = false;
    private bool targetSighted = false;

    // Use this for initialization
    void Start () {
        fireProjectile = GetComponent<FireProjectile>();

        fireProjectileCooldown = gameObject.AddComponent<ActionCoolDown>();
        fireProjectileCooldown.cooldownTime = fireProjectileCooldownTime;

        facing = gameObject.AddComponent<Facing>();
        basicPatrol = transform.GetComponentInChildren<BasicPatrol>();
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
        #region Rotate towards Target
        if (target != null) {
            if (visionRange.CanViewTarget(target)) {
                targetSighted = true;
                searchAttempted = false;

                //Stop what your doing and shoot someone
                if (basicPatrol != null && basicPatrol.patrolModeEnabled) {
                    basicPatrol.patrolModeEnabled = false;
                }
                if (basicSearch != null && basicSearch.searchEnabled) {
                    basicSearch.searchEnabled = false;
                }
                if(navMeshAgent.isActiveAndEnabled) {
                    navMeshAgent.enabled = false;
                }

                lookRotation.transform.rotation = lookRotation.GetRotationTowardsTarget(target.transform.position);

                #region Fire Primary Weapon 
                if (fireProjectileCooldown.IsOffCooldown() && facing.IsFacingDirectlyAtTarget(target)) {
                    fireProjectile.Fire(projectileOriginTransform, target.transform.position);
                    fireProjectileCooldown.OnActionActivated();
                }
                #endregion
            }
            //Start searching
            else if (!visionRange.CanViewTarget(target) && targetSighted && !searchAttempted && !basicSearch.searchEnabled) {
                navMeshAgent.enabled = true;
                basicSearch.StartSearch(target.transform);
                searchAttempted = true;
                targetSighted = false;
            }
            //Go back to patroling
            else if (!visionRange.CanViewTarget(target) && !basicSearch.searchEnabled && basicPatrol != null && !basicPatrol.patrolModeEnabled) {
                if (basicPatrol != null) {
                    basicPatrol.patrolModeEnabled = true;
                    navMeshAgent.enabled = true;
                    basicPatrol.NavigateToNextWayPoint();
                }
            }
        }        
        #endregion
    }
}
