using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleMovement : MonoBehaviour
{
    private float moleHeight;
    // Start is called before the first frame update
    void Start()
    {
        moleHeight = GetComponent<BoxCollider>().size.y;
        StartCoroutine(Behaviour());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        // Sets the player as being on the ground if they touch the ground object
        if (other.gameObject.CompareTag("Ground"))
        {
            Physics.IgnoreCollision(other.collider, GetComponent<MeshCollider>());
        }
    }

    private IEnumerator Behaviour()
    {
        WaitForSeconds waitTime = new WaitForSeconds(4);
        while (true)
        {
            yield return waitTime;
            transform.Translate(Vector3.up * moleHeight);
            yield return waitTime;
            transform.Translate(Vector3.up  * -moleHeight);
        }
    }
}
