using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorisController : MonoBehaviour
{
    SkinnedMeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float eyeClosed = Input.GetAxis("Vertical") * 100;
        float eyeOpened = Input.GetAxis("Horizontal") * 100;
        float mouth = Input.mousePosition.y / 2;

        meshRenderer.SetBlendShapeWeight(0, eyeClosed);
        meshRenderer.SetBlendShapeWeight(1, eyeOpened);
        meshRenderer.SetBlendShapeWeight(2, mouth);


    }
}
