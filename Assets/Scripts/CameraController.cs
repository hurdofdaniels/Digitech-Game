using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerPos;
    
    
    public float lerpSpeed = 0.1f;

    public float rotationAmount = 0.0f;

    void LateUpdate()
    {
        cameraLerp();
    }

    private void cameraLerp()
    {
        if (transform.position != playerPos.position)
        {
            transform.position = playerPos.position;
            Quaternion rotationFrom = transform.rotation;
            Quaternion rotationTo = playerPos.rotation;
            transform.rotation = Quaternion.Lerp(rotationFrom, rotationTo, lerpSpeed);

        }
    }
}