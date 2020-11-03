using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform cameraPos;
    public Transform playerPos;
    public float lerpSpeed = 0.1f;
    public float rotationSpeed = 20.0f;

    void Start()
    {
        
    }

    void Update()
    {
        /*
         * transform.position = playerPos.position;
         */
    }

    void FixedUpdate()
    {
        //transform.rotation = playerPos.rotation;

        /*
         * Quaternion rotationFrom = transform.rotation;
         * Quaternion rotationTo = playerPos.rotation;
         * transform.rotation = Quaternion.Lerp(rotationFrom, rotationTo, lerpSpeed);
         */
    }

    void LateUpdate()
    {
        if (transform.position != playerPos.position)
            transform.position = playerPos.position;
            Quaternion rotationFrom = transform.rotation;
            Quaternion rotationTo = playerPos.rotation;
            transform.rotation = Quaternion.Lerp(rotationFrom, rotationTo, lerpSpeed);
        
        
        if (Input.GetKey(KeyCode.Q))
            cameraPos.RotateAround(playerPos.position, 
                                    Vector3.up, 
                                    rotationSpeed * Time.deltaTime);
        
        if (Input.GetKey(KeyCode.E))
            cameraPos.RotateAround(playerPos.position, 
                                    -Vector3.up, 
                                    rotationSpeed * Time.deltaTime);
    }
}
