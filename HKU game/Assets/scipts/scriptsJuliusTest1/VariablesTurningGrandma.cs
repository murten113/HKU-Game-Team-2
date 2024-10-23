using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariablesTurningGrandma : MonoBehaviour
{
    public bool turnClockwise = false;   // Determines if grandma turns clockwise
    public bool upDirection = false;     // Grandma facing up
    public bool downDirection = false;   // Grandma facing down (default)
    public bool leftDirection = false;   // Grandma facing left
    public bool rightDirection = false;  // Grandma facing right

    private Vector3 currentDirection;    // Current movement direction

    // Track the last known state of direction booleans
    private bool lastUpDirection;
    private bool lastDownDirection;
    private bool lastLeftDirection;
    private bool lastRightDirection;

    // Start is called before the first frame update
    void Start()
    {
        // Set the initial direction based on which boolean is true
        SetInitialDirection();

        // Initialize the last state variables
        lastUpDirection = upDirection;
        lastDownDirection = downDirection;
        lastLeftDirection = leftDirection;
        lastRightDirection = rightDirection;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if any of the direction booleans have changed
        if (upDirection != lastUpDirection || downDirection != lastDownDirection ||
            leftDirection != lastLeftDirection || rightDirection != lastRightDirection)
        {
            // Update the current direction based on active direction booleans
            UpdateCurrentDirection();

            // Rotate the grandma to match her new direction
            RotateToCurrentDirection();

            // Update last known state of the booleans
            lastUpDirection = upDirection;
            lastDownDirection = downDirection;
            lastLeftDirection = leftDirection;
            lastRightDirection = rightDirection;
        }
    }

    // Turn the grandma 90 degrees based on the turnClockwise bool
    public void Turn()
    {
        // Cycle through the directions based on clockwise or counterclockwise
        if (turnClockwise)
        {
            if (upDirection) { upDirection = false; rightDirection = true; }       // Up -> Right
            else if (rightDirection) { rightDirection = false; downDirection = true; } // Right -> Down
            else if (downDirection) { downDirection = false; leftDirection = true; } // Down -> Left
            else if (leftDirection) { leftDirection = false; upDirection = true; }  // Left -> Up
        }
        else
        {
            if (upDirection) { upDirection = false; leftDirection = true; }       // Up -> Left
            else if (leftDirection) { leftDirection = false; downDirection = true; } // Left -> Down
            else if (downDirection) { downDirection = false; rightDirection = true; } // Down -> Right
            else if (rightDirection) { rightDirection = false; upDirection = true; }  // Right -> Up
        }

        // Update the current direction based on active direction booleans
        UpdateCurrentDirection();

        // Rotate the grandma to match her new direction
        RotateToCurrentDirection();

        // Update the last state booleans to reflect the new state after turning
        lastUpDirection = upDirection;
        lastDownDirection = downDirection;
        lastLeftDirection = leftDirection;
        lastRightDirection = rightDirection;
    }

    // Set initial direction from editor setup
    private void SetInitialDirection()
    {
        if (upDirection) currentDirection = Vector3.up;
        else if (downDirection) currentDirection = Vector3.down;
        else if (leftDirection) currentDirection = Vector3.left;
        else if (rightDirection) currentDirection = Vector3.right;

        // Rotate the grandma to the initial direction
        RotateToCurrentDirection();
    }

    // Method to update the current direction based on boolean states
    private void UpdateCurrentDirection()
    {
        if (upDirection) currentDirection = Vector3.up;
        else if (downDirection) currentDirection = Vector3.down;
        else if (leftDirection) currentDirection = Vector3.left;
        else if (rightDirection) currentDirection = Vector3.right;
    }

    // Method to return the grandma's current direction for the player to follow
    public Vector3 GetCurrentDirection()
    {
        return currentDirection;
    }

    // Rotate the grandma object and sprite based on the current direction
    private void RotateToCurrentDirection()
    {
        if (currentDirection == Vector3.up)
            transform.rotation = Quaternion.Euler(0, 0, 0);         // Up
        else if (currentDirection == Vector3.down)
            transform.rotation = Quaternion.Euler(0, 0, 180);       // Down
        else if (currentDirection == Vector3.left)
            transform.rotation = Quaternion.Euler(0, 0, 90);        // Left
        else if (currentDirection == Vector3.right)
            transform.rotation = Quaternion.Euler(0, 0, -90);       // Right
    }

    // Method to set the direction using booleans and update the currentDirection
    private void SetDirection(bool up, bool down, bool left, bool right)
    {
        upDirection = up;
        downDirection = down;
        leftDirection = left;
        rightDirection = right;

        // Update current direction and rotation
        UpdateCurrentDirection();
        RotateToCurrentDirection();

        // Update the last state booleans after setting the direction
        lastUpDirection = up;
        lastDownDirection = down;
        lastLeftDirection = left;
        lastRightDirection = right;
    }
}
