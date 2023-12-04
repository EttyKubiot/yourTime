using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LosePopup : MonoBehaviour
{
    private GameManager gameManager;
    private Timer timer;

    [SerializeField] private Text scoreText;
    private int score;
   
    [SerializeField] private GameObject[] avatar;
    [SerializeField] private Animator[] animator;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        timer = FindObjectOfType<Timer>();
        if (gameManager.mode == 0)
        {
            avatar[0].SetActive(true);
        }
        else
        {
            avatar[1].SetActive(true);
        }
      
        score = PlayerPrefs.GetInt("score");
        scoreText.text = score.ToString();
        StartCoroutine(DisableLoop());

    }

    private IEnumerator DisableLoop()
    {
       
        yield return new WaitForSeconds(7f);
        //animator[0].enabled = false;
        //animator[1].enabled = false;

    }
}
