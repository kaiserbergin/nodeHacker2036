using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardICEController : MonoBehaviour {
    private FireProjectile fireProjectile;

    public Transform projectileOriginTransform;
    public VisionRange visionRange;

    private ActionCoolDown fireProjectileCooldown;
    public float fireProjectileCooldownTime;

    public LookRotation lookRotation;

    public GameObject target;
    private Facing facing;
    
	// Use this for initialization
	void Start () {
        fireProjectile = GetComponent<FireProjectile>();

        fireProjectileCooldown = gameObject.AddComponent<ActionCoolDown>();
        fireProjectileCooldown.cooldownTime = fireProjectileCooldownTime;

        facing = gameObject.AddComponent<Facing>();

        if(target != null) {
            visionRange.validTargets = new List<GameObject> { target };
        }        
    }
	
	// Update is called once per frame
	void Update () {        
        #region Rotate towards Target
        if (target != null) {
            if (visionRange.CanViewTarget(target)) {
                lookRotation.transform.rotation = lookRotation.GetRotationTowardsTarget(target.transform);

                #region Fire Primary Weapon 
                if (fireProjectileCooldown.IsOffCooldown() && facing.IsFacingDirectlyAtTarget(target)) {
                    fireProjectile.Fire(projectileOriginTransform, target.transform.position);
                    fireProjectileCooldown.OnActionActivated();
                }
                #endregion
            }
        }        
        #endregion
    }
}
