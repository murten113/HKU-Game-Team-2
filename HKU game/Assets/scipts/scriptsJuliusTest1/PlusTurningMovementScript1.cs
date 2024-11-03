using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController4 : MonoBehaviour
{
    public float moveSpeed = 5f;                  // Speed of movement
    public Transform movePoint;                   // The point towards which the player moves

    public LayerMask whatStopsMovement;           // Layer mask to define what blocks movement
    public LayerMask turnPlayerLayer;             // Layer mask for "TurnPlayer" objects like grandma

    public AudioClip stopMovementClip;            // Sound for hitting a stop movement point
    public float stopMovementVolume = 1f;         // Volume for stop movement sound
    public AudioClip turnPlayerClip;              // Sound for hitting a turn player point
    public float turnPlayerVolume = 1f;           // Volume for turn player sound

    private Vector3 moveDirection;                // Current movement direction
    private bool isMoving;                        // Tracks if the player is currently moving
    private AudioSource audioSource;              // AudioSource component to play sounds

    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;                  // Detach movePoint from the player
        moveDirection = Vector3.up;               // Initial movement direction is upward
        isMoving = false;

        // Initialize AudioSource component
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the player towards the movePoint
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        // If the player reaches the movePoint
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            // Start movement when space is pressed and the player isn't moving
            if (Input.GetKeyDown(KeyCode.Space) && !isMoving)
            {
                isMoving = true;
            }

            if (isMoving)
            {
                // Check if there's an obstacle in the direction the player is moving
                if (!Physics2D.OverlapCircle(movePoint.position + moveDirection, 0.2f, whatStopsMovement))
                {
                    // Move the player to the new point in the current direction
                    movePoint.position += moveDirection;
                }
                else
                {
                    // Play the stop movement sound when an obstacle is hit
                    PlaySound(stopMovementClip, stopMovementVolume);

                    // Reverse the direction (180 degrees) if an obstacle is hit
                    TurnAround();
                }

                // Check for collision with grandma after reaching the movePoint
                CheckForGrandmaCollision();
            }
        }
    }

    // Check for collision with multiple grandma instances
    private void CheckForGrandmaCollision()
    {
        // Use OverlapCircleAll to find all grandma objects within a small radius
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(movePoint.position, 0.2f, turnPlayerLayer);
        foreach (var hitCollider in hitColliders)
        {
            // Ensure the collided object has the VariablesTurningGrandma component
            VariablesTurningGrandma grandma = hitCollider.GetComponent<VariablesTurningGrandma>();
            if (grandma != null)
            {
                // Play the turn player sound when turning is triggered by grandma
                PlaySound(turnPlayerClip, turnPlayerVolume);

                // Turn the player in the grandma's direction
                SetMoveDirection(grandma.GetCurrentDirection());

                // Make the grandma turn after turning the player
                grandma.Turn();

                // Ensure to stop checking further grandmas after one has been processed
                break; // Remove this line if you want to handle multiple grandmas at once
            }
        }
    }

    // Method to reverse the player's direction
    private void TurnAround()
    {
        // Reverse the move direction by 180 degrees
        moveDirection *= -1;
    }

    // Set the player's movement direction
    private void SetMoveDirection(Vector3 newDirection)
    {
        moveDirection = newDirection;
    }

    // Method to play a sound clip at a specified volume
    private void PlaySound(AudioClip clip, float volume)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip, volume);
        }
    }
}
