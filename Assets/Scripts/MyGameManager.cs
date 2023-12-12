using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyGameManager : MonoBehaviour
{
    public UnityAction<int, string> OnScorePlayer1;
 
    public UnityAction OnScorePlayer1Minus;
    public UnityAction OnScorePlayer2Minus;
    public UnityAction OnScorePlayer3Minus;
    public UnityAction OnScorePlayer4Minus;
    public UnityAction OnHutPick;
    public UnityAction OnColdPick;
    public UnityAction OnMistakePick;
    public UnityAction OnEnemy;
    public UnityAction OnTime;
    public UnityAction OnEndA;
    public UnityAction OnThousand;
    public UnityAction OnTenThousand;
    public UnityAction OnCorrectPick;
    public UnityAction<AudioClip> PlayAudioPressed;
    public ParticleSystem particleSystem;
    public ParticleSystem particleSystem1;
    public ParticleSystem particleSystem2;
    public SpriteRenderer textCollect;
    public SpriteRenderer textCollect1;
    public SpriteRenderer textCollect2;
    public int saveScore;
    public static MyGameManager Instance;
    public string homePageURL = "https://shirshiur.co.il/game-school/";
    public string googleFormURL = "https://docs.google.com/forms/d/e/1FAIpQLSf25SB673RWNkRpBD0TlGL5dgsnKuR74LoXYRKh0lzBXG2ElA/viewform?usp=sf_link";
    //public GameObject popup;
    public GameObject endAPopup;
    public int mode;
    public bool gameEnd;
    private int misNum;
    public bool canMove =true;
    //[SerializeField] private GameObject[] avatar;
    public Button openButton;
    public string landingPageURL = "https://shirshiur.co.il/game-school/";


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        OnTime += SetPopup;
        OnEndA += SetPopup;
        StartCoroutine(GetData());
    }

    public void OpenLandingPage()
    {
        // Display a notification or message informing the user about pop-up action

        // Attempt to open the landing page
        OpenURL(landingPageURL);
    }

    private void OpenURL(string url)
    {
        // Open the URL in a new tab or window
        Application.OpenURL(url);
    }

    IEnumerator GetData()
    {
        yield return new WaitForSeconds(0.2f);
       
        //Debug.Log(PlayerPrefs.GetInt("avatarNum"));
        int saveAvatar = PlayerPrefs.GetInt("avatarSelected");
        mode = saveAvatar;
        canMove = true;
        //SaveAvatar.Instance.mode = saveAvatar;
        //Debug.Log(SaveAvatar.Instance.mode);
        //avatar[mode].gameObject.SetActive(true);

    }

    private void SetPopup()
    {

        //WinPopup.SetActive(true);
        StartCoroutine(Popup());
    }

    IEnumerator Popup()
    {
        yield return new WaitForSeconds(6f);
        endAPopup.SetActive(true);
        //OpenHomePage();
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }


    public void OpenHomePage()
    {
        //Application.OpenURL(homePageURL);
    }

    public void OpenGoogleFormPage()
    {
        Application.OpenURL(googleFormURL);
    }

   

}
