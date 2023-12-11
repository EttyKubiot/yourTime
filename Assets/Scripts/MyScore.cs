using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyScore : MonoBehaviour
{

    public PlayerController[] player;
    [SerializeField] private PlayerUIpanel[] playerUIpanel;

    [SerializeField] private TMP_Text scoreText;
    private int scoreType;
    private void Start()
    {
        MyGameManager.Instance.OnScorePlayer1 += SetScorePlayer1;
        //MyGameManager.Instance.OnScorePlayer2 += SetScorePlayer2;
        //MyGameManager.Instance.OnScorePlayer3 += SetScorePlayer3;
        //MyGameManager.Instance.OnScorePlayer4 += SetScorePlayer4;
    }

    private void SetScorePlayer1(int playerLayer, string watchType)
    {
        int index = playerLayer - 6;
        if(watchType== "Clock1")
        {
            scoreType = 10;
        }
        if (watchType == "Clock2")
        {
            scoreType = 20;
        }
        if (watchType == "Clock3")
        {
            scoreType = 30;
        }
        else scoreType = 40;
        player[index].score = player[index].score + scoreType;
        playerUIpanel[index].UpDateScore(player[index].score);
    }

    
}
    