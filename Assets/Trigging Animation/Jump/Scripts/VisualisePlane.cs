using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualisePlane : MonoBehaviour {
    public Vector3 vertex1;
    public Vector3 vertex2;
    public Vector3 vertex3;

    void OnDrawGizmosSelected() {

        Plane myPlane = new Plane(vertex1, vertex2, vertex3);
        Gizmos.DrawLine(vertex1, vertex2);
        Gizmos.DrawLine(vertex2, vertex3);
        Gizmos.DrawLine(vertex3, vertex1);
    }

}