using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public CharacterController controller;

    public Vector3 playerPos;
    
    public float lerpSpeed;
    
    public LayerMask groundLayer;
    
    public Vector3 playerVelocity;
    public bool groundedPlayer;

    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMovement();
        playerJump();
    }

    void playerJump()
    {
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void playerMovement()
    {
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        move = transform.TransformDirection(move);
        move *= (playerSpeed * Time.deltaTime);

        if (move != Vector3.zero)
        {
            Vector3 lerpTo = Vector3.zero;
            lerpTo.y = Camera.main.transform.rotation.eulerAngles.y;
            Debug.Log(lerpTo);
            gameObject.transform.rotation = Quaternion.Euler(lerpTo);
            
            gameObject.transform.forward = move;
        }
    }

    #region GroundDetection
    private bool IsFloor(Vector3 v) {
        float angle = Vector3.Angle(Vector3.up, v);
        return angle < 35f;
    }
    
    private bool _cancellingGrounded;
    
    private void OnCollisionStay(Collision other) {
        //Make sure we are only checking for walkable layers
        int layer = other.gameObject.layer;
        if (groundLayer != (groundLayer | (1 << layer))) return;

        //Iterate through every collision in a physics update
        for (int i = 0; i < other.contactCount; i++) {
            Vector3 normal = other.contacts[i].normal;
            //FLOOR
            if (IsFloor(normal)) {
                groundedPlayer = true;
                _cancellingGrounded = false;
                CancelInvoke(nameof(StopGrounded));
            }
        }

        //Invoke ground/wall cancel, since we can't check normals with CollisionExit
        float delay = 3f;
        if (!_cancellingGrounded) {
            _cancellingGrounded = true;
            Invoke(nameof(StopGrounded), Time.deltaTime * delay);
        }
    }

    private void StopGrounded() {
        groundedPlayer = false;
    }
    #endregion
}