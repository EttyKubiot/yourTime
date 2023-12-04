using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AvatarSound : MonoBehaviour
{
    //[SerializeField]
    //GameObject musicSlider;
    //[SerializeField]
    //AudioSource audioSourceMusic;
  
   
    //[SerializeField] private AudioClip[] audioClipsButton;
    //[SerializeField] private AudioClip[] complimentClipGirl;
    //[SerializeField] private AudioClip[] complimentClipBoy;
    //[SerializeField] private AudioClip[] supportClip;
    //[SerializeField] private AudioClip[] supportClipGirl;
    //[SerializeField] private AudioSource audioSource;
  
    //[SerializeField] private Animator boyAnimator;
    //[SerializeField] private Animator girlAnimator;
   
    //private bool mistake;
    //private bool win;
    //private int indexCom;
    //private int indexCom2;
    //private float currentMusic = 1;
  

    //private void Awake()
    //{
       
     
        
      
    //    currentMusic = PlayerPrefs.GetFloat("Volume")/* 0.5f*/;
    //    if(currentMusic == 0)
    //    {
    //        currentMusic = 0.5f;
    //    }
      
    //    musicSlider.GetComponent<Slider>().value = currentMusic;
    //    audioSourceMusic.volume = currentMusic;

       

    //}


    //private void Start()
    //{
    //    MyGameManager.Instance.OnMistakePick += PlaySoundL;
    //    MyGameManager.Instance.OnCorrectPick += PlaySoundW;
    //    MyGameManager.Instance.PlayAudioPressed += PlayAudioOnPress;
    //    MyGameManager.Instance.OnWin += SetWin;
    //    audioSource.clip = audioClipsButton[2];
    //    audioSource.Play();
    //    StartCoroutine(WaitForPlay());
    //    MyGameManager.Instance.canMove = true;
    //    //currentMusic = PlayerPrefs.GetFloat("Volume");
    //    //musicSlider.GetComponent<Slider>().value = currentMusic;
    //    //audioSourceMusic.volume = musicSlider.GetComponent<Slider>().value;
    //}
    //public void PlayAudioOnPress(AudioClip clip)
    //{
      
    //    StartCoroutine(PlayClip(clip));
    //    //audioSource.PlayOneShot(clip, 1f);
    //}

    //IEnumerator WaitForPlay()
    //{
    //    yield return new WaitForSeconds(3f);
    //    MyGameManager.Instance.canMove = true;
    //}
    //public void SetVolume()
    //{
    //    audioSourceMusic.volume = musicSlider.GetComponent<Slider>().value;
    //    PlayerPrefs.SetFloat("Volume", musicSlider.GetComponent<Slider>().value);
    //}




    //IEnumerator PlayClip(AudioClip clip)
    //{
    //    yield return new WaitForSeconds(0.2f);
    //    audioSource.clip = clip;
    //    audioSource.Play();
    //}




    //public void PlaySoundW()
    //{
    //    mistake = false;
    //    StartCoroutine(PlaySuccsesOrMistake());
    //}

    //public void PlaySoundL()
    //{
    //    mistake = true;
    //    StartCoroutine(PlaySuccsesOrMistake());
    //}

    //private IEnumerator PlaySuccsesOrMistake()
    //{
       

    //    if (!MyGameManager.Instance.gameEnd && mistake)
    //    {

    //       audioSource.clip = audioClipsButton[0];
         
    //    }
    //    else if(!MyGameManager.Instance.gameEnd && !mistake)
    //    {
    //        audioSource.clip = audioClipsButton[1];
    //    }
    //    audioSource.Play();
    //    yield return new WaitForSeconds(1.5f);
    //    if(mistake && !MyGameManager.Instance.gameEnd)
    //    {
    //        if (MyGameManager.Instance.mode != 0)
    //        {
    //            audioSource.clip = supportClip[indexCom2];
               
    //        }
    //        else
    //        {
    //            audioSource.clip = supportClipGirl[indexCom2];
    //        }

    //        audioSource.Play();
    //        indexCom2++;
    //        if (indexCom2 >= supportClip.Length || indexCom2 >= supportClipGirl.Length)
    //        {
    //            indexCom2 = 0;
    //        }

    //    }

    //    else if (!MyGameManager.Instance.gameEnd && MyGameManager.Instance.mode == 0 && !mistake)
    //    {
    //        audioSource.clip = complimentClipGirl[indexCom];
    //        audioSource.Play();
    //        indexCom++;
    //    }
    //    else if(!MyGameManager.Instance.gameEnd && MyGameManager.Instance.mode != 0 && !mistake)
    //    {
    //        audioSource.clip = complimentClipBoy[indexCom];
    //        audioSource.Play();
    //        indexCom++;
    //    }
       
    //    if (indexCom >= complimentClipGirl.Length || indexCom >= complimentClipBoy.Length)
    //    {
    //        indexCom = 0;
    //    }
    //    yield return new WaitForSeconds(1.5f);
    //    MyGameManager.Instance.canMove = true;

    //}

    //public void GetClip(AudioClip audioClip)
    //{
    //    audioSource.PlayOneShot(audioClip, 0.7f);
    //}

    ////public void ButtonClick()
    ////{
    ////    audioSource.PlayOneShot(audioClipsButton[7], 0.7f);
    ////}

    //private void SetWin()
    //{
    //    win = true;
    //    musicSlider.GetComponent<Slider>().value = 0f;
    //    audioSourceMusic.volume = musicSlider.GetComponent<Slider>().value;
     
    //    //masterMixer.SetFloat("musicVol", -80);
    //    audioSource.clip = audioClipsButton[6];
    //    audioSource.Play();
    //    //audioSource.PlayOneShot(audioClipsButton[4], 0.7f);
    //    //audioSource.PlayOneShot(audioClipsButton[4], 0.7f);
    //    //audioSource.PlayOneShot(audioClipsButton[4], 0.7f);
    //    StartCoroutine(WinPopup());


    //}

    //IEnumerator WinPopup()
    //{
    //    yield return new WaitForSeconds(7f);
    //    audioSource.clip = audioClipsButton[8];
    //    audioSource.Play();
    //}

    //private void SetLose()
    //{
    //    win = false;
    //    musicSlider.GetComponent<Slider>().value = 0f;
    //    audioSourceMusic.volume = musicSlider.GetComponent<Slider>().value;
        
    //    //masterMixer.SetFloat("musicVol", -80);
    //    audioSource.PlayOneShot(audioClipsButton[4], 0.7f);
       
    //    //StartCoroutine(WinLosePopup());
    //}

    ////IEnumerator WinLosePopup()
    ////{
    ////    yield return new WaitForSeconds(2f);
    ////    if(!win)
    ////    {
    ////        audioSource.PlayOneShot(audioClipsButton[6], 0.7f);
            
    ////    }
      
    ////    else
    ////    {
    ////        yield return new WaitForSeconds(1f);
    ////        if (MyGameManager.Instance.mode == 1)
    ////        {
    ////            audioSource.PlayOneShot(audioClipsButton[6], 0.7f);
    ////        }
    ////        else
    ////        {
    ////            audioSource.PlayOneShot(audioClipsButton[2], 0.7f);
    ////        }
           
    ////    }
       
    //}
}

   
  
  

    


