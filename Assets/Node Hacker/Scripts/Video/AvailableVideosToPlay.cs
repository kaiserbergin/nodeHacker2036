using UnityEngine;
using System.Collections.Generic;

public class AvailableVideosToPlay : MonoBehaviour {
    public InventoryManager inventoryManager;
    private List<VhsTape> vhsTapes;

    private void Awake() {
        if (vhsTapes == null) vhsTapes = new List<VhsTape>();
    }

    private void Start() {
        VhsTape[] tapes = transform.root.GetComponentsInChildren<VhsTape>(true);
        foreach (VhsTape vhsTape in tapes) {
            vhsTapes.Add(vhsTape);
            vhsTape.gameObject.SetActive(false);
        }
        EnableAvailableVideos();
    }

    private void EnableAvailableVideos() {
        foreach (VhsTape vhsTape in vhsTapes) {
            if (inventoryManager.CheckItemByName(vhsTape)) {
                vhsTape.gameObject.SetActive(true);
            }
        }
    }

    private void Update() {
        EnableAvailableVideos();
    }
}
