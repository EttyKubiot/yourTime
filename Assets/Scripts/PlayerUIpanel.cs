using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUIpanel : MonoBehaviour
{
    
    [SerializeField] private TMP_Text playerScore;
    //[SerializeField] private TMP_Text playerName;
    //[SerializeField] private ThirdPersonController [] player;




    public void UpDateScore(int score)
    {
        playerScore.text = score.ToString();
    }
}
