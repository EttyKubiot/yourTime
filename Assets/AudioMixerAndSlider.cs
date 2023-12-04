using UnityEngine.Audio;
using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;


public class AudioMixerAndSlider : MonoBehaviour
{
   
  
    [SerializeField]
    GameObject musicSlider;
    [SerializeField]
    AudioSource audioSource;



    void Awake()
    {

        audioSource.volume = PlayerPrefs.GetFloat("effectsVolume");
        musicSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("effectsVolume");


    }

    public void SetVolume()
    {
        audioSource.volume = musicSlider.GetComponent<Slider>().value;
        PlayerPrefs.SetFloat("effectsVolume", musicSlider.GetComponent<Slider>().value);
    }

  
  
   
}
