using UnityEngine;
using System.Collections;
/// <summary>
/// Cooldown:
///   A cooldown time will determine when you can next take an action.  
///   Public triggerCooldown starts iterating through the array and enables / disables based on time
///   isOnCooldown is a public bool to let others know what's up
/// </summary>

public class Cooldown : MonoBehaviour {
    public bool isOnCoolDown = false;

    [SerializeField]
    private float coolDownDuration = 1.0f;

    public void TriggerCooldown() {
        StartCoroutine(TriggerCooldownCooroutine());
    }

    IEnumerator TriggerCooldownCooroutine() {
        isOnCoolDown = true;
        Debug.Log($"starting cooldown at {Time.time}");
        yield return new WaitForSeconds(coolDownDuration);
        Debug.Log($"ending cooldown at {Time.time}");
        isOnCoolDown = false;
    }
}
