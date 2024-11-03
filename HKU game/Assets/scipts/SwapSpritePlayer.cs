using UnityEngine;

public class DirectionalSpriteController : MonoBehaviour
{
    // Public references to sprites for each direction
    public SpriteRenderer spriteRenderer;  // Reference to the SpriteRenderer component
    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteLeft;
    public Sprite spriteRight;

    // Store the last position to calculate movement direction
    private Vector2 lastPosition;

    private void Start()
    {
        // Initialize lastPosition to the GameObject's starting position
        lastPosition = transform.position;

        // Ensure a spriteRenderer is assigned
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            if (spriteRenderer == null)
            {
                Debug.LogError("SpriteRenderer component is missing on this GameObject.");
            }
        }
    }

    private void Update()
    {
        // Calculate movement direction
        Vector2 currentPosition = transform.position;
        Vector2 movementDirection = currentPosition - lastPosition;

        // Determine which sprite to display based on movement direction
        if (movementDirection.x != 0 || movementDirection.y != 0)  // Check if movement occurred
        {
            if (Mathf.Abs(movementDirection.x) > Mathf.Abs(movementDirection.y))
            {
                // Moving horizontally
                spriteRenderer.sprite = movementDirection.x > 0 ? spriteRight : spriteLeft;
            }
            else
            {
                // Moving vertically
                spriteRenderer.sprite = movementDirection.y > 0 ? spriteUp : spriteDown;
            }
        }

        // Update lastPosition for the next frame
        lastPosition = currentPosition;
    }
}
