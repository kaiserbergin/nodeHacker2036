using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {
    public GameObject deathPrefab;

    public void Kill() {
        if (deathPrefab != null) {
            deathPrefab.SetActive(true);
        }
        gameObject.SetActive(false);
    }
}
