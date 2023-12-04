using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpClip : MonoBehaviour
{
    public AudioClip clip;
    // Start is called before the first frame update
    private void Start()
    {
        MyGameManager.Instance.OnCorrectPick += GetClip;
    }
    public void GetClip()
    {
        MyGameManager.Instance.PlayAudioPressed?.Invoke(clip);
    }
}
