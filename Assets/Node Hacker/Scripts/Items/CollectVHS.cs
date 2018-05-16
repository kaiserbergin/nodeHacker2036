using UnityEngine;
using System.Collections.Generic;

public class CollectVHS : MonoBehaviour {
    public List<string> acceptableTags;
    public InventoryManager inventoryManager;

    private VhsTape vhsTape;

    private void Awake() {
        if (acceptableTags == null || acceptableTags.Count == 0) {
            acceptableTags = new List<string> {
                "Player",
                "Left Hand",
                "Right Hand"
            };
        }
    }

    private void Start() {
        vhsTape = transform.GetComponent<VhsTape>();
    }

    private void OnTriggerEnter(Collider other) {
        if (acceptableTags.Contains(other.tag) && vhsTape != null) {
            inventoryManager.AddUniqueItem(vhsTape);
            gameObject.SetActive(false);
        }
    }
}
