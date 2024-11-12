using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastWin : MonoBehaviour
{
    [SerializeField] GameObject lastWin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the hit box collides with the player then the Last win screen comes up and the time stops
        if (collision.tag == "Player")
        {
            lastWin.SetActive(true);
            Time.timeScale = 0;
        }
    }

    //method for main menu button
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

}
