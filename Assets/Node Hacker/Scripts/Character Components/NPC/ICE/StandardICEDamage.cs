using UnityEngine;

public class StandardICEDamage : MonoBehaviour, Damage {
    private Health standardIceHealth;
    private void Awake() {
        standardIceHealth = gameObject.GetComponent<Health>();
    }
    public void TakeDamage(int damage) {
        if (standardIceHealth != null) {
            standardIceHealth.health = standardIceHealth.health - damage;
            Debug.Log($"ICE Health: {standardIceHealth.health}");
        } else {
            Debug.LogError("Cannot take damage if there is no health component, fool!");
        }
        if(standardIceHealth.health <= 0) {
            gameObject.SetActive(false);
        }
    }
}

