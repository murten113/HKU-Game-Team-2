using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwapper : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component
    public Sprite[] sprites; // Array to hold the four possible sprites (up, right, down, left)

    private float lastZRotation;

    void Start()
    {
        // Initialize the lastZRotation to the current Z rotation
        lastZRotation = transform.eulerAngles.z;

        // Set the initial sprite based on the current direction
        UpdateSprite();
    }

    void Update()
    {
        // Get the current Z rotation
        float currentZRotation = transform.eulerAngles.z;

        // Check if the Z rotation has changed by 90 degrees
        if (Mathf.Abs(currentZRotation - lastZRotation) >= 90f)
        {
            UpdateSprite();
            lastZRotation = currentZRotation; // Update the lastZRotation
        }
    }

    void UpdateSprite()
    {
        // Determine the index based on the current rotation
        int currentIndex = GetSpriteIndex();

        // Swap the sprite
        spriteRenderer.sprite = sprites[currentIndex];
    }

    int GetSpriteIndex()
    {
        float angle = transform.eulerAngles.z;

        // Determine the index based on the angle
        if (angle >= 45f && angle < 135f) // Facing right
            return 1;
        else if (angle >= 135f && angle < 225f) // Facing down
            return 2;
        else if (angle >= 225f && angle < 315f) // Facing left
            return 3;
        else // Facing up (default)
            return 0;
    }
}


