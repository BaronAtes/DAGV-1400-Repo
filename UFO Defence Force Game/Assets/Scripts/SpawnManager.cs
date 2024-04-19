using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] ufoPrefabs; // Array to store spawnable objects
    public GameObject ore; // Stores the collectable object
    private float spawnRangeX = 20.0f;
    private float spawnPosZ = 20.0f;
    private float startDelay = 2.0f;
    private float spawnInterval = 1.5f;
    public int enemyCount;
    private float spawnDelay;
    void Start()
    {
        spawnDelay = Random.Range(startDelay * 3, startDelay * 7);
        InvokeRepeating("SpawnRandomUFO", startDelay, spawnInterval);
        InvokeRepeating("SpawnCollectable", startDelay, spawnDelay);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomUFO()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        int ufoIndex = Random.Range(0, ufoPrefabs.Length); // Picks a random UFO from the array
        Instantiate(ufoPrefabs[ufoIndex], spawnPos, ufoPrefabs[ufoIndex].transform.rotation); // Spawns indexed UFO from array on a random position on the X axis
    }

    void SpawnCollectable()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        spawnDelay = Random.Range(startDelay * 3, startDelay * 7);
        CountDown(spawnDelay);
        Instantiate(ore, spawnPos, ore.transform.rotation); // Spawns indexed collectable on a random position on the X axis
    }

    IEnumerator CountDown(float timeMultiplier)
    {
        yield return new WaitForSeconds(spawnInterval * timeMultiplier);
    }
}
