using UnityEngine;
using System.Collections;

public class LaserSwordController : MonoBehaviour {
    public DealDamage dealDamage;
    public WeaponCharges weaponCharges;
    public Rigidbody rb;

    private void Start() {
        dealDamage = gameObject.GetComponent<DealDamage>();
        weaponCharges = gameObject.GetComponent<WeaponCharges>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private int CalculateDamage() {
        return dealDamage.CalculateMultipliedBaseDamage(weaponCharges.chargeCapacity - weaponCharges.remainingCharges);
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log($"on collision with {collision.gameObject.name}");
        Damage targetDamageComponent = collision.gameObject.GetComponentInChildren<Damage>();
        if (targetDamageComponent != null && weaponCharges.remainingCharges > 0) {
            weaponCharges.ConsumeCharges(1);
            targetDamageComponent.TakeDamage(CalculateDamage());
        }
    }

    private void OnCollisionExit(Collision collision) {
        Debug.Log($"on collision exit with {collision.gameObject.name}");
    }
}
