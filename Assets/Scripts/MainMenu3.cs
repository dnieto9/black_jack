using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu3 : MonoBehaviour
{
       
    public void PlayGame()
    {
        //PlayerPrefs.SetInt("MyIntValue", 0);
        //PlayerPrefs.Save(); // Save the changes
        SceneManager.LoadScene("Game");
       }
}
