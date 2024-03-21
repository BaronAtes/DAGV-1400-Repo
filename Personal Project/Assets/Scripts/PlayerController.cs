using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 20f;
    private float turnSpeed = 75f;
    private float horizontalInput;
    private float forwardInput;
    private Quaternion curRot;
    public bool isOnGround  = false;
    public int health;
    public int mailBoxes = 0;
    public int coins = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        curRot = transform.rotation;
        // Checks if the player is on the ground, and if so, allows them to move
        if (isOnGround == true)
        {
            // Forwards and backwards movement
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            // Turning
            transform.Rotate(Vector3.up, turnSpeed *  horizontalInput * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Sets the player as being on the ground if they touch the ground object
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        // Makes the player lose health if they collide with an obstacle
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            health --;
            Debug.Log("Imma add the HUD later, but for now, here's this message!");
        }
        // Increments the number of mailboxes if the player touches a mailbox
        else if (collision.collider.CompareTag("Mailbox"))
        {
            mailBoxes ++;
            Debug.Log("Imma add the the HUD later, but for now, here's this message!");
        }
        // Increments the number of coins if the player touches a coin
        else if (collision.gameObject.CompareTag("Coin"))
        {
            coins ++;
            Debug.Log("Imma add the HUD later, but for now, here's this message!");
        }
    }
}
