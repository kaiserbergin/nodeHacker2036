using UnityEngine;
using System.Collections;

public class StandarICEDying : MonoBehaviour {
    public float explosionForce = 3f;
    public float explosionRadius = 3f;
    public float timeSpan = 3f;

    private float spawnTime;
    // Use this for initialization
    void Start() {
        Rigidbody[] rbs = transform.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in rbs) {
            rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
        }
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update() {
        if (Time.time >= timeSpan + spawnTime) {
            gameObject.SetActive(false);
        }
    }
}
