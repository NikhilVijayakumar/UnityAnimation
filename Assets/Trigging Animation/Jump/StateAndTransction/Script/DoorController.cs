using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = this.GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("isOpened", true);
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("isOpened", false);
    }


}
