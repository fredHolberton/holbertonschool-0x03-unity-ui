using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Load the Maze scene
    public void PlayMaze()
    {
        SceneManager.LoadScene("maze");
    }

    // Quits the Maze video game
    public void QuitMaze()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
