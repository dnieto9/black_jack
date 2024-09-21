using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
   
    //get other scripts
    public CardScript cardScript;
    public DeckScript deckScript;

    //Total Value of player/dealers hand
    public int handValue = 0;

    //betting money
    private int money = 1000;

    public GameObject[] hand;//deck from teh deck scripts
    public int cardIndex = 0;
    List<CardScript> aceList = new List<CardScript>();

   public void StartHand()
    {
        GetCard();
        GetCard();
    }

    
    //add a hand to the player/dealer
    public int GetCard()
    {
        int cardValue = deckScript.DealCard(hand[cardIndex].GetComponent<CardScript>()); //gets the cardscript in the fron
        //show card on screen
        hand[cardIndex].GetComponent<Renderer>().enabled = true;

        handValue += cardValue;
        if(cardValue == 1)
        {
            aceList.Add(hand[cardIndex].GetComponent<CardScript>());
        }
        //check if we should use 11 or 1
        AceCheck();
        cardIndex++;
        return handValue;
    }

    
    public void AceCheck()
    {
        foreach(CardScript ace in aceList)
        {
            if(handValue + 10 < 22 && ace.GetValueOfCard() == 1)
            {
                ace.SetValue(11);
                handValue += 10;
            }
            else if(handValue >21 && ace.GetValueOfCard() == 11)
            {
                ace.SetValue(1);
                handValue -=10;
            }
        }
    }
    public void ResetHand()
    {
        for(int i = 0; i < hand.Length; i++)
        {
            hand[i].GetComponent<CardScript>().ResetCard();
            hand[i].GetComponent<Renderer>().enabled = false;
        }
        cardIndex = 0;
        handValue = 0;
        aceList = new List<CardScript>();
    }
}
