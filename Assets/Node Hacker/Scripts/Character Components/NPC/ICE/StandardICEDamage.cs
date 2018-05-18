using UnityEngine;

public class StandardICEDamage : MonoBehaviour, Damage {
    private Health standardIceHealth;
    public StandardICEController standardICEController;
    public GameObject dyingStandardICE;

    private void Awake() {
        standardIceHealth = gameObject.GetComponent<Health>();
    }
    public void TakeDamage(int damage) {
        if (standardIceHealth != null) {
            standardIceHealth.health = standardIceHealth.health - damage;
        } else {
            Debug.LogError("Cannot take damage if there is no health component, fool!");
        }
        if (standardIceHealth.health <= 0) {
            if (dyingStandardICE != null) {
                Instantiate(dyingStandardICE, transform.position, transform.rotation);
            }
            gameObject.SetActive(false);
        }
        standardICEController.targetSighted = true;
    }
}

