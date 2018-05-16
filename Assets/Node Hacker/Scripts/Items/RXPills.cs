using System;
using System.Collections.Generic;
using UnityEngine;

public class RXPills : MonoBehaviour, IItem {
    //Interface Properties
    public Guid ItemId { get; private set; }
    public ItemTypes ItemType { get; private set; }
    public String ItemName { get; set; }

    //Public facing setters for editor
    public String itemName;

    //Item specific stuff
    public int hpRestored = 25;

    public List<string> acceptableTags;

    public void Initialize() {
        ItemName = itemName;
        ItemType = ItemTypes.RX_PILLS;
    }

    private void Awake() {
        ItemId = Guid.NewGuid();
        if (acceptableTags == null || acceptableTags.Count == 0) {
            acceptableTags = new List<string> {
                "Player",
                "Left Hand",
                "Right Hand"
            };
        }
        Initialize();
    }

    private void OnTriggerEnter(Collider other) {
        if (acceptableTags.Contains(other.tag)) {
            Health playerHealth = other.transform.root.GetComponentInChildren<Health>();
            if (playerHealth != null) {
                if (playerHealth.health + hpRestored > playerHealth.maxHealth) {
                    playerHealth.health = playerHealth.maxHealth;
                } else {
                    playerHealth.health += hpRestored;
                }
            }
            gameObject.SetActive(false);
        }
    }
}
