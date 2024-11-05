using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    //Code for pause menu
    [SerializeField] GameObject pauseMenu;

    //Turns on pause UI and stops the game time
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    //Loads the main menu scene and turns time back to normal
    public void Home()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    //Turns off pause panel and sets time back to normal
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
//https://www.youtube.com/watch?v=MNUYe0PWNNs&t=351s by Rehope Games
