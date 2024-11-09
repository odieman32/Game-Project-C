using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    public void OpenLevel(int levelId)
    {
        string levelName = "level " + levelId;
        SceneManager.LoadScene(levelName);
    }
}

//https://www.youtube.com/watch?v=2XQsKNHk1vk&t=296s by Rehope Games
