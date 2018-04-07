using System;
using UnityEngine;

public class DealDamage : MonoBehaviour {
    public int baseDamage = 0;
    public int actualDamage = 0;

    private void Awake() {
        ResetDamage();
    }

    public int DealActualDamage() {
        return actualDamage;
    }

    public void ResetDamage() {
        actualDamage = baseDamage;
    }

    public void AddToBaseDamage(int additionalDamage) {
        actualDamage = baseDamage + additionalDamage;
    }

    public void MultiplyBaseDamage(float damageMultiplier) {
        actualDamage = (int)(baseDamage * damageMultiplier);
    }
}
