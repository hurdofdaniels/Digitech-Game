using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapScript : MonoBehaviour
{

    public Transform playerTransform;

    public void Update()
    {
        //transform.position = new Vector3(playerTransform.position.x, 18.35f, playerTransform.position.z) * (panSpeed * Time.deltaTime);
    }

    //public Transform player;

    void LateUpdate()
    {
        transform.position = new Vector3(playerTransform.position.x, 18.35f, playerTransform.position.z) * Time.deltaTime;
    }
}
