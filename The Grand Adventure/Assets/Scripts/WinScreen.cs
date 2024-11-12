using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour
{
    [SerializeField] GameObject winScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if player collides with collider, the win screen appears and time stops
        if (collision.tag == "Player")
        {
            winScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }

    //method for next level button
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    //method for main menu button
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
