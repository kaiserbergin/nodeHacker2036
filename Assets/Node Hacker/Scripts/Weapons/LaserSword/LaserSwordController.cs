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
        Debug.Log($"Gonna test sword before dealing dmg! remaingin chrgs: {weaponCharges.remainingCharges} & target {targetDamageComponent}");
        if (targetDamageComponent != null && weaponCharges.remainingCharges > 0) {
            Debug.Log("doing dmg");
            weaponCharges.ConsumeCharges(1);
            targetDamageComponent.TakeDamage(CalculateDamage());
        }
    }
}
