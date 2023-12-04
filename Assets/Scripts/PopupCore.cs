using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PopupCore : MonoBehaviour
{
    [SerializeField] private ToggleGroup avatarToggleGroup;  
    [SerializeField] private GameObject[] avatar;
    [SerializeField] private GameObject POPUP;

    private int currentAvatar = 1;
  

    private void Awake()
    {
       currentAvatar = 1;
        Debug.Log(currentAvatar);
    }

    public void Close()
    {
        StartCoroutine(SetFalse());
      
    }


    public void OnGirlAvatarSelected()
    {
        currentAvatar = 0;
    }

   
    public void OnBoyAvatarSelected()
    {
        currentAvatar = 1;
    }

    public void OnSaveButtonPressed()
    {
        PlayerPrefs.SetInt("avatarSelected", currentAvatar);
        PlayerPrefs.Save();
        avatar[currentAvatar].SetActive(true);
        StartCoroutine(SetFalse());
    }

    IEnumerator SetFalse()
    {
        yield return new WaitForSeconds(2);
        POPUP.SetActive(false);
        avatar[currentAvatar].SetActive(false);
    }

}
