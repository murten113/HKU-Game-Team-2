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

        // Check if the object is moving in a specific direction
        if (movementDirection.magnitude > 0.01f)  // Ensure some movement happened
        {
            if (Mathf.Abs(movementDirection.x) > Mathf.Abs(movementDirection.y))
            {
                // Moving left or right
                if (movementDirection.x > 0)
                {
                    spriteRenderer.sprite = spriteRight;
                }
                else
                {
                    spriteRenderer.sprite = spriteLeft;
                }
            }
            else
            {
                // Moving up or down
                if (movementDirection.y > 0)
                {
                    spriteRenderer.sprite = spriteUp;
                }
                else
                {
                    spriteRenderer.sprite = spriteDown;
                }
            }
        }

        // Update lastPosition for the next frame
        lastPosition = currentPosition;
    }
}
