using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameManager : MonoBehaviour
{
    //Game Buttons
    public Button dealBtn;
    public Button hitBtn;
    public Button standBtn;

    public Button quitBtn;
    
    public PlayerScript playerScript;
    public PlayerScript dealerScript;

    //accces to public text to access and update
    public Text scoreText;

    public Text dealerScoreText;
   
    public Text mainText;
    
    public GameObject hideCard;
    public Sprite[] def ;
    public  Sprite newsprite ; //added

   public int Choice ;


    void Start()
    {
           int myval = PlayerPrefs.GetInt("MyIntValue"); // Default to 0 if not set
           Debug.Log("Received int value: " + myval);

           newsprite = def[myval];
       
        
         

            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("Deck");
            Debug.Log("number of tags found");
            Debug.Log(objectsWithTag.Count());
            // Loop through each object and change the SpriteRenderer
            foreach (GameObject obj in objectsWithTag)
            {
                SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
                
                    spriteRenderer.sprite = newsprite; // Change to your new sprite
                
          
            }

        hitBtn.gameObject.SetActive(false);
        standBtn.gameObject.SetActive(false);
        //Add on click listers to the buttons
        dealBtn.onClick.AddListener(() => DealClicked());
        hitBtn.onClick.AddListener(() => HitClicked());
        standBtn.onClick.AddListener(() => StayClicked());

        
    }
    

    private void DealClicked()
    {

        //reset round, hide text, prep for new hand
        playerScript.ResetHand();
        dealerScript.ResetHand();
        mainText.gameObject.SetActive(false);
        //hide deal hand score 
        dealerScoreText.gameObject.SetActive(false);
        GameObject.Find("Deck").GetComponent<DeckScript>().Shuffle();
        playerScript.StartHand();
        dealerScript.StartHand();

        //update the score displayed
        
        scoreText.text = "Hand: " + playerScript.handValue.ToString();
        dealerScoreText.text = "Dealer Hand: " + dealerScript.handValue.ToString();

        //enable hid one of dealers card
        hideCard.GetComponent<Renderer>().enabled = true;


        //adjust buttons visible
        dealBtn.gameObject.SetActive(false);
        hitBtn.gameObject.SetActive(true);
        standBtn.gameObject.SetActive(true);
      

    }
    private void HitClicked()
    {
        if(playerScript.cardIndex <= 5)
        {
            playerScript.GetCard();
            scoreText.text = "Hand: " + playerScript.handValue.ToString();
            if(playerScript.handValue > 20) RoundOver();
        }
    }
    private void StayClicked()
    {
        standBtn.gameObject.SetActive(false);
        dealBtn.gameObject.SetActive(false);
        hitBtn.gameObject.SetActive(false);
        HitDealer();
        

    } 
        

    private void HitDealer()
    {
        while(dealerScript.handValue < 16 && dealerScript.cardIndex < 5)
        {
            dealerScript.GetCard();
            dealerScoreText.text = "Hand: " + dealerScript.handValue.ToString();
            if(dealerScript.handValue > 20) RoundOver();
        }
        
        RoundOver();
        
    }

    //check for winner and loser, hand is over
    void RoundOver()
    {
        //Booleans for bus
        bool playerBust = playerScript.handValue > 21;
        bool dealerBust = dealerScript.handValue > 21;
        bool player21 = playerScript.handValue == 21;
        bool dealer21 = dealerScript.handValue ==21;
        
        bool roundOver = true; 
        if(playerBust && dealerBust)
        {
            mainText.text = "Tied with Dealer";
        }
        //if player busts, dealer didnt, or if dealer has more points
        else if(playerBust || (!dealerBust && dealerScript.handValue > playerScript.handValue))
        {
            mainText.text = "Dealer wins!";
        }
        //dealer busts player didnt
        else if(dealerBust || playerScript.handValue > dealerScript.handValue)
        {
            mainText.text = ""; //
            SceneManager.LoadScene("WinnerAnimation"); // Load the specified scene

        }
        //check for tie
        else if(playerScript.handValue == dealerScript.handValue)
        {
            mainText.text = "Tied with Dealer";
        }
        else if(player21 && !dealer21)
        {
            mainText.text = "";
            SceneManager.LoadScene("WinnerAnimation"); // Load the specified scene


        }
        else if(!player21 && dealer21)
        {
            mainText.text = "Dealer wins!";  //
        }
        else if(player21 && dealer21)
        {
            mainText.text = "Tied with Dealer!";

        }
        else{
            roundOver = false;
        }
        //set up ui
        if(roundOver)
        {
            hitBtn.gameObject.SetActive(false);
            standBtn.gameObject.SetActive(false);
            dealBtn.gameObject.SetActive(true);
            mainText.gameObject.SetActive(true);
            dealerScoreText.gameObject.SetActive(true);
            hideCard.GetComponent<Renderer>().enabled = false;
        }
    }
}
