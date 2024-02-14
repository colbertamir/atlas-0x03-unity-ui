using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour 
{
    public float speed = 10f;
    public int health = 5;
    public Text scoreText;
    public Text healthText;
    private Rigidbody rb;
    private int score = 0;

    void Start () 
    {
        rb = GetComponent<Rigidbody>();
        SetScoreText(); // Calls the SetScoreText method when the game starts
        SetHealthText(); // Calls the SetHealthText method when the game starts
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

    // Handles collisions
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup")) // Tag is "Pickup"
        {
            // Increment the score
            score++;

            // Update the score text
            SetScoreText();

            // Destroy the pickup object on contact
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Trap")) // Tag is "Trap"
        {
            // Decrement the health
            health--;

            // Update the health text
            SetHealthText();

            // Logs updated health to console
            // Debug.Log("Health: " + health);
        }
		else if (other.CompareTag("Goal")) // Tag "Goal"
		{
			// "You win!" to console
			Debug.Log("You win!");
		}
    }

	void Update()
	{
		// Game over!
		if (health <= 0)
		{
			Debug.Log("Game Over!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}

    // Method to update the score text
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString(); // Update the score text
    }

    // Method to update the health text
    void SetHealthText()
    {
        healthText.text = "Health: " + health.ToString(); // Update the health text
    }
}
