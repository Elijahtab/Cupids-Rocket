using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    
    public float lifetime = 2f;
    private ScoreController scoreController;

    void Start()
    {
        // Destroy the object after 'lifetime' seconds
        scoreController = GameObject.Find("ScoreController").GetComponent<ScoreController>();
        Destroy(gameObject, lifetime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other GameObject is an enemy
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            scoreController.increaseScore(1);
        }
    }
}
