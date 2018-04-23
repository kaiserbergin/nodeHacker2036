using UnityEngine;
using System.Collections;

public class LookRotation : MonoBehaviour {

    public float speed;

    public Quaternion GetRotationTowardsTarget(Vector3 targetPosition) {
        Vector3 targetDir = targetPosition - transform.position;

        // The step size is equal to speed times frame time.
        float step = speed * Time.deltaTime;

        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        Debug.DrawRay(transform.position, newDir, Color.red);
        // Move our position a step closer to the target.
        return Quaternion.LookRotation(newDir);
    }

    //TODO fix this mess
    public Vector3 MatchRotation(Vector3 targetRotation) {
        float step = speed * Time.deltaTime;
        return new Vector3(
            transform.rotation.x + targetRotation.x * step,
            transform.rotation.y + targetRotation.y * step,
            transform.rotation.z + targetRotation.z * step
        );
    }

    public void RotateAtSpeed(Transform transform) {
        float step = speed * Time.deltaTime;
        transform.Rotate(step, 0, 0);
    }
}
