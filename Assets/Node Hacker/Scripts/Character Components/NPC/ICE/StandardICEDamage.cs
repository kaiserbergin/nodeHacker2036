using UnityEngine;
using System.Collections;

public class StandardICEDamage : MonoBehaviour, Damage {
    private Health standardIceHealth;
    private void Awake() {
        standardIceHealth = gameObject.GetComponent<Health>();
    }
    public void TakeDamage(int damage) {
        if (standardIceHealth != null) {
            standardIceHealth.health -= damage;
            Debug.Log($"Player Health: {standardIceHealth.health}");
        } else {
            Debug.LogError("Cannot take damage if there is no health component, fool!");
        }
    }
}

