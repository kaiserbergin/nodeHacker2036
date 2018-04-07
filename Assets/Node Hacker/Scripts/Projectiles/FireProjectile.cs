using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour {
    public Projectile projectilePrefab;
    private GameObject projectile;

	public void Fire(Transform origin, Vector3 target) {
        projectile = projectilePrefab.GetProjectileInstance();
        projectile.transform.position = origin.transform.position;
        projectile.transform.rotation = origin.transform.rotation;

        Rigidbody rb = projectile.GetComponentInChildren<Rigidbody>();
        if(rb != null) {            
            rb.velocity = (target - origin.position).normalized * projectilePrefab.magnitude;
        }
    }
}
