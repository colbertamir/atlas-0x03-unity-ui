using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Initialization
    void Start()
    {

    }

    // Update called once per frame
    void Update()
    {

    }

    // Method to play the maze scene
    public void PlayMaze()
    {
        // Load the maze scene
        SceneManager.LoadScene("maze");
    }
}
