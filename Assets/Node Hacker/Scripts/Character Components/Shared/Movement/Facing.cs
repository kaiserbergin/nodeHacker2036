using UnityEngine;
using System.Collections;

public class Facing : MonoBehaviour {

    public bool IsFacingDirectlyAtTarget(GameObject target) {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit)) {
            return hit.collider.gameObject.GetInstanceID() == target.GetInstanceID();
        }
        return false;
    }
}
