using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform playerPos;
    
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = playerPos.position;
    }
}
