using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goToGame : MonoBehaviour
{
    
    private void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            ChangeScene();
        }
    }

    private void ChangeScene()
    {
        // Load the specified scene
        SceneManager.LoadScene("Game");
    }

}
