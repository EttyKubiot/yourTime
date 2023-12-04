using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MyScore : MonoBehaviour
{

    public PlayerController[] player;
    [SerializeField] private PlayerUIpanel[] playerUIpanel;

    [SerializeField] private TMP_Text scoreText;

    private void Start()
    {
        MyGameManager.Instance.OnScorePlayer1 += SetScorePlayer1;
        MyGameManager.Instance.OnScorePlayer2 += SetScorePlayer2;
        MyGameManager.Instance.OnScorePlayer3 += SetScorePlayer3;
        MyGameManager.Instance.OnScorePlayer4 += SetScorePlayer4;
    }

    private void SetScorePlayer1()
    {
        player[0].score = player[0].score + 10;
        playerUIpanel[0].UpDateScore(player[0].score);
    }

    private void SetScorePlayer2()
    {
        player[1].score = player[1].score + 10;
        playerUIpanel[1].UpDateScore(player[1].score);
    }

    private void SetScorePlayer3()
    {
        player[2].score = player[2].score + 10;
        playerUIpanel[2].UpDateScore(player[2].score);
    }

    private void SetScorePlayer4()
    {
        player[3].score = player[3].score + 10;
        playerUIpanel[3].UpDateScore(player[3].score);
    }
}
    