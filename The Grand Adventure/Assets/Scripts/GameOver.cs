using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameOver : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject pauseButton;

    // Update is called once per frame
    void Update()
    {
        //Finds the Player game object through the Player tag
        if(Health.totalHealth == 0f)
        {
            //sets the game over UI active
            gameOver.SetActive(true);
            //Turns off pause button
            pauseButton.SetActive(false);
        }
    }
   
    //Reloads the scene 
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        //Loads the main menu
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}

//Source: https://www.youtube.com/watch?v=U3sT-T5bKX4
