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

    public float rotationAmount = 0.0f;
    public float rotationAmountLeft = 0.0f;
    public float rotationAmountRight = 0.0f;
    public bool isLeft = false;

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
        cameraLerp();
        cameraRotation();
    }

    private void cameraLerp()
    {
        if (transform.position != playerPos.position)
        {
            transform.position = playerPos.position;
            Quaternion rotationFrom = transform.rotation;
            Quaternion rotationTo = playerPos.rotation;
            transform.rotation = Quaternion.Lerp(rotationFrom, rotationTo, lerpSpeed);
            lerpToOriginalPosition();
        }
    }

    private void cameraRotation()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            //isLeft = true;
            float tmpRotAmount = rotationSpeed * Time.deltaTime;
            //rotationAmountLeft += tmpRotAmount;
            rotationAmount += tmpRotAmount;
            cameraPos.RotateAround(playerPos.position,
                                    Vector3.up, tmpRotAmount);
        }

        if (Input.GetKey(KeyCode.E))
        {
            //isLeft = false;
            float tmpRotAmount = rotationSpeed * Time.deltaTime;
            //rotationAmountRight += tmpRotAmount;
            rotationAmount -= tmpRotAmount;
            cameraPos.RotateAround(playerPos.position,
                -Vector3.up,
                tmpRotAmount);
        }
    }

    private void lerpToOriginalPosition()
    {
        // LookRotate back to o.g. pos
        /*
         * Quaternion rotationFrom = cameraPos.rotation;
         * Quaternion rotationTo = Quaternion.Euler(new Vector3(27.107f, -2.311f, 0.9030001f));
         * cameraPos.rotation = Quaternion.Lerp(rotationFrom, rotationTo, lerpSpeed);
         */
        
        cameraPos.RotateAround(playerPos.position, Vector3.up, rotationAmount);
    }
}