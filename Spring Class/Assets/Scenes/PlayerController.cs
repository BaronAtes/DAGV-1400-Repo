using System.Collections;
using System.Collections.Generic;
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
    void Start()
    {
        pc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        moveDirection.x = horizontalInput * moveSpeed;
        moveDirection.z = verticalInput * moveSpeed;
        moveDirection.y = moveDirection.y - (gravity * Time.deltaTime);
        if (Input.GetButtonDown("Jump"))
        {
            if (pc.isGrounded == true)
            {
                isJumping = true;
            }
        }
        if (isJumping == true)
        {
            moveDirection.y = jumpForce;
            isJumping = false;
        }
        pc.Move(moveDirection * Time.deltaTime);
    }
}
