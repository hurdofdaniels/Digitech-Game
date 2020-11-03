using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform playerPos;
    public float lerpSpeed = 0.1f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = playerPos.position;
    }

    void FixedUpdate()
    {
        //transform.rotation = playerPos.rotation;

        Quaternion rotationFrom = transform.rotation;
        Quaternion rotationTo = playerPos.rotation;

        transform.rotation = Quaternion.Lerp(rotationFrom, rotationTo, lerpSpeed);
    }
}
