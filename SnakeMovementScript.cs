using UnityEngine;


public class SnakeClickMovement : MonoBehaviour
{
    public float moveSpeed = 2f; // Speed of movement
    private bool isMoving = false; // Flag to check if the snake should move
    Animator animator;
    public bool SnakeRouteBocked;
    GameManager manager;

    private void Start()
    {
        animator = GetComponent<Animator>();
        manager = FindAnyObjectByType<GameManager>();
    }

    void Update()
    {
        // Detect Mouse Click or Touch Input
        if (Input.GetMouseButtonDown(0)) // 0 = Left Click or Tap
        {
            Debug.Log("Mouse click detected!");

            // Cast a ray from the camera to where the mouse or touch occurred
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits any collider attached to the snake's bones
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Raycast hit: " + hit.transform.name);

                // Check if the hit object is one of the snake's bones (you could also add a specific tag or layer to the bones)
                if (hit.transform.IsChildOf(transform)) // Ensures we clicked one of the snake's bones
                {
                    if (SnakeRouteBocked == false)
                    {
                        Debug.Log("Snake clicked!");
                        isMoving = true; // Start moving the snake
                        animator.SetTrigger("moving");
                    }
                    else
                    {
                        manager.ChanceRemaining--;
                    }
                }
            }
        }

        // Move the snake forward continuously if it is marked as moving
        if (isMoving)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }
}
