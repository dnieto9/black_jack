using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
      
    public void PlayGame()
    {
        PlayerPrefs.SetInt("MyIntValue", 0);
        PlayerPrefs.Save(); // Save the changes
       // SceneManager.LoadScene("Game");
       }
}


// SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    