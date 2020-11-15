using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlentTreeController : MonoBehaviour {

    float speed = 1.0f;
    float rotationSpeed = 100.0f;
    Animator anim;
    float currentSpeed = 0.0f;
   

    void Start() {

        anim = GetComponent<Animator>();
    }
    
    void Update() {

        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        currentSpeed += translation;     

        anim.SetFloat("speed",currentSpeed);


        transform.Rotate(0.0f, rotation, 0.0f);

        if(translation != 0) {

            anim.SetBool("isWalking", true);
        } else {

            anim.SetBool("isWalking", false);
            currentSpeed = 0;
        }
    }
}
