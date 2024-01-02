using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClip;
    private AudioSource audioSource;
    

    private void Start()
    {
        audioSource = FindObjectOfType<AudioSource>(); 
       
    }

    //public void PlaySound(AudioClip audioClip)
    //{
    //    audioSource.PlayOneShot(audioClip, 0.7f); 
    //}

}
