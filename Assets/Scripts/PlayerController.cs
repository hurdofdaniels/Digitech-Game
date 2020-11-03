using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public CharacterController controller;
    public Rigidbody playerRigidbody;

    public float lerpSpeed;
    
    public LayerMask groundLayer;
    
    public Vector3 movementDirection = Vector3.zero;
    public bool groundedPlayer;

    public float playerSpeed = 5f;
    public float playerRotationSpeed = 2f;
    public float playerJumpSpeed = 8f;
    public float gravityValue = 20;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        playerRigidbody = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        groundedPlayer = controller.isGrounded;
        Vector3 inputMovement = transform.forward * playerSpeed * Input.GetAxisRaw("Vertical");
        controller.Move(inputMovement * Time.deltaTime);

        transform.Rotate(Vector3.up * Input.GetAxisRaw("Horizontal") * playerRotationSpeed);


        //jumping
        if(Input.GetButton("Jump") && groundedPlayer)
        {
            movementDirection.y = playerJumpSpeed;
        }
        movementDirection.y -= gravityValue * Time.deltaTime;

        controller.Move(movementDirection * Time.deltaTime);
    }
    
    // Update is called once per frame
    /*void FixedUpdate()
    {
        playerMovement();
        playerJump();
    }*/

    void playerJump()
    {
        
    }

    void playerMovement()
    {
        
    }

    /*
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
    */
}