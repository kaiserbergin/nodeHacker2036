using UnityEngine;
using System.Collections;

public class CollectedVHS : MonoBehaviour {
    public float yRotSpeed = 10f;
    public float lift = 1;
    public float fadeTime = 2.5f;

    private float spawnTime;

    private void Start() {
        spawnTime = Time.time;
    }

    private void Update() {
        if (Time.time >= spawnTime + fadeTime) {
            gameObject.SetActive(false);
        }
        float yStep = yRotSpeed * Time.smoothDeltaTime;
        transform.Rotate(0, 0, yStep);
        transform.position = transform.position + -Vector3.up * lift * Time.smoothDeltaTime / (fadeTime - spawnTime);
    }
}
