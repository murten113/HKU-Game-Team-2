using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaDraggable : MonoBehaviour
{
    public float holdTransparency = 0.5f;  // Transparency when holding the grandma
    public float holdSizeMultiplier = 1.2f;  // Size multiplier when holding the grandma

    private bool isHeld = false;          // Whether the grandma is being held
    private Vector3 originalSize;         // Original size of the grandma
    private float originalTransparency;   // Original transparency of the grandma
    private SpriteRenderer spriteRenderer; // Sprite renderer component
    private Collider2D grandmaCollider;   // Collider for the grandma

    private Vector3 offset;               // Offset to keep grandma centered under the mouse

    // Start is called before the first frame update
    void Start()
    {
        // Get the original size and transparency of the grandma
        spriteRenderer = GetComponent<SpriteRenderer>();
        grandmaCollider = GetComponent<Collider2D>();

        originalSize = transform.localScale;
        originalTransparency = spriteRenderer.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is clicking on the grandma
        if (isHeld)
        {
            // Move grandma with the mouse while holding the left mouse button
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z) + offset;

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

        // Calculate offset to keep the grandma centered under the mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mousePosition.x, mousePosition.y, transform.position.z);

        isHeld = true;
    }

    private void DropGrandma()
    {
        // Snap the grandma to the center of the tile
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 gridPosition = SnapToGrid(mousePosition);
        transform.position = gridPosition;

        // Return the grandma to her original size and transparency
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, originalTransparency);
        transform.localScale = originalSize;

        // Re-enable collisions after dropping the grandma
        grandmaCollider.enabled = true;

        isHeld = false;
    }

    // Snap position to nearest tile center (assumes grid size is 1 unit)
    private Vector3 SnapToGrid(Vector3 rawPosition)
    {
        float x = Mathf.Round(rawPosition.x);
        float y = Mathf.Round(rawPosition.y);
        return new Vector3(x, y, transform.position.z);
    }
}
