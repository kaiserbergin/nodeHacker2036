using UnityEngine;
using System.Collections.Generic;

public class CollectVHS : MonoBehaviour {
    public List<string> acceptableTags;

    private VhsTape vhsTape;

    public float rotationSpeed = .25f;

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

    private void Update() {
        float step = rotationSpeed * Time.smoothDeltaTime;
        transform.Rotate(0, 0, rotationSpeed);
    }

    private void OnTriggerEnter(Collider other) {
        if (acceptableTags.Contains(other.tag) && vhsTape != null) {
            InventoryManager.instance.AddUniqueItem(vhsTape);
            gameObject.SetActive(false);
        }
    }
}
