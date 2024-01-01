using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPopups : MonoBehaviour
{

    public GameObject[] flagPopup;
    public ParticleSystem[] confti;
    // Start is called before the first frame update
    void Start()
    {
        MyGameManager.Instance.OnFlag += SetPopupFlag;
    }

    private void SetPopupFlag(int player)
    {
        flagPopup[player].SetActive(true);
        //for (int i = 0; i < confti.Length; i++)
        //{
        //    confti[i].gameObject.SetActive(true);
        //}
       
    }

   
       

    
}
