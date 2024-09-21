using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenus : MonoBehaviour
{
    public void PlayGame()
    {
        //pass in the game option
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
