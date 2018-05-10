using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OculusTouchTeleportationInterface : MonoBehaviour {
    public SteamVR_TrackedObject trackedObject;
    private SteamVR_Controller.Device touchController;

    public PlayerTeleporter playerTeleporter;
	
	void Update () {
        try {
            touchController = SteamVR_Controller.Input((int)trackedObject.index);

            if (touchController.GetPress(SteamVR_Controller.ButtonMask.Trigger)) {
                playerTeleporter.ShowTeleportationIndicators();
            }
            if (touchController.GetPressUp(SteamVR_Controller.ButtonMask.Trigger)) {
                playerTeleporter.Teleport();
            }
        }
        catch (IndexOutOfRangeException ex) {
            Debug.LogWarning("Waiting to detect controller");
        }
	}
}
