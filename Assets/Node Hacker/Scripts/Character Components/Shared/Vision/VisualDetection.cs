using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VisualDetection : MonoBehaviour {
    public float fieldOfView;

    public bool CanViewTarget(Collider target) {
        Vector3 direction = target.transform.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);
        if(angle < fieldOfView * .5f) {
            RaycastHit hit;

            if(Physics.Raycast(transform.position, direction.normalized, out hit)) {
                return hit.collider.gameObject.GetInstanceID() == target.gameObject.GetInstanceID();
            }
        }
        return false;
    }
}
