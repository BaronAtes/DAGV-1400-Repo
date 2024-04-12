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
    // Start is called before the first frame update

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Create laserBolt at the blaster transform position while maintaining the object's rotation.
            Instantiate(laserBolt, blaster.transform.position, laserBolt.transform.rotation);
        }
    }

    // Delete any object with a trigger that hits the player
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ore"))
        {
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
