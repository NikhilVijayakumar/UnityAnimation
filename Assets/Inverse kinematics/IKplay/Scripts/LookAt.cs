using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target;
    private Animator animator;
    public float weight = 1;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnAnimatorIK(int layerIndex)
    {
        animator.SetLookAtPosition(target.position);
        animator.SetLookAtWeight(weight);
       
    }
}
