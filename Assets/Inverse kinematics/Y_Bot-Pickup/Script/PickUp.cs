using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform target;
    public Transform hand;
    private Animator animator;
    private float weight = 1;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        weight = animator.GetFloat("IKWeight");

        if(weight > 0.95)
        {
            target.parent = hand;
            target.localPosition = new Vector3(0f,0.10f,0.14f);
            target.localRotation = Quaternion.Euler(331f, 0, 0);

        }

        animator.SetIKPosition(AvatarIKGoal.RightHand, target.position);
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, weight);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("pickup");
        }
    }
}
