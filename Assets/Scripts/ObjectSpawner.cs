using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectPrefabs;
    public float spawnInterval = 1.0f;
    public float screenWidth = 16.0f;
    public float descentSpeed = 0.5f;
    [SerializeField] GameObject limit;
    public float timeToSpawn = 120f;

    void Start()
    {
        InvokeRepeating("SpawnObject", spawnInterval, spawnInterval);
        Invoke("StopSpawningAndDestroyLimit", timeToSpawn); // Stop spawning after 60 seconds
    }

    void SpawnObject()
    {
        int randomIndex = Random.Range(0, objectPrefabs.Length);
        GameObject objectPrefab = objectPrefabs[randomIndex];
        Vector3 spawnPos = new Vector3(Random.Range(-screenWidth /*/ 2*/, screenWidth /*/ 2*/), transform.position.y, 0);
        GameObject newObject = Instantiate(objectPrefab, spawnPos, Quaternion.identity) as GameObject;
        newObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -descentSpeed);
    }

    void StopSpawningAndDestroyLimit()
    {
        CancelInvoke("SpawnObject"); // Stop spawning
        if (limit != null)
        {
            Destroy(limit); // Destroy the limit object
        }
    }
}
