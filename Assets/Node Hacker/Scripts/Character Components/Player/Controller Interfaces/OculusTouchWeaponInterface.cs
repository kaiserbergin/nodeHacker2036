using System;
using UnityEngine;

public class OculusTouchWeaponInterface : OculusTouchInterface {
    public SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device touchController;

    public PistolController pistolController;

    void Update() {
        if (isInterfaceEnabled) {
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
}
