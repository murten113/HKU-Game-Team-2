using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform movePoint;

    public LayerMask whatStopsMovement;

    private Vector3 moveDirection; // Stores the direction of movement (forward or backward)
    private bool isMoving; // Keeps track if the player is currently moving

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        moveDirection = Vector3.up; // Initial direction is set to up
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the player towards the target move point
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        // If the player has reached the move point
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            // Start moving when space is pressed (only once)
            if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
            {
                isMoving = true;
            }

            if (isMoving)
            {
                // Check if there's an obstacle in the direction the player is moving
                if (!Physics2D.OverlapCircle(movePoint.position + moveDirection, 0.2f, whatStopsMovement))
                {
                    // Move the player in the current direction
                    movePoint.position += moveDirection;
                }
                else
                {
                    // Hit an obstacle, reverse the direction by 180 degrees
                    moveDirection *= -1;
                    Debug.Log("Hit obstacle, turning around");

                    // Flip sprite based on the movement direction
                    FlipSprite(moveDirection);
                }
            }
        }
    }

    // Method to flip the sprite based on the direction (horizontal or vertical)
    void FlipSprite(Vector3 direction)
    {
        // Horizontal movement (left or right)
        if (direction == Vector3.right || direction == Vector3.left)
        {
            // Rotate 180 degrees around the Y-axis (horizontal flip)
            transform.Rotate(0f, 180f, 0f);
        }
        // Vertical movement (up or down)
        else if (direction == Vector3.up || direction == Vector3.down)
        {
            // Rotate 180 degrees around the X-axis (vertical flip)
            transform.Rotate(180f, 0f, 0f);
        }
    }
}
