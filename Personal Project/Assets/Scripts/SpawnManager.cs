using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[ ] objectPrefabs;
    private float startDelay = 2;
    private float repeatRate = 2;
    private float spawnRange = 20;
    private float spawnInterval = 1.5f;
    private int objIndex;
    // Start is called before the first frame update
    void Start()
    {
        SpawnObject(7);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObject(int objectsToSpawn)
    {
        for (int i = 0; i < objectsToSpawn; i++)
        {
            objIndex = Random.Range(0, objectPrefabs.Length);
            Instantiate(objectPrefabs[objIndex], GenerateSpawnPosition(), objectPrefabs[objIndex].transform.rotation);
        }
    }
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, objectPrefabs[objIndex].transform.position.y, spawnPosZ);
        return randomPos;
    }
}
