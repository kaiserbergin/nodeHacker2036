using UnityEngine;
using System.Collections;

public class ActionCoolDown : MonoBehaviour {
    public float cooldownTime = 3f;
    public float nextAvailableActivationTime = 0f;

    public void OnActionActivated() {
        nextAvailableActivationTime = Time.time + cooldownTime;
    }

    public bool IsOffCooldown() {
        return Time.time > nextAvailableActivationTime;
    }
}
