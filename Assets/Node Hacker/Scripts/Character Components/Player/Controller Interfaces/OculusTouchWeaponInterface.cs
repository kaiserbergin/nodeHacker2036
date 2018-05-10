using System;
using UnityEngine;

public class OculusTouchWeaponInterface : MonoBehaviour {
    public SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device touchController;

    public PistolController pistolController;

    void Update() {
        try {
            touchController = SteamVR_Controller.Input((int)trackedObject.index);

            if (touchController.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) {
                pistolController.FirePistol();
            }
        } catch (IndexOutOfRangeException ex) {
            Debug.LogWarning("Waiting to detect controller");
        }
    }
}
