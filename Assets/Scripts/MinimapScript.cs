using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapScript : MonoBehaviour
{

    public Transform playerTransform;

    public float lerpSpeed;
    public float panSpeed = 20f;

    public Vector2 panLimit;
    
    public void Update()
    {
        
        Vector3 pos = playerTransform.position * (panSpeed * Time.deltaTime);

        pos.x = Mathf.Clamp(pos.x, -panLimit.x, panLimit.x);
        pos.z = Mathf.Clamp(pos.z, -panLimit.y, panLimit.y);

        Vector3 currentPos = transform.position;
        
        transform.position = Vector3.Lerp(currentPos, pos, lerpSpeed);
    }

    /*public Transform player;

    void LateUpdate()
    {
        Vector3 newPosition = player.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }*/
}
