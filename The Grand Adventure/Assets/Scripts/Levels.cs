using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    //method for level select buttons
    public void OpenLevel(int levelId)
    {
        //button opens level based on level ID in build settings
        string levelName = "level " + levelId;
        SceneManager.LoadScene(levelName);
    }
}

//https://www.youtube.com/watch?v=2XQsKNHk1vk&t=296s by Rehope Games
