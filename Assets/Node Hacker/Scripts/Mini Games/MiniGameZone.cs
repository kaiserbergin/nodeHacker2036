using UnityEngine;

public class MiniGameZone : MonoBehaviour {
    public OculusTouchInterractionInterface oculusTouchInterractionInterface;
    public OculusTouchWeaponInterface oculusTouchWeaponInterface;
    public GameObject weapon;

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            oculusTouchInterractionInterface.isInterfaceEnabled = true;
            oculusTouchWeaponInterface.isInterfaceEnabled = false;
            if (weapon != null) {
                weapon.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            oculusTouchInterractionInterface.isInterfaceEnabled = false;
            oculusTouchWeaponInterface.isInterfaceEnabled = true;
            if (weapon != null) {
                weapon.SetActive(true);
            }
        }
    }
}
