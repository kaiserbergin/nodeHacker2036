using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateValidTeleportationTris : MonoBehaviour {
    public int[] triangleIndeces;
    public Vector3[] meshVerts;
    public Vector3[] meshNormals;
    public Vector3[] triangleCenters;
    public Vector3[] triangleFaceNormals;
    public List<Vector3[]> validTriangles;

    public float drawRadius = .1f;
    public float degreeThreshold = 45f;

    void Start() {
        var mesh = gameObject?.GetComponentInChildren<MeshCollider>()?.sharedMesh;
        if (mesh != null) {
            InitializeValues();
        }
    }

    private void OnDrawGizmosSelected() {
        InitializeValues();
        Gizmos.color = Color.red;
        for (int i = 0; i < meshVerts.Length; i++) {
            Gizmos.DrawSphere(transform.TransformPoint(meshVerts[i]), drawRadius);
        }
        Gizmos.color = Color.blue;
        for (int i = 0; i < meshNormals.Length; i++) {
            Gizmos.DrawSphere(transform.TransformPoint(meshNormals[i]), drawRadius * 2);
        }
        Gizmos.color = Color.green;
        for (int i = 0; i < triangleCenters.Length; i++) {
            Gizmos.DrawSphere(transform.TransformPoint(triangleCenters[i]), drawRadius);
        }
        Gizmos.color = Color.yellow;
        for (int i = 0; i < triangleFaceNormals.Length; i++) {
            Gizmos.DrawSphere(transform.TransformPoint(triangleFaceNormals[i]), drawRadius);
        }
        Gizmos.color = Color.magenta;
        for (int i = 0; i < validTriangles.Count; i++) {
            Gizmos.DrawLine(transform.TransformPoint(validTriangles[i][0]), transform.TransformPoint(validTriangles[i][1]));
            Gizmos.DrawLine(transform.TransformPoint(validTriangles[i][1]), transform.TransformPoint(validTriangles[i][2]));
            Gizmos.DrawLine(transform.TransformPoint(validTriangles[i][2]), transform.TransformPoint(validTriangles[i][0]));
        }
    }

    private void InitializeValues() {
        validTriangles = new List<Vector3[]>();
        triangleIndeces = transform.GetComponent<MeshCollider>().sharedMesh.triangles;
        meshVerts = transform.GetComponent<MeshCollider>().sharedMesh.vertices;
        meshNormals = transform.GetComponent<MeshCollider>().sharedMesh.normals;

        triangleCenters = new Vector3[triangleIndeces.Length / 3];
        triangleFaceNormals = new Vector3[triangleIndeces.Length / 3];

        if (triangleIndeces != null && triangleIndeces.Length > 0) {
            for (int i = 0; i < triangleIndeces.Length; i += 3) {
                triangleCenters[i / 3] = (meshVerts[triangleIndeces[i]] + meshVerts[triangleIndeces[i + 1]] + meshVerts[triangleIndeces[i + 2]]) / 3;
                triangleFaceNormals[i / 3] = ((meshNormals[triangleIndeces[i]] + meshNormals[triangleIndeces[i + 1]] + meshNormals[triangleIndeces[i + 2]]) / 3);
                if (Vector3.Angle(transform.TransformVector(triangleFaceNormals[i / 3]), Vector3.up) <= degreeThreshold) {
                    validTriangles.Add(new Vector3[] {
                        meshVerts[triangleIndeces[i]],
                        meshVerts[triangleIndeces[i + 1]],
                        meshVerts[triangleIndeces[i + 2]]
                    });
                }
            }
        }
    }

    public bool IsValidTeleporationTri(int triIndex) {
        Vector3[] triVectors = { meshVerts[triIndex * 3], meshVerts[triIndex * 3 + 1], meshVerts[triIndex * 3 + 2] };
        for(int i = 0; i < validTriangles.Count; i++) {
            if (triVectors[0] == validTriangles[i][0] && triVectors[1] == validTriangles[i][1] && triVectors[2] == validTriangles[i][2]) {
                return true;
            }
        }
        return false;
    }
}
