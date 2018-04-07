using UnityEngine;
using System.Collections;

public class LookRotation : MonoBehaviour {

    public float speed;

    public Quaternion GetRotationTowardsTarget(Transform target) {
        Vector3 targetDir = target.position - transform.position;

        // The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        Debug.DrawRay(transform.position, newDir, Color.red);

        // Move our position a step closer to the target.
        return Quaternion.LookRotation(newDir);
    }
}
