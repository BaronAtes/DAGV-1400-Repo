using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager gameManager; // Stores reference to game manager
    public float topBounds = 30.0f;
    public float lowerBounds = -10.0f;
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); // Find Game Manager game object and reference GameManager script component
    }
    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > topBounds)
        {
            Destroy(gameObject);
        }
        else if(transform.position.z < lowerBounds)
        {
            Destroy(gameObject);
            if (gameObject.CompareTag("Enemy"))
            {
                gameManager.isGameOver = true;
            }
        }
    }
}
