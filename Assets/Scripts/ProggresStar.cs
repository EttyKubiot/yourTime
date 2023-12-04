using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProggresStar : MonoBehaviour
{
    private GameManager gameManager;
    public Image[] image;
    public Sprite[] onSprite;
    //[SerializeField] private GameObject winPopup;

    private int index = 0;
    private Animator animator;

    /// <summary>
    /// Unity's Awake method.
    /// </summary>
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        //animator = GetComponentInChildren<Animator>();
        //gameManager.OnCorrect += Activate;
        gameManager.OnCorrect += Activate;

    }

    /// <summary>
    /// Activates the star (when the player achieves its associated score).
    /// </summary>
    public void Activate()
    {

        for (int i = 0; i < onSprite.Length; i++)
        {
           
                image[index].sprite = onSprite[i];
            
        }
           
        animator = image[index].GetComponent<Animator>();
        animator.SetTrigger("Pop");
        if(index == image.Length)
        {
            Debug.Log("win");
            
        }
        else
        {
            index++;
        }
      
    }

    //private IEnumerator SetWin()
    //{
    //    yield return new WaitForSeconds(3);
    //    gameManager.OnWin?.Invoke();
    //    //winPopup.SetActive(true);
       
    //}
}
