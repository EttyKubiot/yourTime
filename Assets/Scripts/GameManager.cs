using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public UnityAction OnWin;
    public UnityAction OnLose;
    public UnityAction OnCorrect;
    public UnityAction OnMistake;
    public UnityAction<AudioClip, bool> PlayAudioEvent;
    public UnityAction<AudioClip> PlayAudioPressed;
    public UnityAction<float> OnNewState;
    public UnityAction OnPlayClip;
    public UnityAction<string> OnPlayClipName;
    public UnityAction<string> OnColor;
    public UnityAction OnTime;
    public UnityAction isChoose;
    public int mode;
    public bool gameEnd;
    [SerializeField] private int misNum;
    private int corNum;
    [SerializeField] private GameObject[] avatar;
    [SerializeField] private GameObject[] player;

    [SerializeField] private GameObject mistakePopup;
    [SerializeField] private GameObject winPopup;
    public ParticleSystem particleSystem;
    public ParticleSystem particleSystem1;
    public Slider slider;
    public bool isChoosePick;
    public Toggle toggle;
    public float indexState = 1f;

    // Start is called before the first frame update
    void Start()
    {
        mode = PlayerPrefs.GetInt("avatarSelected");

        avatar[mode].gameObject.SetActive(true);
        player[mode].gameObject.SetActive(true);
        OnMistake += SetLose;
        OnCorrect += SetCorrect;
    }

    public void ToggleOf()
    {
        toggle.isOn = false;
        isChoosePick = false;
    }

    public void ChoosePickUp()
    {
        if (toggle.isOn)
        {
            isChoosePick = true;
        }

        else
        {
            isChoosePick = false;
        }
       
        isChoose?.Invoke();
       

    }

    private void SetLose()
    {
        misNum++;
        if (misNum >= 4)
        {
            gameEnd = true;
            OnLose?.Invoke();
            StartCoroutine(LosePopup());

        }
    }

    private void SetCorrect()
    {
        corNum++;
        if (corNum >= 6)
        {
            gameEnd = true;
            OnWin?.Invoke();
            StartCoroutine(WinPopup());

        }
    }

    IEnumerator LosePopup()
    {
        yield return new WaitForSeconds(0.4f);
        mistakePopup.SetActive(true);
       
    }

    IEnumerator WinPopup()
    {
        yield return new WaitForSeconds(0.4f);
        winPopup.SetActive(true);
       
    }

    public void Exit()
    {
        Application.Quit();
        //SceneManager.LoadScene(0);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}


