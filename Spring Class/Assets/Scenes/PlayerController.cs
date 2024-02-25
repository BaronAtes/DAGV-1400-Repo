using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float gravity = 9.81f;
    private CharacterController pc;
    private Vector3 moveDirection;
    private bool isJumping;
    private float horizontalInput;
    private float verticalInput;
    private float playerRotat;
    private bool isCrouching;
    private bool isSprinting;
    void Start()
    {
        pc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal"); //Initializes horizontal input
        verticalInput = Input.GetAxis("Vertical"); //Initialized vertical input
        if (isCrouching == true) //If the player is crouching, divide their move speed by 2
        {
            moveDirection.x = horizontalInput * (moveSpeed / 2);
            moveDirection.z = verticalInput * (moveSpeed / 2);
        }
        else if (isSprinting == true) //If the player is sprinting, multiply their move speed by 2
        {
            moveDirection.x = horizontalInput * (moveSpeed * 2);
            moveDirection.z = verticalInput * (moveSpeed * 2);
        }
        else //default movement speed
        {
            moveDirection.x = horizontalInput * moveSpeed;
            moveDirection.z = verticalInput * moveSpeed;
        }
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime); //Establishes how gravity affects the player
        if (Input.GetButtonDown("Jump"))
        {
            if (isCrouching == false) //Makes sure the player is not crouching, as they cannot jump if so
            {
                if (pc.isGrounded == true) //Makes sure the player is on the ground before letting them jump
                {
                    isJumping = true;
                }
            }
        }
        if (isJumping == true)
        {
            moveDirection.y = jumpForce; //Moves the player upwards equal to the jump force value
            isJumping = false; //Forces the player to stop going upwards
        }
        if (Input.GetButton("Fire3"))
        {
            if (pc.isGrounded == true) //Makes sure that the player is grounded before they are able to crouch
            {
                isCrouching = true; //Tells the machine that the player is crouching
                gameObject.transform.localScale = new Vector3(1.0f, 0.75f, 1.0f); //When the player crouches, their character becomes shorter
            }
        }
        else
        {
            isCrouching = false; //Resets the crouching value when the player is not holding the shift key
            gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f); //Resets the player's size when they are not holding the shift key
        }
        if (Input.GetButton("Fire1"))
        {
            if (pc.isGrounded == true) //Makes sure that the player is grounded before they are able to dash
            {
                isSprinting = true; //Tells the machine that the player is sprinting
            }
        }
        else
        {
            isSprinting = false; //Resets the sprinting value when the player is not holding the shift key
        }
        pc.Move(moveDirection * Time.deltaTime); //Moves the player depending on their direction
    }
}
