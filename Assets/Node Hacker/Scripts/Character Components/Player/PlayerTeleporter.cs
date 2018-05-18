using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleporter : MonoBehaviour {
    [Header("UI Representations")]
    public LineRenderer teleportationDirectionIndicator;
    public GameObject teleportationLocationMarker;

    [Header("Settings")]
    public LayerMask terrainMask;
    public LayerMask teleportationSurface;
    public GameObject origin;
    public GameObject player;

    private Vector3 teleportationCoords;

    public void ShowTeleportationIndicators() {
        if(teleportationDirectionIndicator != null) {
            teleportationDirectionIndicator.gameObject.SetActive(true);
            teleportationDirectionIndicator.SetPosition(0, origin.transform.position);
        }
        if(teleportationLocationMarker != null) {
            teleportationLocationMarker.SetActive(true);
        }

        RaycastHit hit;

        // If we hit terrain, tp to groud in front, else tp to surface at distance
        if (Physics.Raycast(origin.transform.position, origin.transform.forward, out hit, 15, terrainMask)) {
            TerrainCast(hit);
        } else if (Physics.Raycast(origin.transform.position, origin.transform.forward, out hit, 15, teleportationSurface)) {
            teleportationCoords = hit.point;
            SetTeleportationIndicators(teleportationCoords);
        } else {
            GroundCast();
        }
    }

    public void Teleport() {
        ClearTeleportationIndicators();        
        player.transform.position = teleportationCoords;
    }

    private void GroundCast() {
        teleportationCoords = player.transform.position;
        RaycastHit groundRay;
        RaycastHit terrainRay;
        Vector3 pointInSpace = origin.transform.forward * 15 + origin.transform.position;
        if (!Physics.Raycast(pointInSpace, -Vector3.up, out terrainRay, 100, terrainMask) && Physics.Raycast(pointInSpace, -Vector3.up, out groundRay, 100, teleportationSurface)) {
            teleportationCoords = groundRay.point;
        }
        SetTeleportationIndicators(pointInSpace, teleportationCoords);
    }

    private void TerrainCast(RaycastHit terrainHit) {
        teleportationCoords = player.transform.position;
        RaycastHit groundRay;
        Vector3 pointInSpace = origin.transform.forward * 15 + origin.transform.position;
        if (Physics.Raycast(terrainHit.point, -Vector3.up, out groundRay, 100, teleportationSurface)) {
            teleportationCoords = groundRay.point;
        }
        SetTeleportationIndicators(pointInSpace, teleportationCoords);
    }

    private void SetTeleportationIndicators(Vector3 teleportationCoords) {
        if (teleportationDirectionIndicator != null) {
            teleportationDirectionIndicator.SetPosition(1, teleportationCoords);
        }
        if (teleportationLocationMarker != null) {
            teleportationLocationMarker.transform.position = teleportationCoords;
        }
    }

    private void SetTeleportationIndicators(Vector3 teleporationDirectionIndicatorCoords, Vector3 teleportationLocationMarkerCoords) {
        if (teleportationDirectionIndicator != null) {
            teleportationDirectionIndicator.SetPosition(1, teleporationDirectionIndicatorCoords);
        }
        if (teleportationLocationMarker != null) {
            teleportationLocationMarker.transform.position = teleportationLocationMarkerCoords;
        }
    }

    private void ClearTeleportationIndicators() {
        if (teleportationDirectionIndicator != null) {
            teleportationDirectionIndicator.gameObject.SetActive(false);
        }
        if (teleportationLocationMarker != null) {
            teleportationLocationMarker.SetActive(false);
        }
    }
}
