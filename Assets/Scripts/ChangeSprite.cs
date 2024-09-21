using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour
{
   public  int toChange = 1;

   public Button button1;
   public Button button2;

 
  
   void Start(){
    button1.onClick.AddListener(() => changeSpr1());
    button2.onClick.AddListener(() => changeSpr2());
   }

    public void changeSpr1()
    {
        toChange = 1;
    }

    public void changeSpr2()
    {
        toChange = 2;
    }
}
