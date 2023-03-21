using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawner : MonoBehaviour
{

    public ScoreController sc;
    int score;
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other GameObject is an enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            score = 1;
            Destroy(other.gameObject);
            sc.increaseScore(score);
        }
    }
}