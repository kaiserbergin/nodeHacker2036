using UnityEngine;
using System.Collections;

public class Facing : MonoBehaviour {

    public bool IsFacingDirectlyAtTarget(GameObject target) {
        RaycastHit hit;
        // if (Physics.Raycast(transform.position, transform.forward, out hit, QueryTriggerInteraction.Ignore)) {
        if (Physics.Raycast(transform.position, transform.forward, out hit, Mathf.Infinity, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Ignore)) {
            return hit.collider.gameObject.GetInstanceID() == target.GetInstanceID();
        }
        return false;
    }
}
