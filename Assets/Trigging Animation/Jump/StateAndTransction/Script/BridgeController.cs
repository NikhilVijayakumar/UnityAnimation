using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeController : MonoBehaviour
{

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        GameObject dynamicBridge = GameObject.Find("DynamicBridge");
        
        if(dynamicBridge != null)
        {
            print("dynamicBridge not null");
            animator = dynamicBridge.gameObject.GetComponent<Animator>();
        }
        else
        {
            print("dynamicBridge null");
        }
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (animator != null)
        {
            print("OnTriggerEnter isOpened false");
            animator.SetBool("isOpened", false);
        }
        else
        {
            print("OnTriggerEnter animator null");
        }
     
    }

    private void OnTriggerExit(Collider other)
    {
        if (animator != null)
        {
            print("OnTriggerExit isOpened true");
            animator.SetBool("isOpened", true);
        }
        else
        {
            print("OnTriggerExit animator null");
        }

    }
}
