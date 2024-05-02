using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;


public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager;
    private Rigidbody playerRb;
    private float speed = 30f;
    private float turnSpeed = 75f;
    private float horizontalInput;
    private float forwardInput;
    private Quaternion curRot;
    public bool isOnGround  = false;
    public int health;
    public int mailBoxes = 0;
    public int coins = 0;
    public int dmgValue;
    public float deathThrow;
    public bool hasPowerUp = false;
    public GameObject powerUpIndicator;
    private GameObject selectRing;
    public TextMeshProUGUI healthText;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        healthText.text = "Health: " + health;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        curRot = transform.rotation;
        // Checks if the player is on the ground, and if so, allows them to move
        if (isOnGround == true && gameManager.isGameOver == false)
        {
            // Forwards and backwards movement
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            // Turning
            transform.Rotate(Vector3.up, turnSpeed *  horizontalInput * Time.deltaTime);
        }
        if (transform.position.y >= 3)
        {
            isOnGround = false;
        }
        if (transform.position.y < -10) // Failsafe in case the player falls out of bounds
        {
            gameManager.isGameOver = true;
            Debug.Log("Game over!");
        }
        if (health <= 0)
        {
            gameManager.isGameOver = true;
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
            if (hasPowerUp)
            {
                Destroy(other.gameObject);
                gameManager.UpdateScore(10);
            }
            else
            {
                health = health - dmgValue;
                healthText.text = "Health: " + health;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Increments the number of coins if the player touches a coin
        if (other.gameObject.CompareTag("Coin"))
        {
            coins ++;
            gameManager.UpdateScore(10);
            Destroy(other.gameObject);
            Debug.Log("Number of coins: " + coins);
        }
        // Increments the number of mailboxes if the player touches a mailbox
        else if (other.gameObject.CompareTag("Mailbox"))
        {
            selectRing = other.gameObject.transform.Find("SelectionRing_02").gameObject;
            mailBoxes ++;
            gameManager.UpdateScore(25);
            Debug.Log("Mailboxes delivered to: " + mailBoxes);
            selectRing.gameObject.SetActive(false);
            other.tag = "Filled Mailbox";
        }
        else if (other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            gameManager.UpdateScore(5);
            StartCoroutine(PowerupCountdownRoutine ());
            powerUpIndicator.gameObject.SetActive(true);
        }
    }
    IEnumerator PowerupCountdownRoutine ()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
        Debug.Log("Powerup time had ended.");
    }
}
