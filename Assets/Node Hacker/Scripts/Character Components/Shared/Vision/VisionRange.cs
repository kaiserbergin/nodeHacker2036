using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VisionRange : MonoBehaviour {
    public List<GameObject> validTargets;
    public VisualDetection visualDetection;
    public List<GameObject> viewedTargets;

    public bool CanViewTarget(GameObject target) {
        return viewedTargets.Contains(target);
    }

    private void OnTriggerStay(Collider other) {
        if (visualDetection != null && validTargets != null && validTargets.Count > 0) {
            foreach (GameObject target in validTargets) {
                if (other.gameObject.CompareTag(target.tag)) {
                    if (visualDetection.CanViewTarget(other) && !viewedTargets.Contains(other.gameObject)) {
                        viewedTargets.Add(other.gameObject);
                    } else if (viewedTargets.Contains(other.gameObject)) {
                        viewedTargets.Remove(other.gameObject);
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (visualDetection != null && validTargets != null && validTargets.Count > 0) {
            foreach (GameObject target in validTargets) {
                if (other.gameObject.CompareTag(target.tag) && viewedTargets.Contains(other.gameObject)) {
                    viewedTargets.Remove(other.gameObject);
                }
            }
        }
    }
}
