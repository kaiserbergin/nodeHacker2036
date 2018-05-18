using UnityEngine;
using System.Collections.Generic;

public class CollectVHS : MonoBehaviour {
    public List<string> acceptableTags;
    public GameObject collectedVHS;

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
        if ((acceptableTags.Contains(other.tag) || other.gameObject.layer == LayerMask.NameToLayer("Projectile")) && vhsTape != null) {
            InventoryManager.instance.AddUniqueItem(vhsTape);
            gameObject.SetActive(false);
            if (collectedVHS != null) {
                collectedVHS.transform.rotation = transform.rotation;
                collectedVHS.transform.position = transform.position;
                collectedVHS.SetActive(true);
            }
        }
    }
}
