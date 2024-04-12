using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    // Start is called before the first frame update
    public float topBounds = 30.0f;
    public float lowerBounds = -10.0f;

    void Awake()
    {
        //Time.timeScale = 1;
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
                Debug.Log("Game Over!");
                //Time.timeScale = 0;
            }
        }
    }
}
