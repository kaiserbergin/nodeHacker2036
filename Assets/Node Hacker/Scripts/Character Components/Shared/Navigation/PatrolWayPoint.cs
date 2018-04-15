using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolWayPoint : MonoBehaviour {
    public float drawRadius;
    public float waitTime;

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, drawRadius);
    }
}
