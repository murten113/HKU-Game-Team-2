using UnityEngine;

public class PlayerDeleteOnCollision : MonoBehaviour
{
    public string deleteObjectTag = "DeleteObject";  // The tag of the object that should trigger deletion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collided with an object that has the specified tag
        if (collision.gameObject.CompareTag(deleteObjectTag))
        {
            Destroy(gameObject); // Destroy the player GameObject
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If using trigger colliders, check if the object has the specified tag
        if (collision.gameObject.CompareTag(deleteObjectTag))
        {
            Destroy(gameObject); // Destroy the player GameObject
        }
    }
}
