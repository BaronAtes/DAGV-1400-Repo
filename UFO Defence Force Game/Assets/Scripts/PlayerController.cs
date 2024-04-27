using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 25;
    public float xRange = 30;
    public Transform blaster;
    public GameObject laserBolt;
    public int oreCount = 0;
    public GameManager gameManager;
    public ScoreManager scoreManager; // Stores reference to score manager
    public int scoreToGive;
    public AudioClip shootSound;
    public AudioClip collectSound;
    private AudioSource playerAudio;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); // Find Game Manager game object and reference GameManager script component
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>(); // Find ScoreManager game object and reference ScoreManager script component
        playerAudio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        // Initializes horizontal input
        horizontalInput = Input.GetAxis("Horizontal"); 
        // Moves player left and right
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        // Keep player in bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        // If space bar is pressed, fire laser bolt
        if (Input.GetKeyDown(KeyCode.Space) && gameManager.isGameOver == false)
        {
            playerAudio.PlayOneShot(shootSound, 1.0f);
            // Create laserBolt at the blaster transform position while maintaining the object's rotation.
            Instantiate(laserBolt, blaster.transform.position, laserBolt.transform.rotation);
        }
    }

    // Delete any object with a trigger that hits the player
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ore"))
        {
            playerAudio.PlayOneShot(collectSound, 1.0f);
            scoreManager.IncreaseScore(scoreToGive);
            oreCount++;
            Destroy(other.gameObject);
            Debug.Log("Ore collected: " + oreCount);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
