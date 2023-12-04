using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PickUp : MonoBehaviour
{
    public ImageData imageData;
    private Animator animator;
    private GameManager gameManager;
  
    //private float indexState = 1f;
    private string AvatrLetter;

    private bool isTriggered = false;
   
    private void Awake()
    {

        animator = GetComponentInParent<Animator>();
         gameManager = FindObjectOfType<GameManager>();
        gameManager.OnPlayClipName += GetName;
        gameManager.OnWin += EndGame;
        gameManager.OnLose += EndGame;
       
    }

   




    void OnTriggerEnter2D(Collider2D col)
    {

        if (!isTriggered && col.gameObject.CompareTag("Player"))
        {
            isTriggered = true;
            Debug.Log("player trigger");

            gameManager.PlayAudioPressed?.Invoke(imageData.AudioClip);
            if (Keyboard.current.spaceKey.isPressed /*|| Gamepad.current.buttonEast.isPressed*/
                 || gameManager.isChoosePick)
            {
                if (imageData.Sound == char.Parse(AvatrLetter))
                {
                    gameManager.OnCorrect?.Invoke();
                    Debug.Log("correct");
                    if(gameObject.CompareTag("PickUp2"))
                    {
                        ParticleSystem particleSystem = Instantiate(gameManager.particleSystem1, gameObject.transform.GetChild(0).transform);
                        particleSystem.Play();
                    }
                    else
                    {
                        ParticleSystem particleSystem = Instantiate(gameManager.particleSystem, gameObject.transform.GetChild(0).transform);
                        particleSystem.Play();
                    }
                   
                    animator.SetTrigger("PickUp");
                    Destroy(gameObject, 0.8f);
                    //StartCoroutine(Particals(imageData));
                }

                else
                {
                    gameManager.OnMistake?.Invoke();
                    animator.SetTrigger("Mistake");
                    Debug.Log("mistake");
                    gameManager.indexState = gameManager.indexState - 0.25f;
                    Debug.Log("indexState" + gameManager.indexState);
                    gameManager.OnNewState?.Invoke(gameManager.indexState);
                    //SetHaelthSlider(indexState);

                }
                Debug.Log(imageData.Sound);
               
                gameManager.OnPlayClip?.Invoke();
            }
           
        }
       
        gameManager.ToggleOf();
        StartCoroutine(EnableColliderAfterDelay());
    }


    IEnumerator EnableColliderAfterDelay()
    {
    // Wait for a short delay before enabling the collider again
    yield return new WaitForSeconds(3f);

    isTriggered = false;
     
    }

   

    private void SetHaelthSlider(float game)
    {
        gameManager.slider.value = game;

    }

    private void GetName(string letter)
    {
        AvatrLetter = letter;
    }

    private void EndGame()
    {
        gameManager.gameEnd = true;
    }
}
