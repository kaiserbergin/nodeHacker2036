using UnityEngine;
using System.Collections.Generic;

public class AvailableVideosToPlay : MonoBehaviour {
    private List<VhsTape> vhsTapes;

    private void Awake() {
        if (vhsTapes == null) vhsTapes = new List<VhsTape>();
    }

    private void Start() {
        VhsTape[] tapes = transform.GetComponentsInChildren<VhsTape>(true);
        foreach (VhsTape vhsTape in tapes) {
            vhsTapes.Add(vhsTape);
            vhsTape.gameObject.SetActive(false);
        }
        EnableAvailableVideos();
    }

    private void EnableAvailableVideos() {
        foreach (VhsTape vhsTape in vhsTapes) {
            if (InventoryManager.instance.CheckItemByName(vhsTape)) {
                vhsTape.gameObject.SetActive(true);
            }
        }
    }
}
