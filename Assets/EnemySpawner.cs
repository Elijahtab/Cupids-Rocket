using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnIntervalMin = 0f;
    public float spawnIntervalMax = 5f;
    public float spawnIntervalMaxReal = 5f;

    private float spawnTimer = 0f;
    private ScoreController scoreController;

    void Start()
    {
        scoreController = GameObject.Find("ScoreController").GetComponent<ScoreController>();
    }

    void Update()
    {
        // Update the spawn timer
        spawnTimer += Time.deltaTime;

        spawnIntervalMaxReal = 1 + (spawnIntervalMax / (scoreController.score + 1));
        // Check if it's time to spawn a new enemy
        if (spawnTimer >= Random.Range(spawnIntervalMin, spawnIntervalMaxReal))
        {
            // Reset the spawn timer
            spawnTimer = 0f;

            // Set the random Y position within a specified range
            float yPosition = Random.Range(-5f, 5f);

            // Spawn a new enemy at the random Y position
            Vector3 spawnPosition = new Vector3(transform.position.x, yPosition, transform.position.z);
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            
        }
    }
}