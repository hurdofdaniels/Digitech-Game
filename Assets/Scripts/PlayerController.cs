using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public CharacterController controller;

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
    }

    void FixedUpdate()
    {
        // Player Movement Logic
        PlayerMovement();
        // Player Jumping Logic
        PlayerJumping();
    }

    void PlayerMovement()
    {
        groundedPlayer = controller.isGrounded;
        Vector3 inputMovement = transform.forward * playerSpeed * Input.GetAxisRaw("Vertical");
        controller.Move(inputMovement * Time.deltaTime);

        transform.Rotate(Vector3.up * Input.GetAxisRaw("Horizontal") * playerRotationSpeed);
    }

    void PlayerJumping()
    {
        if(Input.GetButton("Jump") && groundedPlayer)
        {
            movementDirection.y = playerJumpSpeed;
        }
        movementDirection.y -= gravityValue * Time.deltaTime;

        controller.Move(movementDirection * Time.deltaTime);
    }
}