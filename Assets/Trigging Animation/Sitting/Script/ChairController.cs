using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairController : MonoBehaviour
{
    private GameObject player;
    private GameObject anchor;
    private Animator anim;
    private bool isSitting;
    private bool isAutoWalking;

    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player");
        anchor = GameObject.FindGameObjectWithTag("ChairAnchor");
        anim = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAutoWalking)
        {
            AutoWalking();
        }
    }

    private void FixedUpdate()
    {
        AnimationLerp();
    }

    private void AnimationLerp()
    {
        if (!isSitting)
        {
            return;
        }

       if( Vector3.Distance(player.transform.position, anchor.transform.position) > 0.1f)
        {
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, anchor.transform.rotation, 0.5f * Time.deltaTime);
            player.transform.position = Vector3.Lerp(player.transform.position, anchor.transform.position, 0.5f * Time.deltaTime);
        }
        else
        {
            player.transform.rotation = anchor.transform.rotation;
            player.transform.position = anchor.transform.position;
        }
    }

    private void AutoWalking()
    {
        Vector3 target = new Vector3(anchor.transform.position.x - player.transform.position.x, 0f, anchor.transform.position.z - player.transform.position.z);
        Quaternion rotation = Quaternion.LookRotation(target);
        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, rotation, 0.05f);

        if (Vector3.Distance(anchor.transform.position, player.transform.position) < 0.9f)
        {
            anim.SetBool("isWalking", false);
            anim.SetFloat("speed", 0);
            anim.SetBool("isSitting", true);
            isAutoWalking = false;
            isSitting = true;
            player.transform.rotation = anchor.transform.rotation;
        }
    }

    private void OnMouseDown()
    {
        Controller controller = player.GetComponent<Controller>();
        if (!isSitting)
        {
            isAutoWalking = true;
            anim.SetBool("isWalking", true);
            anim.SetFloat("speed", 1);
            controller.controlledBy = gameObject;
        }
        else{
            isAutoWalking = false;
            isSitting = false;
            controller.controlledBy = null;
            anim.SetBool("isSitting", false);
        }
    }
}
