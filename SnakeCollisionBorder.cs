using UnityEngine;

public class SnakeCollisionBorder : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>(); 
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with an object tagged as "snakehead"
        if (collision.gameObject.CompareTag("snakehead"))
        {
            // Debug log to confirm the collision with the snake head
            Debug.Log("Snake head collided with the border!");

            gameManager.SnakesLeft--;
            // Destroy the object with the "snakehead" tag
            Destroy(collision.gameObject); // Destroy the snake head
        }
    }
    
}
