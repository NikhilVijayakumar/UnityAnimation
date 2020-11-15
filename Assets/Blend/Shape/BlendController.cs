using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendController : MonoBehaviour
{

    private SkinnedMeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float inflat = Input.GetAxis("Vertical");
        meshRenderer.SetBlendShapeWeight(0, inflat * 100);
    }
}
