using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUIpanel : MonoBehaviour
{
    
    [SerializeField] private TMP_Text playerScore;
    [SerializeField] private TMP_Text playerScorePopup;
    //[SerializeField] private TMP_Text playerName;
    //[SerializeField] private ThirdPersonController [] player;




    public void UpDateScore(int score)
    {
        int minutes = score / 60; // Calculate minutes
        int seconds = score % 60; // Calculate remaining seconds

        // Display the time in the format MM:SS
        playerScore.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        playerScorePopup.text = playerScore.text;
        //playerScore.text = score.ToString();
    }
}
