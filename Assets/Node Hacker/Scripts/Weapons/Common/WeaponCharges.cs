using UnityEngine;
using System.Collections;

/// <summary>
/// Stores number of charges in public var charges
/// For adding charges back, match the array index to the charge count
///   and apply a delay.  If rechargeDuration array is less than charges,
///   then use the last element of array.
/// ConsumeCharge & RestoreCharge will be the pub meths
/// </summary>

public class WeaponCharges : MonoBehaviour {
    public int chargeCapacity = 3;
    public int remainingCharges;

    [SerializeField]
    private bool autoGenerateCharges = false;
    public float[] rechargeDurations = { 1.0f };

    private IEnumerator currentRechargeCoroutine;

    private void Awake() {
        remainingCharges = chargeCapacity;
    }

    public void ConsumeCharges(int chargeCount = 1) {
        if (remainingCharges >= chargeCount) {
            remainingCharges = remainingCharges - chargeCount;
        } else {
            Debug.LogError("tried to use unavailable charges");
        }
        Debug.Log($"remaing charges after consumption: {remainingCharges}");
        if(autoGenerateCharges) {
            if(currentRechargeCoroutine == null) {
                currentRechargeCoroutine = TriggerRechargeTime();
            } else {
                StopCoroutine(currentRechargeCoroutine);
                currentRechargeCoroutine = TriggerRechargeTime();
            }
            StartCoroutine(currentRechargeCoroutine);
        }
    }

    public void RestoreCharges(int rechargeCount = 1) {
        if(currentRechargeCoroutine != null) {
            StopCoroutine(currentRechargeCoroutine);
        }
        if(remainingCharges + rechargeCount > chargeCapacity) {
            remainingCharges = chargeCapacity;
        } else {
            remainingCharges = remainingCharges + rechargeCount;
        }

        Debug.Log($"remaing charges after restore: {remainingCharges}");
        if (remainingCharges < chargeCapacity) {
            currentRechargeCoroutine = TriggerRechargeTime();
            StartCoroutine(currentRechargeCoroutine);
        }
    }

    IEnumerator TriggerRechargeTime() {
        while (chargeCapacity > remainingCharges) {
            Debug.Log($"Starting recharge at: {Time.time}");
            int rechargeDurationIndex = chargeCapacity - remainingCharges - 1 > rechargeDurations.Length ? rechargeDurations.Length - 1 : chargeCapacity - remainingCharges - 1;
            yield return new WaitForSeconds(rechargeDurations[rechargeDurationIndex]);
            Debug.Log($"Adding charge at: {Time.time}");
            remainingCharges = remainingCharges + 1;
            Debug.Log($"remainign charges in cooroutine loop: {remainingCharges}");
        }
    }
}
