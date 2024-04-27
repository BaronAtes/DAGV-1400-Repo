using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public ScoreManager scoreManager; // Stores reference to score manager
    public int scoreToGive;
    public GameObject explosionParticle;
    public GameObject audioSource;
    public AudioClip explodeSound;
    private AudioSource globalAudio;

    void Start()
    {
        scoreManager = GameObject.Find("Score Manager").GetComponent<ScoreManager>(); // Find ScoreManager game object and reference ScoreManager script component\
        globalAudio = GameObject.Find("Global Audio").GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other) // Once the trigger has been entered, record collision in the object variable "other"
    {
        if (other.CompareTag("Laser")) // Checks if the object collided with is a laser, otherwise do not run the following code
        {
            globalAudio.PlayOneShot(explodeSound, 1.0f);
            Instantiate(explosionParticle, gameObject.transform.position, explosionParticle.transform.rotation);
            scoreManager.IncreaseScore(scoreToGive); // Increase the score
            Destroy(other.gameObject); // Destroy other game object
            Destroy(gameObject); // Destroy this game object
        }
    }
}
