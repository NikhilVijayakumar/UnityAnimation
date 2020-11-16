using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5.0f;
    private float rotationSpeed = 10.0f;
    private bool isDrunk;
    private float drunkSpeed = 3.0f;
    private Animator animator;
    private bool isJump;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isPlayerDrunk();
        playerMovement();
        playerJump();
    }

    private void playerJump()
    {
        if (Input.GetButtonDown("Jump") )
        {          
            animator.SetBool("isJump", true);
        }
    }

    private void playerMovement()
    {
        float move = Input.GetAxis("Vertical");
        float rotation = Input.GetAxis("Horizontal");
        
        if (animator != null && (move != 0 || rotation != 0))
        {
           
            if (isDrunk)
            {
                if (move > 0)
                {
                    move *= drunkSpeed * Time.deltaTime;                   
                    animator.SetFloat("drunkSpeed", drunkSpeed);
                    animator.SetFloat("speed", 0);
                }else if (move < 0)
                {
                    move *= drunkSpeed * Time.deltaTime;
                    animator.SetFloat("drunkSpeed", 1);
                    animator.SetFloat("speed", 0);
                }
                else if (rotation != 0)
                {
                    rotation *= rotationSpeed * Time.deltaTime;
                }

            }
            else
            {
                if (move > 0)
                {
                    move *= speed * Time.deltaTime;
                    animator.SetFloat("speed", speed);
                    animator.SetFloat("drunkSpeed", 0);
                }
                else if (move < 0)
                {
                    move *= drunkSpeed * Time.deltaTime;
                    animator.SetFloat("speed", 1);
                    animator.SetFloat("drunkSpeed", 0);
                }
                else if (rotation != 0)
                {
                    rotation *= rotationSpeed * Time.deltaTime;
                }              
            }
        }
        else
        {
            animator.SetFloat("speed", 0);
            animator.SetFloat("drunkSpeed", 0);
        }
        animator.SetBool("isJump", false);
        transform.Translate(0, 0, move);
        transform.Rotate(0, rotation, 0);
    }

    private void isPlayerDrunk()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isDrunk = true;
        }
       else if (Input.GetButtonDown("Fire2"))
        {
            isDrunk = false;
        }

        if(animator != null)
        {
            animator.SetBool("isDrunk", isDrunk);
        }
    }
}
