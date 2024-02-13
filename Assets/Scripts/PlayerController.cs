using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour 
{
    public float speed = 5f;
    public int health = 5;

    private Rigidbody rb;
    private int score = 0;

    void Start () 
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void FixedUpdate () 
    {
        // Check for input and move the player accordingly
        float moveHorizontal = Input.GetAxis("Horizontal"); // Gets input from A/D or left/right arrow keys
        float moveVertical = Input.GetAxis("Vertical"); // Gets input from W/S or up/down arrow keys

        // Calculates the movement based on the input
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = movement.normalized * speed * Time.deltaTime;

        // Move the player using physics
        rb.MovePosition(transform.position + movement);
    }

    // Function to handle collisions with objects
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup")) // Check if tag is "Pickup"
        {
            // Increment the score
            score++;

            // Log the updated score to console
            Debug.Log("Score: " + score);

            // Destroy the pickup object on contact
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Trap")) // Check if tag is "Trap"
        {
            // Decrement the health
            health--;

            // Log the updated health to console
            Debug.Log("Health: " + health);
        }
		else if (other.CompareTag("Goal")) // Check if tag is "Goal"
		{
			// Logs "You win!" to console
			Debug.Log("You win!");
		}
    }

	void Update()
	{
		// Check for game over
		if (health <= 0)
		{
			Debug.Log("Game Over!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
