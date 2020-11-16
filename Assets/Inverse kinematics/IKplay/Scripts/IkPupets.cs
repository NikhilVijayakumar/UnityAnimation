using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkPupets : MonoBehaviour
{
    public Transform target;
    private Animator animator;
    private float weight = 1;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnAnimatorIK(int layerIndex)
    {
        animator.SetIKPosition(AvatarIKGoal.RightHand, target.position);
        animator.SetIKPositionWeight(AvatarIKGoal.RightHand, weight);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            target.transform.Translate(0f, 0.1f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            target.transform.Translate(0f, -0.1f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            target.transform.Translate(0.1f, 0f, 0f);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            target.transform.Translate(-0.1f, 0f, 0f);
        }


    }
}
