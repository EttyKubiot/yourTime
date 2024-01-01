using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WinPopup : MonoBehaviour
{
   // private GameManager gameManager;  
   // [SerializeField] private Image star1;
   // [SerializeField] private Image star2;
   // [SerializeField] private Image star3;
   // [SerializeField] private ParticleSystem star1Particles;
   // [SerializeField] private ParticleSystem star1WhiteParticles;
   // [SerializeField] private ParticleSystem star2Particles;
   // [SerializeField] private ParticleSystem star2WhiteParticles;
   // [SerializeField] private ParticleSystem star3Particles;
   // [SerializeField] private ParticleSystem star3WhiteParticles;
   // [SerializeField] private Sprite disabledStarSprite;
   // [SerializeField] private GameObject[] avatar;
   // [SerializeField] private Animator[] animator;
   // [SerializeField] private Text scoreText;
   // private int score;
   // private int stars;
   ////private PlayFabLeaderBoard playFabLeaderBoard;


   // private void Start()
   // {
   //     gameManager = FindObjectOfType<GameManager>();
      
   //     //if(gameManager.mode == 0)
   //     //{
   //     //    avatar[0].SetActive(true);
   //     //}
   //     //else
   //     //{
   //     //    avatar[1].SetActive(true);
   //     //}
   //     gameManager.OnWin += SetStars;
   //     StartCoroutine(DisplayScore());
   //     //playFabLeaderBoard = FindObjectOfType<PlayFabLeaderBoard>();       
   //     //playFabLeaderBoard.SendLeaderBoard(score);
   //     //playFabLeaderBoard.GetLeaderboard();

       
   // }
   // public void SetStars()
   // {
   //     if (stars == 0)
   //     {
   //         star1.sprite = disabledStarSprite;
   //         star2.sprite = disabledStarSprite;
   //         star3.sprite = disabledStarSprite;
   //         star1Particles.gameObject.SetActive(false);
   //         star1WhiteParticles.gameObject.SetActive(false);
   //         star2Particles.gameObject.SetActive(false);
   //         star2WhiteParticles.gameObject.SetActive(false);
   //         star3Particles.gameObject.SetActive(false);
   //         star3WhiteParticles.gameObject.SetActive(false);
   //     }
   //     else if (stars == 1)
   //     {
   //         star2.sprite = disabledStarSprite;
   //         star3.sprite = disabledStarSprite;
   //         star2Particles.gameObject.SetActive(false);
   //         star2WhiteParticles.gameObject.SetActive(false);
   //         star3Particles.gameObject.SetActive(false);
   //         star3WhiteParticles.gameObject.SetActive(false);
   //     }
   //     else if (stars == 2)
   //     {
   //         star3.sprite = disabledStarSprite;
   //         star3Particles.gameObject.SetActive(false);
   //         star3WhiteParticles.gameObject.SetActive(false);
   //     }
   // }

   // private IEnumerator DisplayScore()
   // {
   //     yield return new WaitForSeconds(1f);
   //     score = PlayerPrefs.GetInt("score");
   //     scoreText.text = score.ToString();
       
   // }
 
}


