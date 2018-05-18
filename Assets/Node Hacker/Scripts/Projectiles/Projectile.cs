using UnityEngine;
using System.Collections.Generic;

public class Projectile : MonoBehaviour {
    //Instantiation
    public GameObject projectilePrefab;

    //Physics
    public float magnitude;

    //Visual Effects
    public GameObject impactPrefab;

    //Audio Effects
    public AudioSource projectileSource;
    public AudioSource projectileTravel;
    public AudioSource projectileImpact;

    //Damage
    private DealDamage dealDamage;

    //State
    public bool isTraveling;

    private void Awake() {
        dealDamage = gameObject.GetComponent<DealDamage>();
    }

    public GameObject GetProjectileInstance() {
        return ObjectPools.instance.SpawnObject(projectilePrefab);
    }

    private void OnCollisionEnter(Collision collision) {
        if (projectileImpact != null) {
            projectileImpact.Play();
        }

        //Deal damage
        if (collision.transform.GetComponentInChildren<Damage>() != null && dealDamage != null) {
            collision.transform.GetComponentInChildren<Damage>().TakeDamage(dealDamage.DealActualDamage());
        }

        //Deactivate process
        if (impactPrefab != null) {
            impactPrefab = Instantiate(impactPrefab);
            impactPrefab.transform.position = transform.position;
            impactPrefab.transform.rotation = Quaternion.Inverse(transform.rotation);
        }
        gameObject.SetActive(false);
    }

    public void OnProjectileFired() {
        if (projectileSource != null) {
            projectileSource.Play();
        }
        if (projectileTravel != null) {
            projectileTravel.Play();
        }
    }
}
