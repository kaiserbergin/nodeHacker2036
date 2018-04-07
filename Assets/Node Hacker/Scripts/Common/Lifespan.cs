using UnityEngine;
using System.Collections;

public class Lifespan : MonoBehaviour {
    public float lifespan;
    private float endOfLifeThreshold;

    private void OnEnable() {
        endOfLifeThreshold = Time.time + lifespan;
    }

    private void Update() {
        if(Time.time > endOfLifeThreshold) {
            gameObject.SetActive(false);
        }
    }
}
