using UnityEngine;
using System.Collections.Generic;

public class Projectile : MonoBehaviour {
    public GameObject projectilePrefab;
    public float magnitude;
    public List<LayerMask> layerWhiteList;
    public GameObject impactPrefab;

    private DealDamage dealDamage;

    private void Awake() {
        dealDamage = gameObject.GetComponent<DealDamage>();
    }

    public GameObject GetProjectileInstance() {
        return ObjectPools.instance.SpawnObject(projectilePrefab);
    }
    
    private void OnCollisionEnter(Collision collision) {
        foreach (LayerMask mask in layerWhiteList) {
            if (1 >> mask == collision.gameObject.layer) {
                if (collision.transform.GetComponentInChildren<Damage>() != null && dealDamage != null) {
                    collision.transform.GetComponentInChildren<Damage>().TakeDamage(dealDamage.DealActualDamage());
                }
                gameObject.SetActive(false);
                break;
            }
        }
        
    }
}
