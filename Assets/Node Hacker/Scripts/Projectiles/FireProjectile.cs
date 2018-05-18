using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour {
    public Projectile projectilePrefab;
    private GameObject projectile;
    private Projectile projectileComponent;

    public void Fire(Transform origin, Vector3 target) {
        InitializeProjectile(origin);

        Projectile proj = projectile.GetComponent<Projectile>();
        proj.OnProjectileFired();

        Rigidbody rb = projectile.GetComponentInChildren<Rigidbody>();
        if(rb != null) {            
            rb.velocity = (target - origin.position).normalized * projectilePrefab.magnitude;
        }
    }

    public void FireForward(Transform origin) {
        InitializeProjectile(origin);

        Projectile proj = projectile.GetComponent<Projectile>();
        proj.OnProjectileFired();

        Rigidbody rb = projectile.GetComponentInChildren<Rigidbody>();
        if (rb != null) {
            rb.velocity = (origin.forward).normalized * projectilePrefab.magnitude;
        }
    }

    private void InitializeProjectile(Transform origin) {
        projectile = projectilePrefab.GetProjectileInstance();
        projectile.transform.position = origin.position;
        projectile.transform.rotation = origin.rotation;
    }
}
