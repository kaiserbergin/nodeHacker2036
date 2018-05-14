using UnityEngine;

public class VisualDetection : MonoBehaviour {
    public float fieldOfView;
    private int layerMask;

    private void Start() {
        layerMask = 1 << 9;
        layerMask = ~layerMask;
    }

    public bool CanViewTarget(Collider target) {
        Vector3 direction = target.transform.position - transform.position;
        float angle = Vector3.Angle(direction, transform.forward);
        if(angle < fieldOfView * .5f) {
            RaycastHit hit;

            if(Physics.Raycast(transform.position, direction.normalized, out hit, Mathf.Infinity, layerMask)) {
                return hit.collider.gameObject.GetInstanceID() == target.gameObject.GetInstanceID();
            }
        }
        return false;
    }
}
