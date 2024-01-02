using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //public GameObject PopupChoose;
    //public GameObject Logo;
    public GameObject PlayButton;
    //public GameObject PopupBoy;
    public Animator animator;
    private void Start()
    {
        StartCoroutine(Choose());
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator Choose()
    {
        yield return new WaitForSeconds(10f);
        //Logo.SetActive(true);

        yield return new WaitForSeconds(9f);
        //animator.SetTrigger("Transper");
        yield return new WaitForSeconds(4f);
      
       
       
       
        //PopupChoose.SetActive(true);
        //PopupBoy.SetActive(false);
        //PlayButton.SetActive(true);
    }
}


