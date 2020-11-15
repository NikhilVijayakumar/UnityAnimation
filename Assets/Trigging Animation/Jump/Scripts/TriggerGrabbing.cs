using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGrabbing : MonoBehaviour {

    public GameObject rootPos;

    private void OnTriggerEnter(Collider other) {

        other.GetComponentInParent<ClimbUp>().GrabEdge(rootPos.transform);
    }
}
