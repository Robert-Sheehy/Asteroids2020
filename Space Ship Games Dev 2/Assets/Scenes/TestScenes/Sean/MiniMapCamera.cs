using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{
    private Transform PlayerTransform;
    private float yoffset;

  
    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 targetPosition = PlayerTransform.position;
        targetPosition.y += yoffset;
        transform.position = targetPosition;
    }
}
