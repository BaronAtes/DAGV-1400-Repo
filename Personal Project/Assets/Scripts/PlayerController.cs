using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody playerRb;
    private float speed = 20f;
    private float turnSpeed = 75f;
    private float horizontalInput;
    private float forwardInput;
    private Quaternion curRot;
    public bool isOnGround  = false;
    public int health;
    public int mailBoxes = 0;
    public int coins = 0;
    public int dmgValue;
    private bool gameOver = false;
    public float deathThrow;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        curRot = transform.rotation;
        // Checks if the player is on the ground, and if so, allows them to move
        if (isOnGround == true && gameOver == false)
        {
            // Forwards and backwards movement
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            // Turning
            transform.Rotate(Vector3.up, turnSpeed *  horizontalInput * Time.deltaTime);
        }
        if (transform.position.y >= 1)
        {
            isOnGround = false;
        }
        if (health <= 0)
        {
            gameOver = true;
            playerRb.AddForce(Vector3.up * deathThrow);
            Debug.Log("Game over!");
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        // Sets the player as being on the ground if they touch the ground object
        if (other.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        // Makes the player lose health if they collide with an obstacle
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            health = health - dmgValue;
            Debug.Log("Current health: " + health);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Increments the number of coins if the player touches a coin
        if (other.gameObject.CompareTag("Coin"))
        {
            coins ++;
            Destroy(other.gameObject);
            Debug.Log("Number of coins: " + coins);
        }
        // Increments the number of mailboxes if the player touches a mailbox
        else if (other.gameObject.CompareTag("Mailbox"))
        {
            mailBoxes ++;
            Debug.Log("Mailboxes delivered to: " + mailBoxes);
            other.tag = "Filled Mailbox";
        }
    }
}
