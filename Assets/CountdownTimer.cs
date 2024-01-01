using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text[] timerTexts;
    public PlayerController[] player;
    [SerializeField] private PlayerUIpanel[] playerUIpanel;

    private int[] timeInSeconds; // Time in seconds representing the countdown for each player

    void Start()
    {
        LoadScores();
    }

    private void LoadScores()
    {
        // Load scores for each player from PlayerPrefs
        timeInSeconds = new int[player.Length];

        for (int i = 0; i < player.Length; i++)
        {
            if (PlayerPrefs.HasKey("Player" + i + "Score"))
            {
                player[i].score = PlayerPrefs.GetInt("Player" + i + "Score");
                playerUIpanel[i].UpDateScore(player[i].score);
                timeInSeconds[i] = player[i].score; // Set initial time for each player
                UpdateTimerText(i);
            }
        }

        InvokeRepeating("Countdown", 1.0f, 1.0f);
    }

    void UpdateTimerText(int playerIndex)
    {
        int minutes = timeInSeconds[playerIndex] / 60; // Calculate minutes
        int seconds = timeInSeconds[playerIndex] % 60; // Calculate remaining seconds

        // Display the time in the format MM:SS for the corresponding player
        timerTexts[playerIndex].text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void Countdown()
    {
        for (int i = 0; i < timeInSeconds.Length; i++)
        {
            if (timeInSeconds[i] > 0)
            {
                timeInSeconds[i]--;
                UpdateTimerText(i);
            }
            else
            {
                // Time's up for player i, perform necessary actions here
                Debug.Log("Player " + i + " - Time's up!");
                player[i].gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                player[i].gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll; 
            }
        }
    }
}
