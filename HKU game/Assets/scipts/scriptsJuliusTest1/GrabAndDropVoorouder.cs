using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaDraggable : MonoBehaviour
{
    public float holdTransparency = 0.5f;  // Transparency when holding the grandma
    public float holdSizeMultiplier = 1.2f;  // Size multiplier when holding the grandma
    public LayerMask stopMovementLayer;    // LayerMask for tiles that block movement

    private bool isHeld = false;          // Whether the grandma is being held
    private Vector3 originalSize;         // Original size of the grandma
    private float originalTransparency;   // Original transparency of the grandma
    private Vector3 originalPosition;     // Original position of the grandma
    private SpriteRenderer spriteRenderer; // Sprite renderer component
    private Collider2D grandmaCollider;   // Collider for the grandma

    // Start is called before the first frame update
    void Start()
    {
        // Get the original size and transparency of the grandma
        spriteRenderer = GetComponent<SpriteRenderer>();
        grandmaCollider = GetComponent<Collider2D>();

        originalSize = transform.localScale;
        originalTransparency = spriteRenderer.color.a;
        originalPosition = transform.position; // Store original position
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is clicking on the grandma
        if (isHeld)
        {
            // Move grandma with the mouse while holding the left mouse button
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);

            // When the player releases the left mouse button, drop the grandma
            if (Input.GetMouseButtonUp(0))
            {
                DropGrandma();
            }
        }
    }

    private void OnMouseDown()
    {
        // Start holding the grandma when left mouse button is pressed
        if (Input.GetMouseButton(0))
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
        float x = Mathf.Floor(rawPosition.x) + 0.5f;  // Use Floor to ensure it snaps to the correct tile
        float y = Mathf.Floor(rawPosition.y) + 0.5f;  // Use Floor to ensure it snaps to the correct tile
        return new Vector3(x, y, transform.position.z);
    }

    // Check if the grandma can be placed on the given position (check for obstacles)
    private bool CanPlaceOnTile(Vector3 position)
    {
        // Check if there's any collider on the stopMovementLayer at the target position
        Collider2D hitCollider = Physics2D.OverlapCircle(position, 0.1f, stopMovementLayer);
        return hitCollider == null;  // Return true if no obstacle is present
    }
}
