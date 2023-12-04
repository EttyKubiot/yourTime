using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float timeRemaining = 0;
    public bool timerIsRunning = false;
    public Text timeText;
    [SerializeField] private Text timeTextPopup;
    [SerializeField] private Text timeTextPopupLose;
    private GameManager gameManager;

    /// <summary>
    /// looks for a reference and sets a listener
    /// </summary>
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        //gameManager.OnRestartTime += RestartTime;
        gameManager.OnWin += StopTimer;
        gameManager.OnLose += StopTimer;
        timerIsRunning = true;
        //RestartTime();
    }

    void Update()
    {
        if (timerIsRunning)
        {
                timeRemaining += Time.deltaTime;
                DisplayTime(timeRemaining);
          
        }
    }
    public void StopTimer()
    {
        timerIsRunning = false;
        DisplayTime(timeRemaining);
    }

    /// <summary>
    /// Display Time and show on text
    /// </summary>

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
       
        if(!timerIsRunning)
        {
            timeTextPopup.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            timeTextPopupLose.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            if (minutes <= 5)
            {
                gameManager.OnTime?.Invoke();
            }
        }
     
    }

    /// <summary>
    /// Resturt Time When the turn changes
    /// </summary>

    //void RestartTime()
    //{
    //    timeRemaining = 0;
    //    timerIsRunning = true;
    //}

}


