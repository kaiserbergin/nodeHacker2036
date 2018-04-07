using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour, Damage {
    private Health playerHealth;
    private void Awake() {
        playerHealth = gameObject.GetComponent<Health>();
    }
    public void TakeDamage(int damage) {
        if(playerHealth != null) {
            playerHealth.health -= damage;
            Debug.Log($"Player Health: {playerHealth.health}");
        }
    }
}
