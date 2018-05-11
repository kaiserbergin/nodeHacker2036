using System;
using UnityEngine;

public class OculusTouchInterractionInterface : MonoBehaviour {
    public SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device touchController;

    public ObjectInterraction objectInterraction;

    void Update() {
        try {
            touchController = SteamVR_Controller.Input((int)trackedObject.index);

            if (touchController.GetPressDown(SteamVR_Controller.ButtonMask.Trigger)) {
                Debug.Log("Press down");
                objectInterraction.InitiateInterraction();
            }
            if (touchController.GetPressUp(SteamVR_Controller.ButtonMask.Trigger)) {
                Debug.Log("Press up");
                objectInterraction.TerminateInterraction();
            }
        } catch (IndexOutOfRangeException ex) {
            Debug.LogWarning("Waiting to detect controller");
        }
    }
}
