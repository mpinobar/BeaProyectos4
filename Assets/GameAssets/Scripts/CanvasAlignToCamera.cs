using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasAlignToCamera : MonoBehaviour
{
    Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.forward = -cameraTransform.forward;
    }
}
