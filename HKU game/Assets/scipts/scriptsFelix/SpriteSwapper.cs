using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwapper : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component
    public Sprite[] sprites; // Array to hold the four possible sprites

    private float lastZRotation;

    void Start()
    {
        // Initialize the lastZRotation to the current Z rotation
        lastZRotation = transform.eulerAngles.z;
    }

    void Update()
    {
        // Get the current Z rotation
        float currentZRotation = transform.eulerAngles.z;

        // Check if the Z rotation has changed by 90 degrees
        if (Mathf.Abs(currentZRotation - lastZRotation) >= 90f)
        {
            SwapSprite();
            lastZRotation = currentZRotation; // Update the lastZRotation
        }
    }

    void SwapSprite()
    {
        // Determine the index of the current sprite
        int currentIndex = System.Array.IndexOf(sprites, spriteRenderer.sprite);

        // Calculate the next index in a circular manner
        int nextIndex = (currentIndex + 1) % sprites.Length;

        // Swap the sprite
        spriteRenderer.sprite = sprites[nextIndex];
    }
}

