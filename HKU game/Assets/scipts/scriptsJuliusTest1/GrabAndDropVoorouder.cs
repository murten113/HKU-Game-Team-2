using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaDraggable : MonoBehaviour
{
    public float holdTransparency = 0.5f;      // Transparency when holding the grandma
    public float holdSizeMultiplier = 1.2f;    // Size multiplier when holding the grandma
    public LayerMask stopMovementLayer;        // LayerMask for tiles that block movement

    public AudioClip placeSound;               // Sound clip to play when placing grandma
    public float placeSoundVolume = 1f;        // Volume of the place sound

    private bool isHeld = false;               // Whether the grandma is being held
    private bool isLocked = false;             // Whether movement is locked after pressing spacebar
    private Vector3 originalSize;              // Original size of the grandma
    private float originalTransparency;        // Original transparency of the grandma
    private Vector3 originalPosition;          // Original position of the grandma
    private SpriteRenderer spriteRenderer;     // Sprite renderer component
    private Collider2D grandmaCollider;        // Collider for the grandma
    private AudioSource audioSource;           // AudioSource to play sound effects

    void Start()
    {
        // Get the original size and transparency of the grandma
        spriteRenderer = GetComponent<SpriteRenderer>();
        grandmaCollider = GetComponent<Collider2D>();

        originalSize = transform.localScale;
        originalTransparency = spriteRenderer.color.a;
        originalPosition = transform.position;

        // Initialize AudioSource component for playing the place sound
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = placeSound;
        audioSource.volume = placeSoundVolume;
    }

    void Update()
    {
        // Check if spacebar has been pressed to lock movement
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isLocked = true;
            isHeld = false;  // Drop grandma if held
        }

        // Move grandma with mouse if it is held and movement is not locked
        if (isHeld && !isLocked)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);

            // Drop grandma when left mouse button is released
            if (Input.GetMouseButtonUp(0))
            {
                DropGrandma();
            }
        }
    }

    private void OnMouseDown()
    {
        // Start holding the grandma if movement is not locked and left mouse button is pressed
        if (!isLocked && Input.GetMouseButton(0))
        {
            GrabGrandma();
        }
    }

    private void GrabGrandma()
    {
        // Make the grandma slightly transparent and bigger
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, holdTransparency);
        transform.localScale = originalSize * holdSizeMultiplier;

        // Disable collisions while the grandma is being held
        grandmaCollider.enabled = false;

        // Store the original position before moving
        originalPosition = transform.position;

        isHeld = true;
    }

    private void DropGrandma()
    {
        // Snap the grandma to the center of the tile where the mouse is hovering
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 gridPosition = SnapToGrid(mousePosition);

        // Check if the new position has a blocking tile on the "StopMovement" layer
        if (!CanPlaceOnTile(gridPosition))
        {
            // If there's an obstacle, return the grandma to the original position
            transform.position = originalPosition;
        }
        else
        {
            // Place the grandma on the grid if no obstacle is present
            transform.position = gridPosition;

            // Play the placement sound at the specified volume
            PlayPlaceSound();
        }

        // Return the grandma to her original size and transparency
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, originalTransparency);
        transform.localScale = originalSize;

        // Re-enable collisions after dropping the grandma
        grandmaCollider.enabled = true;

        isHeld = false;
    }

    // Snap position to the center of the tile the mouse is over (assumes grid size is 1 unit)
    private Vector3 SnapToGrid(Vector3 rawPosition)
    {
        float x = Mathf.Floor(rawPosition.x) + 0.5f;
        float y = Mathf.Floor(rawPosition.y) + 0.5f;
        return new Vector3(x, y, transform.position.z);
    }

    // Check if the grandma can be placed on the given position (check for obstacles)
    private bool CanPlaceOnTile(Vector3 position)
    {
        Collider2D hitCollider = Physics2D.OverlapCircle(position, 0.1f, stopMovementLayer);
        return hitCollider == null;
    }

    // Play the placement sound
    private void PlayPlaceSound()
    {
        if (audioSource != null && placeSound != null)
        {
            audioSource.PlayOneShot(placeSound, placeSoundVolume);
        }
    }
}
