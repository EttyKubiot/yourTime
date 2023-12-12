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
        //StartCoroutine(WaitForDelete());
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
        SaveScores();
      
    }

    private void SaveScores()
    {
        // Save scores for each player using PlayerPrefs
        for (int i = 0; i < player.Length; i++)
        {
            PlayerPrefs.SetInt("Player" + i + "Score", player[i].score);
        }
        PlayerPrefs.Save();
    }

    //private IEnumerator WaitForDelete()
    //{
    //    yield return new WaitForSeconds(1f);
    //    LoadScores();
    //}

   

   

  
}
    