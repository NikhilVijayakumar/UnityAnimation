using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swiming : MonoBehaviour
{
    private float speed = 5.0f;
    private float rotationSpeed = 10.0f;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
    }

    private void playerMovement()
    {
        float move = Input.GetAxis("Vertical");
        float rotation = Input.GetAxis("Horizontal");

        if (animator != null && (move != 0 || rotation != 0))
        {
            if(move != 0)
            {
                move *= speed * Time.deltaTime;
                animator.SetFloat("speed", speed);
            }
            if (rotation != 0)
            {
                rotation *= rotationSpeed * Time.deltaTime;
            }
           
           
            
        }
        else
        {
            animator.SetFloat("speed", 0);           
        }
      
        transform.Translate(0, 0, move);
        transform.Rotate(0, rotation, 0);
    }

}
