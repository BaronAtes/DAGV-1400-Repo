using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float xBound = 30;
    private float yBound = -5;
    private float zBound = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > xBound || transform.position.x < -xBound)
        {
            Destroy(gameObject);
        }

        else if (transform.position.z < yBound)
        {
            Destroy(gameObject);
        }

        else if (transform.position.x > zBound || transform.position.x < -zBound)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        // Sets the player as being on the ground if they touch the ground object
        if (other.gameObject.CompareTag("Building"))
        {
            Destroy(gameObject);
        }
    }
}
