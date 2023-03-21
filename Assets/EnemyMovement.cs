using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        // Get a reference to the enemy's Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        // Set the initial velocity to move the enemy from right to left
        rb.velocity = new Vector2(-moveSpeed, 0);
        transform.Rotate(0f, 0f, 90f);

    }

    void Update()
    {
        // No need for extra movement logic since we're just moving in a straight line
    }
}