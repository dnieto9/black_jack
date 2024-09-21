using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    public GameObject startingSprite; // The sprite to use as the starting position
    public GameObject[] sprites; // Array of sprite GameObjects
    public float speed = 2.0f; // Speed of the animation
    public float randomRange = 5.0f; // Range for random direction
    private Vector3[] directions; // Array to store random directions

    private void Start()
    {
        // Initialize directions and set initial positions
        directions = new Vector3[sprites.Length];

        // Get the starting position from the specified sprite
        Vector3 startingPosition = startingSprite.transform.position;

        for (int i = 0; i < sprites.Length; i++)
        {
            // Set the initial position of each sprite
            sprites[i].transform.position = startingPosition;

            // Generate a random direction
            float randomX = Random.Range(-randomRange, randomRange);
            float randomY = Random.Range(-randomRange, randomRange);
            directions[i] = new Vector3(randomX, randomY, 0).normalized; // Normalize for consistent speed
        }
    }

    private void Update()
    {
        // Move each sprite in its assigned random direction
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].transform.position += directions[i] * speed * Time.deltaTime;
        }
    }


    
}
